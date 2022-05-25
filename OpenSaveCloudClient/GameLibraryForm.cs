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
            serverConnector = ServerConnector.GetInstance();
            _configuration = Configuration.GetInstance();
            logManager = LogManager.GetInstance();
            /*if (_configuration.GetBoolean("igdb.enabled", false))
            {
                string clientId = _configuration.GetString("igdb.client_id", "");
                string clientSecret = _configuration.GetString("igdb.client_secret", "");
                _client = new IGDBClient(clientId, clientSecret);
            }*/
        }

        private void GameLibrary_Load(object sender, EventArgs e)
        {
            taskManager.TaskChanged += taskManager_TaskChanged;
            logManager.Cleared += LogManager_LogCleared;
            logManager.NewMessage += LogManager_NewMessage;
            new Thread(() =>
            {
                serverConnector.Reconnect();
                if (!serverConnector.Connected)
                {
                    this.Invoke((MethodInvoker)delegate {
                        ShowLoginForm();
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate {
                        AboutButton.Enabled = true;
                        if (_configuration.GetBoolean("synchronization.at_login", true))
                        {
                            SyncButton_Click(sender, e);
                        } else
                        {
                            LockCriticalControls(false);
                        }
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
                AboutButton.Enabled = true;
                if (_configuration.GetBoolean("synchronization.at_login", true))
                {
                    SyncButton_Click(sender, e);
                }
                else
                {
                    LockCriticalControls(false);
                }
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
                        if (_configuration.GetBoolean("synchronization.at_game_creation", true))
                        {
                            SyncButton_Click(null, null);
                        }
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
                itm.SubItems.Add(game.Uuid);
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
            this.Invoke((MethodInvoker)delegate {
                MainProgressBar.Visible = (taskManager.TasksInformation.Count(ti => ti.Status == AsyncTaskStatus.Running) > 0);
                StatusLabel.Text = text;
            });
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            serverConnector.Logout();
            LockCriticalControls(true);
            AboutButton.Enabled = false;
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

        private void LogManager_NewMessage(object? sender, NewMessageEventArgs e)
        {
            int errors = logManager.Messages.Count(m => m.Severity == LogSeverity.Error);
            int warnings = logManager.Messages.Count(m => m.Severity == LogSeverity.Warning);
            string label = "";
            if (errors > 0)
            {
                label = String.Format("({0} errors)", errors);
            }
            if (warnings > 0)
            {
                if (errors > 0)
                {
                    label += " ";
                }
                label = String.Format("({0} warnings)", warnings);
            }
            if (errors > 0 || warnings > 0)
            {
                this.Invoke((MethodInvoker)delegate {
                    LogButton.Text = label;
                    LogButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                });
            }
        }

        private void LogManager_LogCleared(object? sender, ClearEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                LogButton.Text = "Show logs";
                LogButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            });
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            TasksForm form = new();
            form.Show();
        }

        private void SyncButton_Click(object sender, EventArgs e)
        {
            LockCriticalControls(true);
            new Thread(() => { 
                serverConnector.Synchronize();
                this.Invoke((MethodInvoker)delegate {
                    LockCriticalControls(false);
                });
            }).Start();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DownloadGameForm form = new DownloadGameForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                List<GameSave> newGames = form.Result;
                new Thread(async () => 
                {
                    string taskUuid = StartTask("Downloading games from server", false, newGames.Count);
                    foreach (GameSave gameSave in newGames)
                    {
                        try
                        {
                            saveManager.Saves.Add(gameSave);
                            List<GameSave> l = new()
                            {
                                gameSave
                            };
                            await serverConnector.DownloadGamesAsync(l);
                        } catch (Exception ex)
                        {
                            logManager.AddError(ex);
                        }
                        taskManager.UpdateTaskProgress(taskUuid, 1);
                    }
                    saveManager.Save();
                    SetTaskEnded(taskUuid);
                    this.Invoke((MethodInvoker)delegate {
                        RefreshList();
                    });
                }).Start();
            }
        }

        private void LockCriticalControls(bool l)
        {
            l = !l;
            AddButton.Enabled = l;
            SyncButton.Enabled = l;
            DownloadButton.Enabled = l;
            LogoutButton.Enabled = l;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1 && SyncButton.Enabled)
            {
                GameSave? g = saveManager.Saves.FirstOrDefault(g => g.Uuid == listView1.SelectedItems[0].SubItems[1].Text);
                if (g != null)
                {
                    DetailForm detail = new(g);
                    if (detail.ShowDialog() == DialogResult.OK)
                    {
                        ForcedSyncResult? r = detail.Result;
                        if (r != null)
                        {
                            LockCriticalControls(true);
                            new Thread(async () =>
                            {
                                List<GameSave> l = new()
                                {
                                    g
                                };
                                string taskUuid;
                                switch (r)
                                {
                                    case ForcedSyncResult.Download:
                                        taskUuid = StartTask("Forcing download of " + g.Name, true, 1);
                                        try
                                        {
                                            await serverConnector.DownloadGamesAsync(l);
                                        } finally
                                        {
                                            SetTaskEnded(taskUuid);
                                        }
                                        break;
                                    case ForcedSyncResult.Upload:
                                        taskUuid = StartTask("Forcing upload of " + g.Name, true, 1);
                                        try
                                        {
                                            g.Archive();
                                            serverConnector.UploadGames(l);
                                        }
                                        finally
                                        {
                                            SetTaskEnded(taskUuid);
                                        }
                                        break;
                                }
                                this.Invoke((MethodInvoker)delegate {
                                    LockCriticalControls(false);
                                });
                            }).Start();
                        }
                    }
                }
            }
        }
    }
}