namespace OpenSaveCloudClient
{
    partial class GameLibrary
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameLibrary));
            this.listView1 = new System.Windows.Forms.ListView();
            this.coverList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddButton = new System.Windows.Forms.ToolStripButton();
            this.SyncButton = new System.Windows.Forms.ToolStripButton();
            this.DownloadButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SettingButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LogoutButton = new System.Windows.Forms.ToolStripButton();
            this.LogButton = new System.Windows.Forms.ToolStripButton();
            this.AboutButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TasksButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.LargeImageList = this.coverList;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(1506, 766);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // coverList
            // 
            this.coverList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.coverList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("coverList.ImageStream")));
            this.coverList.TransparentColor = System.Drawing.Color.Transparent;
            this.coverList.Images.SetKeyName(0, "unknown_cover.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddButton,
            this.SyncButton,
            this.DownloadButton,
            this.toolStripSeparator1,
            this.SettingButton,
            this.toolStripSeparator2,
            this.LogoutButton,
            this.LogButton,
            this.AboutButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1506, 33);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddButton
            // 
            this.AddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddButton.Enabled = false;
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(34, 28);
            this.AddButton.Text = "Add";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SyncButton
            // 
            this.SyncButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SyncButton.Enabled = false;
            this.SyncButton.Image = ((System.Drawing.Image)(resources.GetObject("SyncButton.Image")));
            this.SyncButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(34, 28);
            this.SyncButton.Text = "Sync";
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DownloadButton.Enabled = false;
            this.DownloadButton.Image = ((System.Drawing.Image)(resources.GetObject("DownloadButton.Image")));
            this.DownloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(34, 28);
            this.DownloadButton.Text = "Download from server";
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // SettingButton
            // 
            this.SettingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingButton.Image")));
            this.SettingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(34, 28);
            this.SettingButton.Text = "Settings";
            this.SettingButton.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // LogoutButton
            // 
            this.LogoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LogoutButton.Enabled = false;
            this.LogoutButton.Image = ((System.Drawing.Image)(resources.GetObject("LogoutButton.Image")));
            this.LogoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(34, 28);
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // LogButton
            // 
            this.LogButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LogButton.Image = ((System.Drawing.Image)(resources.GetObject("LogButton.Image")));
            this.LogButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(34, 28);
            this.LogButton.Text = "Show logs";
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutButton.Enabled = false;
            this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
            this.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(34, 28);
            this.AboutButton.Text = "About";
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TasksButton,
            this.StatusLabel,
            this.MainProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 735);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1506, 31);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TasksButton
            // 
            this.TasksButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TasksButton.Image = ((System.Drawing.Image)(resources.GetObject("TasksButton.Image")));
            this.TasksButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TasksButton.Name = "TasksButton";
            this.TasksButton.ShowDropDownArrow = false;
            this.TasksButton.Size = new System.Drawing.Size(28, 28);
            this.TasksButton.Text = "Tasks";
            this.TasksButton.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 24);
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(150, 23);
            this.MainProgressBar.Visible = false;
            // 
            // GameLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1506, 766);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1519, 797);
            this.Name = "GameLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Library";
            this.Load += new System.EventHandler(this.GameLibrary_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListView listView1;
        private ImageList coverList;
        private ToolStrip toolStrip1;
        private ToolStripButton AddButton;
        private ToolStripButton SyncButton;
        private ToolStripButton DownloadButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton SettingButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton LogoutButton;
        private ToolStripButton LogButton;
        private ToolStripButton AboutButton;
        private StatusStrip statusStrip1;
        private ToolStripDropDownButton TasksButton;
        private ToolStripStatusLabel StatusLabel;
        private ToolStripProgressBar MainProgressBar;
    }
}