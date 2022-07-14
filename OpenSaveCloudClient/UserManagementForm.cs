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
            LoadUsers();
        }

        private void LoadUsers()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                List<User>? users = serverConnector.GetUsers();
                if (users != null)
                {
                    this.Invoke((MethodInvoker)delegate {
                        UpdateRemoteList(users);
                    });
                }
            });
        }

        private void UpdateRemoteList(List<User> users)
        {
            if (serverConnector.ConnectedUser == null)
            {
                Close();
                return;
            }
            foreach (User user in users)
            {
                if (user.Username != serverConnector.ConnectedUser.Username)
                {
                    ListViewItem lvi = listView1.Items.Add(user.Username);
                    lvi.SubItems.Add(Convert.ToString(user.Id));
                    lvi.SubItems.Add(user.Role);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewPasswordBox.Text = "";
            PasswordAgainBox.Text = "";
            bool singleActivate = (listView1.SelectedItems.Count == 1);
            bool multiActivate = (listView1.SelectedItems.Count > 0);
            DeleteButton.Enabled = multiActivate;
            UsernameBox.Enabled = singleActivate;
            NewPasswordBox.Enabled = singleActivate;
            PasswordAgainBox.Enabled = singleActivate;
            if (singleActivate)
            {
                ListViewItem item = listView1.SelectedItems[0];
                UsernameBox.Text = item.Text;
            }
            else
            {
                UsernameBox.Text = "";
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddUser form = new();
            form.ShowDialog();
            listView1.Items.Clear();
            LoadUsers();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Remove the selected users? This action cannot be undo", "Remove users", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                LockControls(true);
                List<long> ids = new();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    long userId = Convert.ToInt64(item.SubItems[1].Text);
                    ids.Add(userId);
                }
                ThreadPool.QueueUserWorkItem(delegate
                {
                    try
                    {
                        foreach (long id in ids)
                        {
                            serverConnector.DeleteUser(id);
                        }
                        this.Invoke((MethodInvoker)delegate
                        {
                            listView1.Items.Clear();
                            LoadUsers();
                        });
                    }
                    catch (Exception ex)
                    {
                        this.Invoke((MethodInvoker)delegate {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                    finally
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            LockControls(false);
                        });
                    }
                });
            }
        }

        private void LockControls(bool v)
        {
            v = !v;
            AddButton.Enabled = v;
            DeleteButton.Enabled = v;
            UserSettingsButton.Enabled = v;
            listView1.Enabled = v;
            UsernameBox.Enabled = v;
            NewPasswordBox.Enabled = v;
            PasswordAgainBox.Enabled = v;
            if (v)
            {
                listView1_SelectedIndexChanged(null, null);
            }
            if (!v)
            {
                saveUsernameButton.Enabled = v;
                SavePasswordButton.Enabled = v;
            }
        }

        private void NewPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1) {
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
            else
            {
                SavePasswordButton.Enabled = false;
            }
        }

        private void SavePasswordButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                return;
            }
            LockControls(true);
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
            if (!PasswordTool.CheckRequirements(NewPasswordBox.Text))
            {
                MessageBox.Show(
                        "Passwords need at least 6 characters",
                        "Change password",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                LockControls(false);
                return;
            }
            long userId = Convert.ToInt64(listView1.SelectedItems[0].SubItems[1].Text);
            ThreadPool.QueueUserWorkItem(delegate
            {
                serverConnector.ChangePassword(userId, new NewPassword { Password = NewPasswordBox.Text, VerifyPassword = PasswordAgainBox.Text });
                this.Invoke((MethodInvoker)delegate {
                    NewPasswordBox.Clear();
                    PasswordAgainBox.Clear();
                    LockControls(false);
                });
            });
        }

        private void saveUsernameButton_Click(object sender, EventArgs e)
        {
            LockControls(true);
            if (UsernameBox.Text.Length < 3)
            {
                MessageBox.Show(
                        "Username need at least 3 characters",
                        "Change username",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                LockControls(false);
                return;
            }
            long userId = Convert.ToInt64(listView1.SelectedItems[0].SubItems[1].Text);
            ThreadPool.QueueUserWorkItem(delegate
            {
                serverConnector.ChangeUsername(new UpdateUsername { Id = userId, Username = UsernameBox.Text });
                this.Invoke((MethodInvoker)delegate {
                    listView1.SelectedItems[0].SubItems[0].Text = UsernameBox.Text;
                    LockControls(false);
                });
            });
        }

        private void UsernameBox_TextChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string currentUsername = listView1.SelectedItems[0].SubItems[0].Text;
                bool valid = true;
                if (UsernameBox.Text.Length < 3)
                {
                    valid = false;
                }
                else if (UsernameBox.Text == currentUsername)
                {
                    valid = false;
                }
                saveUsernameButton.Enabled = valid;
            }
            else
            {
                saveUsernameButton.Enabled = false;
            }
            
        }
    }
}
