using OpenSaveCloudClient.Core;
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
    public partial class LoginForm : Form
    {

        private ServerConnector serverConnector;

        public LoginForm()
        {
            InitializeComponent();
            serverConnector = ServerConnector.GetInstance();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LockControls(true);
            try
            {
                if (string.IsNullOrWhiteSpace(ServerTextBox.Text))
                {
                    MessageBox.Show("The server hostname or IP is empty, cannot login to an unknown server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) || string.IsNullOrWhiteSpace(PasswordTextBox.Text))
                {
                    MessageBox.Show("Password or username cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal port = PortNumericBox.Value;
                serverConnector.BindNewServer(ServerTextBox.Text, (int)port);
                if (serverConnector.Bind)
                {
                    serverConnector.Login(UsernameTextBox.Text, PasswordTextBox.Text);
                    if (serverConnector.Connected)
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to find the server, check the hostname or the port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LockControls(false);
            }
        }

        private void LockControls(bool value)
        {
            value = !value;
            ServerTextBox.Enabled = value;
            PortNumericBox.Enabled = value;
            UsernameTextBox.Enabled = value;
            PasswordTextBox.Enabled = value;
            LoginButton.Enabled = value;
        }
    }
}
