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
    public partial class WaitingForm : Form
    {
        private TaskManager taskManager;
        bool busy = true;
        public WaitingForm()
        {
            InitializeComponent();
            taskManager = TaskManager.GetInstance();
            taskManager.TaskChanged += OnTaskChanged;
        }

        private void WaitingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = busy;
        }

        private void OnTaskChanged(object? sender, TaskChangedEventArgs e)
        {
            busy = (taskManager.TasksInformation.Count(ti => ti.Status == AsyncTaskStatus.Running) > 0);
            if (!busy)
            {
                this.Invoke((MethodInvoker)delegate {
                    Close();
                });
            }
        }
    }
}
