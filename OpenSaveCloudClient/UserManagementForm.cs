using OpenSaveCloudClient.Core;
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
    public partial class UserManagementForm : Form
    {

        private ServerConnector serverConnector;

        public UserManagementForm()
        {
            InitializeComponent();
            serverConnector = ServerConnector.GetInstance();
        }

        private void UserSettingsButton_Click(object sender, EventArgs e)
        {
            UserForm frm = new();
            frm.ShowDialog();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                List<User>? users = serverConnector.GetUsers();
                if (users != null)
                {
                    this.Invoke((MethodInvoker)delegate {
                        UpdateRemoteList(users);
                    });
                }
            }).Start();
        }

        private void UpdateRemoteList(List<User> users)
        {
            foreach (User user in users)
            {
                ListViewItem lvi = listView1.Items.Add(user.Username);
                lvi.SubItems.Add(Convert.ToString(user.Id));
                lvi.SubItems.Add(user.Role);
            }
        }
    }
}
