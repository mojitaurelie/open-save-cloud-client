﻿using OpenSaveCloudClient.Models;
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
            ThreadPool.QueueUserWorkItem(delegate
            {
                this.Invoke((MethodInvoker)delegate {
                    CheckPaths();
                });
                serverConnector.Reconnect();
                if (!serverConnector.Connected)
                {
                    this.Invoke((MethodInvoker)delegate {
                        ShowLoginForm();
                    });
                }
                else
                {
                    string taskUuid = StartTask("Detecting changes...", true, 1);
                    try
                    {
                        saveManager.DetectChanges();
                        this.Invoke((MethodInvoker)delegate {
                            SetAdminControls();
                            AboutButton.Enabled = true;
                            if (_configuration.GetBoolean("synchronization.at_login", true))
                            {
                                SyncButton_Click(sender, e);
                            }
                            else
                            {
                                LockCriticalControls(false);
                            }
                        });
                        SetTaskEnded(taskUuid);
                    }
                    catch (Exception e)
                    {
                        logManager.AddError(e);
                        SetTaskFailed(taskUuid);
                    }
                }
            });
        }

        private void CheckPaths()
        {
            List<GameSave> toDelete = new();
            foreach (GameSave save in saveManager.Saves)
            {
                if (!save.PathExist())
                {
                    string message = String.Format("The path of '{0}' is not found\n\n{1}\n\nDo you want to locate the new path?", save.Name, save.FolderPath);
                    DialogResult res = MessageBox.Show(message, "Missing path", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (res == DialogResult.Yes)
                    {
                        FolderBrowserDialog dialog = new();
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            save.FolderPath = dialog.SelectedPath;
                        }
                    } 
                    else
                    {
                        toDelete.Add(save);
                    }
                }
            }
            foreach (GameSave save in toDelete)
            {
                saveManager.Saves.Remove(save);
            }
            saveManager.Save();
            RefreshList();
        }

        private void ShowLoginForm()
        {
            Enabled = false;
            LoginForm loginForm = new();
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
                ThreadPool.QueueUserWorkItem(delegate
                {
                    string taskUuid = StartTask("Detecting changes...", true, 1);
                    try
                    {
                        saveManager.DetectChanges();
                        SetTaskEnded(taskUuid);
                    }
                    catch (Exception e)
                    {
                        logManager.AddError(e);
                        SetTaskFailed(taskUuid);
                    }
                });
                SetAdminControls();
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

        private void SetAdminControls()
        {
            if (serverConnector.ConnectedUser != null && serverConnector.ConnectedUser.IsAdmin)
            {
                UserSettingsButton.Click += UserSettingsButton_Admin_Click;
                UserSettingsButton.Text = "\n\nUsers";
            }
            else
            {
                UserSettingsButton.Click += UserSettingsButton_Click;
                UserSettingsButton.Text = "\n\nMe";
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddGameForm form = new(_client);
            if (form.ShowDialog() == DialogResult.OK) {
                GameSave newGame = form.Result;
                ThreadPool.QueueUserWorkItem(delegate { AddGameToLibrary(newGame); });
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
            if (serverConnector.ConnectedUser != null && serverConnector.ConnectedUser.IsAdmin)
            {
                UserSettingsButton.Click -= UserSettingsButton_Admin_Click;
            }
            else
            {
                UserSettingsButton.Click -= UserSettingsButton_Click;
            }
            UserSettingsButton.Text = "\n\nMe";
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
            bool errors = logManager.Messages.Exists(m => m.Severity != LogSeverity.Information);
            if (errors)
            {
                this.Invoke((MethodInvoker)delegate {
                    LogButton.Text = "\n\nLog";
                });
            }
        }

        private void LogManager_LogCleared(object? sender, ClearEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                LogButton.Text = "\n\nLog";
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
            ThreadPool.QueueUserWorkItem(delegate { 
                serverConnector.Synchronize();
                this.Invoke((MethodInvoker)delegate {
                    LockCriticalControls(false);
                });
            });
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
            UserSettingsButton.Enabled = l;
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

        private void UserSettingsButton_Click(object? sender, EventArgs e)
        {
            UserForm form = new();
            form.ShowDialog();
        }

        private void UserSettingsButton_Admin_Click(object? sender, EventArgs e)
        {
            UserManagementForm form = new();
            form.ShowDialog();
        }

        private void GameLibrary_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool busy = (taskManager.TasksInformation.Count(ti => ti.Status == AsyncTaskStatus.Running) > 0);
            if (busy)
            {
                logManager.Cleared -= LogManager_LogCleared;
                logManager.NewMessage -= LogManager_NewMessage;
                WaitingForm form = new();
                form.ShowDialog();
                taskManager.TaskChanged -= taskManager_TaskChanged;
            }
        }
    }
}