using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using OpenSaveCloudClient.Models.Remote;
using OpenSaveCloudClient.Models;

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

        private Configuration configuration;

        public string? Host { get { return host; } }
        public int Port { get { return port; } }
        public bool Bind { get { return bind; } }
        public bool Connected { get { return connected; } }
        public ServerInformation? ServerInformation { get { return serverInformation; } }

        private ServerConnector()
        {
            configuration = Configuration.GetInstance();
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
            this.host = host;
            this.port = port;
            GetServerInformation();
        }

        private void GetServerInformation()
        {
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
                        bind = true;
                    }
                }
            }
            catch (Exception)
            { }
        }

        public void Login(string username, string password)
        {
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
                    }
                }
            }
            catch (Exception)
            { }
        }

        public void Reconnect()
        {
            try
            {
                if (ReloadFromConfiguration())
                {
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
                        }
                        else
                        {
                            Logout();
                        }
                    }
                }
            }
            catch (Exception)
            { }
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
            catch (Exception)
            {
                return false;
            }
            return true;
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

        private void SaveToConfig()
        {
            configuration.SetValue("authentication.host", host);
            configuration.SetValue("authentication.port", port);
            configuration.SetValue("authentication.token", token);
            configuration.Flush();
        }
    }
}
