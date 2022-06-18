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
    public partial class AddUser : Form
    {

        private ServerConnector serverConnector;
        private TaskManager taskManager;

        public AddUser()
        {
            InitializeComponent();
            serverConnector = ServerConnector.GetInstance();
            taskManager = TaskManager.GetInstance();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            PasswordBox.Text = PasswordTool.GeneratePassword();
        }

        private void UsernameBox_TextChanged(object sender, EventArgs e)
        {
            bool ok = true;
            if (UsernameBox.Text.Length < 3)
            {
                ok = false;
            }
            else if (!PasswordTool.CheckRequirements(PasswordBox.Text))
            {
                ok = false;
            }
            button1.Enabled = ok;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LockControls(true);
            new Thread(() =>
            {
                try
                {
                    Registration registration = new()
                    {
                        Username = UsernameBox.Text,
                        Password = PasswordBox.Text,
                    };
                    User? u = serverConnector.CreateUser(registration);
                    if (u == null)
                    {
                        this.Invoke((MethodInvoker)delegate {
                            MessageBox.Show("Failed to create the user. Refer to the server log to know why", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LockControls(false);
                        });
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate {
                            Close();
                        });
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LockControls(false);
                    });
                }
            }).Start();
        }

        private void LockControls(bool value)
        {
            value = !value;
            UsernameBox.Enabled = value;
            PasswordBox.Enabled = value;
            button1.Enabled = value;
        }
    }
}
