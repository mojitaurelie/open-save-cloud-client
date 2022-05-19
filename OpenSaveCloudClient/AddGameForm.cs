﻿using IGDB;
using IGDB.Models;
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
    public partial class AddGameForm : Form
    {

        private readonly IGDBClient? _client;
        private GameSave result;

        public GameSave Result { get { return result; } }

        public AddGameForm(IGDBClient? iGDBClient)
        {
            InitializeComponent();
            _client = iGDBClient;
            if (_client == null)
            {
                NoCoverLabel.Text = "IGDB is not configured";
            }
            else
            {
                NoCoverLabel.Visible = false;
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (_client != null)
            {
                NoCoverLabel.Visible = false;
                CoverPicture.Visible = true;
                if (!string.IsNullOrWhiteSpace(NameBox.Text))
                {
                    try
                    {
                        string query = string.Format("fields *; search \"{0}\";", NameBox.Text.Replace("\"", ""));
                        Game[] games = await _client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: query);
                        games = games.Where(g => g.Cover != null && g.Cover.Value != null).ToArray();
                        if (games.Length > 0)
                        {
                            Game game = games.First();
                            CoverPicture.LoadAsync(game.Cover.Value.Url);
                        }
                        else
                        {
                            CoverPicture.Visible = false;
                            NoCoverLabel.Text = "No cover found";
                            NoCoverLabel.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        CoverPicture.Visible = false;
                        NoCoverLabel.Text = ex.Message;
                        NoCoverLabel.Visible = true;
                    }
                }
            }
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            if (_client != null)
            {
                timer1.Stop();
                timer1.Start();
            }
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                LocationBox.Text = path;
                if (string.IsNullOrWhiteSpace(NameBox.Text))
                {
                    NameBox.Text = path.Split(Path.DirectorySeparatorChar).Last();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LockControls(true);
            try
            {
                if (string.IsNullOrWhiteSpace(LocationBox.Text))
                {
                    MessageBox.Show("File folder cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Directory.Exists(LocationBox.Text))
                {
                    MessageBox.Show("This directory does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(NameBox.Text))
                {
                    NameBox.Text = LocationBox.Text.Split(Path.DirectorySeparatorChar).Last();
                }
                result = new GameSave(NameBox.Text, "", LocationBox.Text, null, 0);
                DialogResult = DialogResult.OK;
                Close();
            } finally
            {
                LockControls(false);
            }
        }

        private void LockControls(bool value)
        {
            value = !value;
            button1.Enabled = value;
            NameBox.Enabled = value;
            LocationBox.Enabled = value;
            pathButton.Enabled = value;
        }
    }
}
