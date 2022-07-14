using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenSaveCloudClient.Core;
using OpenSaveCloudClient.Models;

namespace OpenSaveCloudClient
{
    public partial class LogsForm : Form
    {

        private LogManager logManager;
        public LogsForm()
        {
            InitializeComponent();
            logManager = LogManager.GetInstance();
            logManager.NewMessage += logManager_NewError;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            logManager.Clear();
            listView1.Items.Clear();
        }

        public void logManager_NewError(object? sender, NewMessageEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ListViewItem lvi = listView1.Items.Add(e.Timestamp.ToString());
                lvi.SubItems.Add(e.Message);
                lvi.SubItems.Add(e.Severity.ToString());
            });
        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logManager.NewMessage -= logManager_NewError;
        }

        private void LogsForm_Load(object sender, EventArgs e)
        {
            foreach (Log l in logManager.Messages)
            {
                ListViewItem lvi = listView1.Items.Add(l.Timestamp.ToString());
                lvi.SubItems.Add(l.Message);
                lvi.SubItems.Add(l.Severity.ToString());
            }
        }
    }
}
