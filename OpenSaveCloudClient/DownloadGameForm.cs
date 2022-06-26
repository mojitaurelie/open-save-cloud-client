using OpenSaveCloudClient.Core;
using OpenSaveCloudClient.Models;
using OpenSaveCloudClient.Models.Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenSaveCloudClient
{
    public partial class DownloadGameForm : Form
    {

        private ServerConnector serverConnector;
        private SaveManager saveManager;
        private ListViewItem? selectedItem;

        private List<GameSave> result;

        public List<GameSave> Result { get { return result; } }

        public DownloadGameForm()
        {
            InitializeComponent();
            result = new List<GameSave>();
            serverConnector = ServerConnector.GetInstance();
            saveManager = SaveManager.GetInstance();
        }

        private void DownloadGameForm_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate {
                List<Game>? remoteGames = serverConnector.GetGamesInfo();
                this.Invoke((MethodInvoker)delegate {
                    UpdateRemoteList(remoteGames);
                });
            });
        }

        private void UpdateRemoteList(List<Game>? remoteGames)
        {
            if (remoteGames != null)
            {
                foreach (Game game in remoteGames)
                {
                    if (game.Available)
                    {
                        if (!saveManager.Saves.Exists(g => g.Id == game.Id))
                        {
                            ListViewItem lvi = RemoteList.Items.Add(game.Name);
                            lvi.SubItems.Add(Convert.ToString(game.Id));
                            lvi.SubItems.Add("");
                        }
                    }
                }
            }
            LockControls(false);
        }

        private void LockControls(bool l)
        {
            LoadingIndicator.Visible = l;
            l = !l;
            RemoteList.Enabled = l;
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                LocationBox.Text = path;
                if (selectedItem != null && selectedItem.Checked)
                {
                    selectedItem.SubItems[2].Text = path;
                }
            }
        }

        private void RemoteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = null;
            if (RemoteList.SelectedItems.Count == 1)
            {
                selectedItem = RemoteList.SelectedItems[0];
                if (selectedItem != null && selectedItem.Checked)
                {
                    pathButton.Enabled = true;
                    LocationBox.Enabled = true;
                    LocationBox.Text = selectedItem.SubItems[2].Text;
                }
                
            } else
            {
                pathButton.Enabled = false;
                LocationBox.Enabled = false;
                LocationBox.Clear();
            }
        }

        private void RemoteList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            DownloadButton.Enabled = (RemoteList.CheckedItems.Count > 0);
            RemoteList_SelectedIndexChanged(sender, e);
        }

        private void LocationBox_TextChanged(object sender, EventArgs e)
        {
            if (selectedItem != null && selectedItem.Checked)
            {
                selectedItem.SubItems[2].Text = LocationBox.Text;
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in RemoteList.CheckedItems)
            {
                string path = lvi.SubItems[2].Text;
                if (string.IsNullOrWhiteSpace(path))
                {
                    MessageBox.Show("File folder cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    if (saveManager.Saves.Exists(g => g.FolderPath == path))
                    {
                        MessageBox.Show("This directory is already used for another game", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (Directory.EnumerateFileSystemEntries(path).Any())
                    {
                        string msg = String.Format("The directory '{0}' contains files, these files will be deleted. Do you want to continue using this folder?", path);
                        if (MessageBox.Show(
                            msg,
                            "Directory not empty",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                GameSave gameSave = new(lvi.SubItems[0].Text, "", path, "", 0);
                gameSave.Id = Int64.Parse(lvi.SubItems[1].Text);
                result.Add(gameSave);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
