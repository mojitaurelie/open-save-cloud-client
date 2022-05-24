using OpenSaveCloudClient.Core;
using OpenSaveCloudClient.Models;
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
    public enum ForcedSyncResult
    {
        Upload,
        Download
    }

    public partial class DetailForm : Form
    {

        private ForcedSyncResult? result;
        private GameSave gameSave;

        public ForcedSyncResult? Result { get { return result; } }

        public DetailForm(GameSave gameSave)
        {
            InitializeComponent();
            this.gameSave = gameSave;
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                        "Forcing upload will overwrite the save on the server, do you really want to forcing the upload of the save?",
                        "Warning: Forcing upload",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            result = ForcedSyncResult.Upload;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            TitleLabel.Text = gameSave.Name;
            Text = "Detail of " + gameSave.Name;
            RevisionLabel.Text = Convert.ToString(gameSave.Revision);
            PathLabel.Text = gameSave.FolderPath;
            SyncedLabel.Text = gameSave.Synced ? "Yes" : "No";
            ChecksumBox.Text = gameSave.CurrentHash;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                        "Forcing download will overwrite the local save, do you really want to forcing the download of the save?",
                        "Warning: Forcing download",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            result = ForcedSyncResult.Download;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
