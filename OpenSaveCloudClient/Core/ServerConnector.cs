using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using OpenSaveCloudClient.Models.Remote;
using OpenSaveCloudClient.Models;
using System.Net.Http.Headers;
using System.IO.Compression;

namespace OpenSaveCloudClient.Core
{
    public class ServerConnector
    {
        private static ServerConnector? instance;

        private string? token;
        private string? host;
        private int port;
        private bool bind;
        private bool connected;
        private ServerInformation? serverInformation;

        private LogManager logManager;
        private TaskManager taskManager;
        private Configuration configuration;
        private SaveManager saveManager;


        public string? Host { get { return host; } }
        public int Port { get { return port; } }
        public bool Bind { get { return bind; } }
        public bool Connected { get { return connected; } }
        public ServerInformation? ServerInformation { get { return serverInformation; } }

        private ServerConnector()
        {
            configuration = Configuration.GetInstance();
            logManager = LogManager.GetInstance();
            taskManager = TaskManager.GetInstance();
            saveManager = SaveManager.GetInstance();
        }

        public static ServerConnector GetInstance()
        {
            if (instance == null)
            {
                instance = new ServerConnector();
            }
            return instance;
        }

        public void BindNewServer(string host, int port)
        {
            Logout();
            if (!host.StartsWith("http://") && !host.StartsWith("https://"))
            {
                host = "http://" + host;
            }
            logManager.AddInformation(String.Format("Binding server {0}:{1}", host, port));
            this.host = host;
            this.port = port;
            GetServerInformation();
        }

