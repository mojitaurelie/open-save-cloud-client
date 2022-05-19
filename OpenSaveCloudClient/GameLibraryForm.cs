using OpenSaveCloudClient.Models;
using OpenSaveCloudClient.Core;
using IGDB;

namespace OpenSaveCloudClient
{
    public partial class GameLibrary : Form
    {

        private readonly Configuration _configuration;
        private readonly IGDBClient? _client;
        private readonly SaveManager saveManager;
        private readonly TaskManager taskManager;
        private readonly ServerConnector serverConnector;
        

        public GameLibrary()
        {
            InitializeComponent();
            saveManager = SaveManager.GetInstance();
            taskManager = TaskManager.GetInstance();
            serverConnector = ServerConnector.GetInstance();
            _configuration = Configuration.GetInstance();
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
                this.Invoke((MethodInvoker)delegate {
                    taskUuid = StartTask(String.Format("Archiving \"{0}\"", newGame.Name), 1);
                });
                newGame.Archive();
                saveManager.Saves.Add(newGame);
                saveManager.Save();
                this.Invoke((MethodInvoker)delegate {
                    RefreshList();
                    SetTaskEnded(taskUuid);
                });
            }
            catch (Exception)
            {
                this.statusStrip1.Invoke((MethodInvoker)delegate {
                    this.Invoke((MethodInvoker)delegate {
                        SetTaskFailed(taskUuid);
                    });
                });
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

        private string StartTask(string label, int maxProgress)
        {
            toolStripStatusLabel1.Text = string.Format("{0}...", label);
            return taskManager.StartTask(label, maxProgress);
        }

        private void SetTaskEnded(string uuid)
        {
            try
            {
                var task = taskManager.GetTask(uuid);
                task.Progress = task.Max;
                task.Status = AsyncTaskStatus.Ended;
                toolStripStatusLabel1.Text = string.Format("{0} finished", task.Label);
            }
            catch (Exception ex)
            {
                //todo: catch exception
            }
        }

        private void SetTaskFailed(string uuid)
        {
            try
            {
                var task = taskManager.GetTask(uuid);
                task.Status = AsyncTaskStatus.Failed;
                toolStripStatusLabel1.Text = string.Format("{0} failed", task.Label);
            }
            catch (Exception ex)
            {
                //todo: catch exception
            }
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
    }
}