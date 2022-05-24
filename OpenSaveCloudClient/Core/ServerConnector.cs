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
    /// <summary>
    /// This class is a connector to the remote Open Save Cloud server, it contains all the function that are mapped to the server endpoint
    /// This is a singleton, to get the instance, call <c>GetInstance()</c>
    /// </summary>
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

        /// <summary>
        /// method <c>BindNewServer</c> set the hostname (or ip) and the port of the server and try to connect
        /// </summary>
        /// <param name="host">hostname or IP of the server</param>
        /// <param name="port">port of the server</param>
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

        /// <summary>
        /// method <c>Login</c> connect a user and save the token to <c>token</c>
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
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

        /// <summary>
        /// method <c>Reconnect</c> try to reconnect with the token, hostname and port saved in the configuration file
        /// </summary>
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

        /// <summary>
        /// method <c>Logout</c> disconnect the current user and remove all the server's information of the config file
        /// </summary>
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

        /// <summary>
        /// method <c>CreateGame</c> create a new game entry in the server database
        /// </summary>
        /// <param name="name">The name of the game</param>
        /// <returns>The game that was created by the server</returns>
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
                    logManager.AddError(String.Format("Received HTTP Status {0} from the server", response.StatusCode.ToString()));
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

        /// <summary>
        /// method <c>Synchronize</c> is the method that upload and download the files from the server
        /// If there is conflict, a warning is generated and the files are keep untouched
        /// </summary>
        public async void Synchronize()
        {
            logManager.AddInformation("Starting synchronization");
            List<GameSave> games = saveManager.Saves;
            string uuidTask = taskManager.StartTask("Synchronizing games", true, games.Count);
            List<GameSave> toUpload = new();
            List<GameSave> toDownload = new();
            foreach (GameSave localCopy in games)
            {
                try
                {
                    // Get the current information that are stored in the server
                    Game? remoteCopy = GetGameInfoByID(localCopy.Id);
                    if (remoteCopy == null)
                    {
                        logManager.AddWarning(String.Format("'{0}' is not found on this server, force upload it from the game detail screen", localCopy.Name));
                        continue;
                    }

                    // Check if available on the server
                    if (!remoteCopy.Available)
                    {
                        logManager.AddInformation(String.Format("'{0}' does not exist in the server", localCopy.Name));
                        localCopy.DetectChanges();
                        toUpload.Add(localCopy);
                    }
                    else if (localCopy.DetectChanges() || !localCopy.Synced)
                    {
                        // Create an archive of the folder
                        localCopy.Archive();

                        // Upload only if the revision is the same
                        if (remoteCopy.Revision != localCopy.Revision)
                        {
                            logManager.AddWarning(String.Format("There revision of the local copy is not equal with the copy on the server ({0})", localCopy.Name));
                            logManager.AddInformation("To resolve this conflict, force download or force upload from the game detail screen");
                            continue;
                        }
                        toUpload.Add(localCopy);
                    }
                    else
                    {
                        if (remoteCopy.Revision > localCopy.Revision)
                        {
                            toDownload.Add(localCopy);
                        }
                        else if (remoteCopy.Revision < localCopy.Revision)
                        {
                            logManager.AddWarning(String.Format("There revision of the local copy is not equal with the copy on the server ({0})", localCopy.Name));
                            logManager.AddInformation("To resolve this conflict, force download or force upload from the game detail screen");
                        }
                    }
                } 
                catch (Exception ex)
                {
                    logManager.AddError(ex);
                }
                taskManager.UpdateTaskProgress(uuidTask, 1);
            }

            // Upload files
            UploadGames(toUpload);

            // Download new version of files
            await DownloadGamesAsync(toDownload);
            
            taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
        }

        /// <summary>
        /// method <c>UploadGames</c> upload the game saves to the server
        /// </summary>
        /// <param name="toUpload">A list of GameSaves</param>
        public void UploadGames(List<GameSave> toUpload)
        {
            string cachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osc", "cache");
            foreach (GameSave game in toUpload)
            {
                GameUploadToken? gut = LockGameToUpload(game.Id);
                if (gut != null)
                {
                    string archivePath = Path.Combine(cachePath, game.Uuid + ".bin");
                    if (UploadSave(gut.UploadToken, archivePath, game.CurrentHash))
                    {
                        game.UpdateHash();
                        UpdateCache(game);
                    }
                }
            }
            saveManager.Save();
        }

        /// <summary>
        /// method <c>DownloadGamesAsync</c> download the game saves from the server
        /// This method is async because of <c>DownloadSaveAsync</c> that are async too
        /// </summary>
        /// <param name="toDownload">A list of GameSaves</param>
        /// <returns>A task</returns>
        public async Task DownloadGamesAsync(List<GameSave> toDownload)
        {
            string cachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "osc", "cache");
            string archivePath;
            GameUploadToken? gut;
            foreach (GameSave game in toDownload)
            {
                gut = LockGameToUpload(game.Id);
                if (gut != null)
                {
                    archivePath = Path.Combine(cachePath, game.Uuid + ".bin");
                    if (await DownloadSaveAsync(gut.UploadToken, archivePath, game.FolderPath))
                    {
                        game.DetectChanges();
                        game.UpdateHash();
                        UpdateCache(game);
                    }
                }
            }
            saveManager.Save();
        }

        /// <summary>
        /// method <c>GetGameInfoByID</c> get the game save information from the server
        /// </summary>
        /// <param name="gameId">A game id</param>
        /// <returns>A remote object of a game save</returns>
        public Game? GetGameInfoByID(long gameId)
        {
            logManager.AddInformation("Getting game information from the server database");
            string uuidTask = taskManager.StartTask("Getting game information", true, 1);
            try
            {
                using (HttpClient client = new HttpClient())
                {
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
                        logManager.AddError(String.Format("Received HTTP Status {0} from the server", response.StatusCode.ToString()));
                    }
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
                }
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            return null;
        }

        /// <summary>
        /// method <c>GetGamesInfo</c> get all the save registered on the server of the current user
        /// </summary>
        /// <param name="gameId">A game id</param>
        /// <returns>A list of remote object of a game save</returns>
        public List<Game>? GetGamesInfo()
        {
            logManager.AddInformation("Getting game information from the server database");
            string uuidTask = taskManager.StartTask("Getting game information", true, 1);
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                    HttpResponseMessage response = client.GetAsync(string.Format("{0}:{1}/api/v1/game/all", host, port)).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = response.Content.ReadAsStringAsync().Result;
                        taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
                        return JsonSerializer.Deserialize<List<Game>>(responseText);
                    }
                    else
                    {
                        logManager.AddError(String.Format("Received HTTP Status {0} from the server", response.StatusCode.ToString()));
                    }
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
                }
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            return null;
        }

        /// <summary>
        /// method <c>UploadSave</c> upload a file to the server
        /// </summary>
        /// <param name="uploadToken">The Lock token that a provided by the server</param>
        /// <param name="filePath">The path of the file</param>
        /// <param name="newHash">The new hash of the folder</param>
        public bool UploadSave(string uploadToken, string filePath, string newHash)
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

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                    client.DefaultRequestHeaders.Add("X-Upload-Key", uploadToken);
                    client.DefaultRequestHeaders.Add("X-Game-Save-Hash", newHash);
                    HttpResponseMessage response = client.PostAsync(string.Format("{0}:{1}/api/v1/game/upload", host, port), multipartFormContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
                        return true;
                    }
                    else
                    {
                        logManager.AddError(String.Format("Received HTTP Status {0} from the server", response.StatusCode.ToString()));
                    }
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
                }
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            } finally
            {
                stream.Close();
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uploadToken">The Lock token that a provided by the server</param>
        /// <param name="filePath">The path where the downloaded archive will be stored</param>
        /// <param name="unzipPath">The path is stored the save</param>
        /// <returns>If the save is successfully downloaded and unpacked</returns>
        public async Task<bool> DownloadSaveAsync(string uploadToken, string filePath, string unzipPath)
        {
            logManager.AddInformation("Downloading save");
            string uuidTask = taskManager.StartTask("Downloading", true, 1);
            try
            {
                using (HttpClient client = new HttpClient())
                {
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
                        logManager.AddError(String.Format("Received HTTP Status {0} from the server", response.StatusCode.ToString()));
                        taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
                    }
                }
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            return false;
        }

        /// <summary>
        /// method <c>UpdateCache</c> update the GameSave object with the server data
        /// </summary>
        /// <param name="gameSave">A GameSave object</param>
        private void UpdateCache(GameSave gameSave)
        {
            string uuidTask = taskManager.StartTask("Updating cache", true, 1);
            Game? game = GetGameInfoByID(gameSave.Id);
            if (game != null)
            {
                gameSave.Revision = game.Revision;
                gameSave.Synced = true;
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Ended);
            }
            else
            {
                logManager.AddError("Failed to get game information");
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
        }

        /// <summary>
        /// method <c>LockGameToUpload</c> lock a game save on the server
        /// This method is useful to avoid competing uploads/downloads
        /// </summary>
        /// <param name="gameId">A game id</param>
        /// <returns>A token to give to the upload/download method</returns>
        private GameUploadToken? LockGameToUpload(long gameId)
        {
            logManager.AddInformation("Locking game in the server");
            string uuidTask = taskManager.StartTask("Locking game", true, 1);
            try
            {
                using (HttpClient client = new HttpClient())
                {
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
                        logManager.AddError(String.Format("Received HTTP Status {0} from the server", response.StatusCode.ToString()));
                    }
                    taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
                }  
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                taskManager.UpdateTaskStatus(uuidTask, AsyncTaskStatus.Failed);
            }
            return null;
        }

        /// <summary>
        /// method <c>ReloadFromConfiguration</c> load the server information (host, port and token) from the configuration file
        /// </summary>
        /// <returns>The configuration is valid</returns>
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

        /// <summary>
        /// method <c>GetServerInformation</c> get information about the connected server
        /// </summary>
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

        /// <summary>
        /// method <c>SaveToConfig</c> save the server connection information to the configuration file
        /// </summary>
        private void SaveToConfig()
        {
            configuration.SetValue("authentication.host", host);
            configuration.SetValue("authentication.port", port);
            configuration.SetValue("authentication.token", token);
            configuration.Flush();
        }

    }
}
