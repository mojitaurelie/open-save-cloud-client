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
    public partial class TasksForm : Form
    {
        private TaskManager taskManager;

        public TasksForm()
        {
            InitializeComponent();
            taskManager = TaskManager.GetInstance();
        }

        private void AddLVItem(string key, string name, string status, bool undefined, int value, int max)
        {
            ListViewItem lvi = new();
            ProgressBar pb = new();

            lvi.SubItems[0].Text = name;
            lvi.SubItems.Add(status);
            lvi.SubItems.Add("");
            lvi.SubItems.Add(key);
            listView1.Items.Add(lvi);

            Rectangle r = lvi.SubItems[2].Bounds;
            pb.SetBounds(r.X, r.Y, r.Width, r.Height);
            pb.Minimum = 0;
            pb.Maximum = max;
            pb.Value = value;
            pb.MarqueeAnimationSpeed = 20;
            if (undefined)
            {
                pb.Style = ProgressBarStyle.Marquee;
            }
            pb.Name = key;
            listView1.Controls.Add(pb);
        }

        private void UpdateItemValue(string key, string status, bool undefined, int value)
        {
            ListViewItem? lvi;
            ProgressBar? pb;

            // find the LVI based on the "key" in 
            lvi = listView1.Items.Cast<ListViewItem>().FirstOrDefault(q => q.SubItems[3].Text == key);
            if (lvi != null)
            {
                lvi.SubItems[1].Text = status;
            }
                

            pb = listView1.Controls.OfType<ProgressBar>().FirstOrDefault(q => q.Name == key);
            if (pb != null)
            {
                pb.Value = value;
                if (undefined)
                {
                    pb.Style = ProgressBarStyle.Marquee;
                } else
                {
                    pb.Style = ProgressBarStyle.Blocks;
                }
            }
                
        }

        private void taskManager_UpdateTask(object? sender, TaskChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                ListViewItem? lvi = listView1.Items.Cast<ListViewItem>().FirstOrDefault(q => q.SubItems[3].Text == e.TaskInformation.Uuid);
                if (lvi != null)
                {
                    UpdateItemValue(e.TaskInformation.Uuid, e.TaskInformation.Status.ToString(), e.TaskInformation.Undefined, e.TaskInformation.Progress);
                }
                else
                {
                    AddLVItem(e.TaskInformation.Uuid, e.TaskInformation.Label, e.TaskInformation.Status.ToString(), e.TaskInformation.Undefined, e.TaskInformation.Progress, e.TaskInformation.Max);
                }
            });
        }

        private void taskManager_ClearTask(object? sender, TaskClearedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                List<ListViewItem> toDelete = new();
                List<ProgressBar> toDeletePb = new();
                foreach (ListViewItem item in listView1.Items)
                {
                    string uuid = item.SubItems[3].Text;
                    AsyncTaskInformation? ati = taskManager.TasksInformation.FirstOrDefault(t => t.Uuid == uuid);
                    if (ati == null)
                    {
                        toDelete.Add(item);
                        ProgressBar? pb = listView1.Controls.OfType<ProgressBar>().FirstOrDefault(q => q.Name == uuid);
                        if (pb != null)
                        {
                            toDeletePb.Add(pb);
                        }
                    }
                    
                }
                foreach (ListViewItem item in toDelete)
                {
                    listView1.Items.Remove(item);
                }
                foreach (ProgressBar progressBar in toDeletePb)
                {
                    listView1.Controls.Remove(progressBar);
                }
                foreach (ListViewItem item in listView1.Items.Cast<ListViewItem>())
                {
                    ProgressBar? pb = listView1.Controls.OfType<ProgressBar>().FirstOrDefault(q => q.Name == item.SubItems[3].Text);
                    if (pb != null)
                    {
                        Rectangle r = item.SubItems[2].Bounds;
                        pb.SetBounds(r.X, r.Y, r.Width, r.Height);
                    }
                }
            });       
        }

        private void TasksForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            taskManager.TaskChanged -= taskManager_UpdateTask;
            taskManager.TaskCleared -= taskManager_ClearTask;
        }

        private void TasksForm_Load(object sender, EventArgs e)
        {
            foreach (AsyncTaskInformation ati in taskManager.TasksInformation)
            {
                AddLVItem(ati.Uuid, ati.Label, ati.Status.ToString(), ati.Undefined, ati.Progress, ati.Max);
            }
            taskManager.TaskChanged += taskManager_UpdateTask;
            taskManager.TaskCleared += taskManager_ClearTask;
        }
    }
}
