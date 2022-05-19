using OpenSaveCloudClient.Core;
using OpenSaveCloudClient.Models.Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenSaveCloudClient
{
    public partial class AboutBox : Form
    {
        private ServerConnector serverConnector;

        public AboutBox()
        {
            InitializeComponent();
            serverConnector = ServerConnector.GetInstance();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            if (serverConnector != null)
            {
                ServerInformation? si = serverConnector.ServerInformation;
                if (si != null)
                {
                    string serverInfo = "Go [{0} {1}/{2}]";
                    serverInfo = string.Format(serverInfo, si.GoVersion, si.OsName, si.OsArchitecture);
                    ServerInfoLabel.Text = serverInfo;
                    AllowRegisterLabel.Text = (si.AllowRegister) ? "Yes" : "No";
                    ServerVersionLabel.Text = si.Version;
                    ApiVersionLabel.Text = Convert.ToString(si.ApiVersion);
                }
            }
            Assembly a = Assembly.GetExecutingAssembly();
            Version? v = a.GetName().Version;
            if (v != null)
            {
                VersionLabel.Text = v.ToString();
            }
            string clientInfo = "C# [Core .NET {0}/{1}]";
            Version dotNetVersion = Environment.Version;
            string? clrArch = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            clientInfo = string.Format(clientInfo, dotNetVersion, clrArch);
            ClientInfoLabel.Text = clientInfo;
        }
    }
}