        public void Login(string username, string password)
        {
            logManager.AddInformation("Loging in to the server");
            string uuidTask = taskManager.StartTask("Login to the server", true, 1);
            try
            {
                HttpClient client = new HttpClient();
                string json = JsonSerializer.Serialize(new Credential { Username = username, Password = password });
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(string.Format("{0}:{1}/api/v1/login", host, port), content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseText = response.Content.ReadAsStringAsync().Result;
                    AccessToken? accessToken = JsonSerializer.Deserialize<AccessToken>(responseText);
                    if (accessToken != null)
                    {
                        token = accessToken.Token;
                        connected = true;
                        SaveToConfig();
                        taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
                    }
                    else
                    {
                        taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
                    }
                } 
                else
                {
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
                }
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
        }

        public void Reconnect()
        {
            string? uuidTask = null;
            try
            {
                if (ReloadFromConfiguration())
                {
                    uuidTask = taskManager.StartTask("Login to the server", true, 1);
                    HttpClient client = new HttpClient();
                    string json = JsonSerializer.Serialize(new AccessToken { Token = token });
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(string.Format("{0}:{1}/api/v1/check/token", host, port), content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = response.Content.ReadAsStringAsync().Result;
                        TokenValidation? accessToken = JsonSerializer.Deserialize<TokenValidation>(responseText);
                        if (accessToken != null && accessToken.Valid)
                        {
                            connected = true;
                            SaveToConfig();
                            taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
                        }
                        else
                        {
                            Logout();
                            taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
                        }
                    }
                    else
                    {
                        Logout();
                        taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
                    }
                }
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                if (uuidTask != null)
                {
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
                }
            }
        }

        public void Logout()
        {
            serverInformation = null;
            bind = false;
            connected = false;
            token = "";
            configuration.SetValue("authentication.host", null);
            configuration.SetValue("authentication.port", null);
            configuration.SetValue("authentication.token", null);
            configuration.Flush();
        }

        public Game? CreateGame(string name)
        {
            logManager.AddInformation("Creating game to server database");
            string uuidTask = taskManager.StartTask("Creating game to server database", true, 1);
            try
            {
                HttpClient client = new HttpClient();
                string json = JsonSerializer.Serialize(new NewGameInfo { Name = name });
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage response = client.PostAsync(string.Format("{0}:{1}/api/v1/game/create", host, port), content).Result;
                if (response.IsSuccessStatusCode)
                {
                    logManager.AddInformation("Game created!");
                    string responseText = response.Content.ReadAsStringAsync().Result;
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
                    return JsonSerializer.Deserialize<Game>(responseText);
                } else
                {
                    logManager.AddError(new Exception(String.Format("Received HTTP Status {0} from the server", response.StatusCode.ToString())));
                }
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            return null;
        }

        public async void Synchronize()
        {
            string appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osc");
            string cachePath = Path.Combine(appdata, "cache");
            logManager.AddInformation("Starting synchronization");
            List<GameSave> games = saveManager.Saves;
            string uuidTask = taskManager.StartTask("Synchronizing games", true, games.Count);
            List<GameSave> toUpload = new();
            List<GameSave> toDownload = new();
            foreach (GameSave game in games)
            {
                try
                {
                    game.Archive();
                    Game? g = GetGameInfoByID(game.Id);
                    if (g != null)
                    {
                        if (g.Available)
                        {
                            if (g.Revision > game.Revision)
                            {
                                toDownload.Add(game);
                            }
                            else if (g.Revision < game.Revision)
                            {
                                logManager.AddWarning(String.Format("Revision are the same, maybe uploaded by another computer ({0})", game.Name));
                                logManager.AddInformation("To resolve this conflict, force download or force upload from the game detail screen");
                            }
                            else
                            {
                                toUpload.Add(game);
                            }
                        } else
                        {
                            logManager.AddInformation(String.Format("First upload of '{0}'", game.Name));
                            toUpload.Add(game);
                        }
                    } else
                    {
                        logManager.AddWarning(String.Format("'{0}' is not found on this server, force upload it from the game detail screen", game.Name));
                    }
                } catch (Exception ex)
                {
                    logManager.AddError(ex);
                }
                taskManager.UpdateTaskProgress(uuidTask, 1);
            }
            foreach (GameSave game in toUpload)
            {
                GameUploadToken? gut = LockGameToUpload(game.Id);
                if (gut != null)
                {
                    string archivePath = Path.Combine(cachePath, game.Uuid + ".bin");
                    UploadSave(gut.UploadToken, archivePath);
                    UpdateCache(game.Id, game);
                }
            }
            foreach (GameSave game in toDownload)
            {
                GameUploadToken? gut = LockGameToUpload(game.Id);
                if (gut != null)
                {
                    string archivePath = Path.Combine(cachePath, game.Uuid + ".bin");
                    if (await DownloadSaveAsync(gut.UploadToken, archivePath, game.FolderPath))
                    {
                        UpdateCache(game.Id, game);
                    }
                }
            }
            saveManager.Save();
            taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
        }

        public Game? GetGameInfoByID(int gameId)
        {
            logManager.AddInformation("Getting game information from the server database");
            string uuidTask = taskManager.StartTask("Getting game information", true, 1);
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage response = client.GetAsync(string.Format("{0}:{1}/api/v1/game/info/{2}", host, port, gameId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseText = response.Content.ReadAsStringAsync().Result;
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
                    return JsonSerializer.Deserialize<Game>(responseText);
                }
                else
                {
                    logManager.AddError(new Exception(String.Format("Received HTTP Status {0} from the server", response.StatusCode.ToString())));
                }
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            return null;
        }

        public void UploadSave(string uploadToken, string filePath)
        {
            logManager.AddInformation("Uploading save");
            string uuidTask = taskManager.StartTask("Uploading", true, 1);
            FileStream stream = File.OpenRead(filePath);
            try
            {
                MultipartFormDataContent multipartFormContent = new();
                var fileStreamContent = new StreamContent(stream);
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                multipartFormContent.Add(fileStreamContent, name: "file", fileName: "file.bin");

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                client.DefaultRequestHeaders.Add("X-Upload-Key", uploadToken);
                HttpResponseMessage response = client.PostAsync(string.Format("{0}:{1}/api/v1/game/upload", host, port), multipartFormContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
                    return;
                }
                else
                {
                    logManager.AddError(new Exception(String.Format("Received HTTP Status {0} from the server", response.StatusCode.ToString())));
                }
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            } finally
            {
                stream.Close();
            }
        }

        public async Task<bool> DownloadSaveAsync(string uploadToken, string filePath, string unzipPath)
        {
            logManager.AddInformation("Downloading save");
            string uuidTask = taskManager.StartTask("Downloading", true, 1);
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                client.DefaultRequestHeaders.Add("X-Upload-Key", uploadToken);
                HttpResponseMessage response = client.GetAsync(string.Format("{0}:{1}/api/v1/game/download", host, port)).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await response.Content.CopyToAsync(fs);
                    }
                    if (Directory.Exists(unzipPath))
                    {
                        Directory.Delete(unzipPath, true);
                    }
                    ZipFile.ExtractToDirectory(filePath, unzipPath);
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
                    return true;
                }
                else
                {
                    logManager.AddError(new Exception(String.Format("Received HTTP Status {0} from the server", response.StatusCode.ToString())));
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
                }
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            return false;
        }

        private void UpdateCache(int gameId, GameSave gameSave)
        {
            string uuidTask = taskManager.StartTask("Updating cache", true, 1);
            Game? game = GetGameInfoByID(gameId);
            if (game != null)
            {
                gameSave.Revision = game.Revision;
                gameSave.LocalOnly = false;
                gameSave.Synced = true;
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
            }
            else
            {
                logManager.AddError(new Exception("Failed to get game information"));
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
        }

        private GameUploadToken? LockGameToUpload(int gameId)
        {
            logManager.AddInformation("Locking game in the server");
            string uuidTask = taskManager.StartTask("Locking game", true, 1);
            try
            {
                HttpClient client = new HttpClient();
                string json = JsonSerializer.Serialize(new UploadGameInfo { GameId = gameId });
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                HttpResponseMessage response = client.PostAsync(string.Format("{0}:{1}/api/v1/game/upload/init", host, port), content).Result;
                if (response.IsSuccessStatusCode)
                {
                    logManager.AddInformation("Game locked");
                    string responseText = response.Content.ReadAsStringAsync().Result;
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
                    return JsonSerializer.Deserialize<GameUploadToken>(responseText);
                }
                else
                {
                    logManager.AddError(new Exception(String.Format("Received HTTP Status {0} from the server", response.StatusCode.ToString())));
                }
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            return null;
        }

        private bool ReloadFromConfiguration()
        {
            string newHost = configuration.GetString("authentication.host", "");
            int newPort = configuration.GetInt("authentication.port", 443);
            if (string.IsNullOrWhiteSpace(newHost))
            {
                return false;
            }
            try
            {
                string oldToken = configuration.GetString("authentication.token", "");
                BindNewServer(newHost, newPort);
                if (!bind)
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(oldToken))
                {
                    return false;
                }
                token = oldToken;
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                return false;
            }
            return true;
        }

        private void GetServerInformation()
        {
            logManager.AddInformation("Getting server information");
            string uuidTask = taskManager.StartTask("Getting server information", true, 1);
            try
            {
                HttpClient client = new();
                HttpResponseMessage response = client.GetAsync(string.Format("{0}:{1}/api/v1/system/information", host, port)).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseText = response.Content.ReadAsStringAsync().Result;
                    serverInformation = JsonSerializer.Deserialize<ServerInformation>(responseText);
                    if (serverInformation != null)
                    {
                        logManager.AddInformation("Server is connected");
                        bind = true;
                        taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
            }
            taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
        }

        private void SaveToConfig()
        {
            configuration.SetValue("authentication.host", host);
            configuration.SetValue("authentication.port", port);
            configuration.SetValue("authentication.token", token);
            configuration.Flush();
        }
    }
}
