using OpenSaveCloudClient.Models;
using OpenSaveCloudClient.Core;
using IGDB;
using OpenSaveCloudClient.Models.Remote;

namespace OpenSaveCloudClient
{
    public partial class GameLibrary : Form
    {

        private readonly Configuration _configuration;
        private readonly IGDBClient? _client;
        private readonly SaveManager saveManager;
        private readonly TaskManager taskManager;
        private readonly ServerConnector serverConnector;
        private readonly LogManager logManager;


        public GameLibrary()
        {
            InitializeComponent();
            saveManager = SaveManager.GetInstance();
            taskManager = TaskManager.GetInstance();
            taskManager.TaskChanged += taskManager_TaskChanged;
            serverConnector = ServerConnector.GetInstance();
            _configuration = Configuration.GetInstance();
            logManager = LogManager.GetInstance();
            if (_configuration.GetBoolean("igdb.enabled", false))
            {
                string clientId = _configuration.GetString("igdb.client_id", "");
                string clientSecret = _configuration.GetString("igdb.client_secret", "");
                _client = new IGDBClient(clientId, clientSecret);
            }
        }

        private void GameLibrary_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                serverConnector.Reconnect();
                if (!serverConnector.Connected)
                {
                    this.Invoke((MethodInvoker)delegate {
                        ShowLoginForm();
                    });
                }
            }).Start();
            
            RefreshList();
        }

        private void ShowLoginForm()
        {
            Enabled = false;
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += LoginForm_Close;
            loginForm.Show();
        }

        private void LoginForm_Close(object? sender, EventArgs e)
        {
            if (!serverConnector.Connected)
            {
                Close();
            } else
            {
                Enabled = true;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddGameForm form = new(_client);
            if (form.ShowDialog() == DialogResult.OK) {
                GameSave newGame = form.Result;
                new Thread(() => AddGameToLibrary(newGame)).Start();
            }
        }

        private void AddGameToLibrary(GameSave newGame)
        {
            string taskUuid = "";
            try
            {
                taskUuid = StartTask(String.Format("Archiving \"{0}\"", newGame.Name), true, 1);
                Game? g = serverConnector.CreateGame(newGame.Name);
                if (g != null)
                {
                    newGame.Id = g.Id;
                    newGame.Archive();
                    saveManager.Saves.Add(newGame);
                    saveManager.Save();
                    SetTaskEnded(taskUuid);
                    this.Invoke((MethodInvoker)delegate {
                        RefreshList();
                    });
                } else
                {
                    logManager.AddError(new Exception("Failed to create game on the server"));
                    SetTaskFailed(taskUuid);
                }
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
                SetTaskFailed(taskUuid);
            }
        }

        private void ConfigButton_Click(object sender, EventArgs e)
        {
            SettingsForm form = new();
            form.ShowDialog();
        }

        private void RefreshList()
        {
            listView1.Clear();
            foreach (GameSave game in saveManager.Saves)
            {
                ListViewItem itm = listView1.Items.Add(game.Name);
                itm.ImageKey = "unknown_cover.png";
            }
        }

        private string StartTask(string label, bool undefined, int maxProgress)
        {
            return taskManager.StartTask(label, undefined, maxProgress);
        }

        private void SetTaskEnded(string uuid)
        {
            try
            {
                taskManager.UpdateTaskStatus(uuid, AsyncTaskStatus.Ended);
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
            }
        }

        private void SetTaskFailed(string uuid)
        {
            try
            {
                taskManager.UpdateTaskStatus(uuid, AsyncTaskStatus.Failed);
            }
            catch (Exception ex)
            {
                logManager.AddError(ex);
            }
        }

        private void taskManager_TaskChanged(object? sender, TaskChangedEventArgs e)
        {
            string text = "";
            switch (e.TaskInformation.Status)
            {
                case AsyncTaskStatus.Running:
                    text = e.TaskInformation.Label;
                    break;
                case AsyncTaskStatus.Stopped:
                    text = String.Format("Stopped: {0}", e.TaskInformation.Label);
                    break;
                case AsyncTaskStatus.Failed:
                    text = String.Format("Failed: {0}", e.TaskInformation.Label);
                    break;
                case AsyncTaskStatus.Ended:
                    text = String.Format("Ended: {0}", e.TaskInformation.Label);
                    break;
            }
            toolStripStatusLabel1.Text = text;
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            serverConnector.Logout();
            ShowLoginForm();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new();
            aboutBox.ShowDialog();
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            LogsForm form = new();
            form.Show();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            TasksForm form = new();
            form.Show();
        }

        private void SyncButton_Click(object sender, EventArgs e)
        {
            new Thread(() => serverConnector.Synchronize()).Start();
        }
    }
}