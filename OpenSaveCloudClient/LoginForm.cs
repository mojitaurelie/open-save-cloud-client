﻿using OpenSaveCloudClient.Core;
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
            if (string.IsNullOrWhiteSpace(ServerTextBox.Text))
            {
                MessageBox.Show("The server hostname or IP is empty, cannot login to an unknown server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockControls(false);
                return;
            }
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) || string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                MessageBox.Show("Password or username cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LockControls(false);
                return;
            }
            ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    decimal port = PortNumericBox.Value;
                    string host = ServerTextBox.Text;
                    if (host.StartsWith("https://"))
                    {
                        sslCheckBox.Checked = true;
                    }
                    else if (host.StartsWith("http://"))
                    {
                        sslCheckBox.Checked = false;
                    }
                    else
                    {
                        host = (sslCheckBox.Checked ? "https://" : "http://") + host;
                    }
                    serverConnector.BindNewServer(host, (int)port);
                    if (serverConnector.Bind)
                    {
                        serverConnector.Login(UsernameTextBox.Text, PasswordTextBox.Text);
                        if (serverConnector.Connected)
                        {
                            this.Invoke((MethodInvoker)delegate {
                                Close();
                            });
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate {
                                MessageBox.Show("Wrong username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LockControls(false);
                            });
                        }
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate {
                            MessageBox.Show("Failed to find the server, check the hostname or the port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LockControls(false);
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
            });
        }

        private void LockControls(bool value)
        {
            value = !value;
            ServerTextBox.Enabled = value;
            PortNumericBox.Enabled = value;
            UsernameTextBox.Enabled = value;
            PasswordTextBox.Enabled = value;
            LoginButton.Enabled = value;
            sslCheckBox.Enabled = value;
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            LogsForm form = new();
            form.Show();
        }
    }
}
