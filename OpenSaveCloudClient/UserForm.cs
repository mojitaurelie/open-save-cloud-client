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
    public partial class UserForm : Form
    {

        private ServerConnector serverConnector;

        public UserForm()
        {
            InitializeComponent();
            serverConnector = ServerConnector.GetInstance();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            User? u = serverConnector.ConnectedUser;
            if (u == null)
            {
                Close();
                return;
            }
            UsernameBox.Text = u.Username;
        }

        private void SavePasswordButton_Click(object sender, EventArgs e)
        {
            LockControls(true);
            SavePasswordButton.Enabled = false;
            if (string.IsNullOrEmpty(NewPasswordBox.Text) || string.IsNullOrEmpty(PasswordAgainBox.Text))
            {
                MessageBox.Show(
                        "Password fields are empty",
                        "Change password",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                LockControls(false);
                return;
            }
            if (NewPasswordBox.Text != PasswordAgainBox.Text)
            {
                MessageBox.Show(
                        "Passwords not matches",
                        "Change password",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                LockControls(false);
                return;
            }
            new Thread(() =>
            {
                serverConnector.ChangePassword(new NewPassword { Password = NewPasswordBox.Text, VerifyPassword = PasswordAgainBox.Text });
                this.Invoke((MethodInvoker)delegate {
                    NewPasswordBox.Clear();
                    PasswordAgainBox.Clear();
                    LockControls(false);
                });
            }).Start();
        }

        private void LockControls(bool l)
        {
            l = !l;
            NewPasswordBox.Enabled = l;
            PasswordAgainBox.Enabled = l;
        }

        private void NewPasswordBox_TextChanged(object sender, EventArgs e)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(NewPasswordBox.Text) || string.IsNullOrEmpty(PasswordAgainBox.Text))
            {
                valid = false;
            }
            else if (NewPasswordBox.Text != PasswordAgainBox.Text)
            {
                valid = false;
            }
            SavePasswordButton.Enabled = valid;
        }
    }
}
