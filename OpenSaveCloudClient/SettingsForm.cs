using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenSaveCloudClient.Models;

namespace OpenSaveCloudClient
{
    public partial class SettingsForm : Form
    {

        private readonly Configuration _configuration;

        public SettingsForm()
        {
            InitializeComponent();
            _configuration = Configuration.GetInstance();
            InitAndFillFields();
        }

        private void InitAndFillFields()
        {
            IgdbCheckBox.Checked = _configuration.GetBoolean("igdb.enabled", false);
            IgdbClientID.Text = _configuration.GetString("igdb.client_id", "");
            IgdbClientSecret.Text = _configuration.GetString("igdb.client_secret", "");
        }

        private void IgdbCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IgdbClientID.Enabled = IgdbCheckBox.Checked;
            IgdbClientSecret.Enabled = IgdbCheckBox.Checked;
        }

        private void Save()
        {
            _configuration.SetValue("igdb.enabled", IgdbCheckBox.Checked);
            _configuration.SetValue("igdb.client_id", IgdbClientID.Text);
            _configuration.SetValue("igdb.client_secret", IgdbClientSecret.Text);
            _configuration.Flush();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }
    }
}
