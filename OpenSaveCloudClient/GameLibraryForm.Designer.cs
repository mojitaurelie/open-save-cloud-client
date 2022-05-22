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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddButton = new System.Windows.Forms.ToolStripButton();
            this.SyncButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ConfigButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LogoutButton = new System.Windows.Forms.ToolStripButton();
            this.ErrorLogButton = new System.Windows.Forms.ToolStripButton();
            this.AboutButton = new System.Windows.Forms.ToolStripButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.coverList = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 803);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1428, 32);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(28, 29);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 25);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddButton,
            this.SyncButton,
            this.toolStripSeparator1,
            this.ConfigButton,
            this.toolStripSeparator2,
            this.LogoutButton,
            this.ErrorLogButton,
            this.AboutButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1428, 33);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddButton
            // 
            this.AddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(34, 28);
            this.AddButton.Text = "Add a game";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SyncButton
            // 
            this.SyncButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SyncButton.Image = ((System.Drawing.Image)(resources.GetObject("SyncButton.Image")));
            this.SyncButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(34, 28);
            this.SyncButton.Text = "Synchronize";
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // ConfigButton
            // 
            this.ConfigButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ConfigButton.Image = ((System.Drawing.Image)(resources.GetObject("ConfigButton.Image")));
            this.ConfigButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConfigButton.Name = "ConfigButton";
            this.ConfigButton.Size = new System.Drawing.Size(34, 28);
            this.ConfigButton.Text = "Settings";
            this.ConfigButton.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // LogoutButton
            // 
            this.LogoutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LogoutButton.Image = ((System.Drawing.Image)(resources.GetObject("LogoutButton.Image")));
            this.LogoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(34, 28);
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ErrorLogButton
            // 
            this.ErrorLogButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ErrorLogButton.Image = ((System.Drawing.Image)(resources.GetObject("ErrorLogButton.Image")));
            this.ErrorLogButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ErrorLogButton.Name = "ErrorLogButton";
            this.ErrorLogButton.Size = new System.Drawing.Size(34, 28);
            this.ErrorLogButton.Text = "Show log";
            this.ErrorLogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
            this.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(34, 28);
            this.AboutButton.Text = "About";
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.LargeImageList = this.coverList;
            this.listView1.Location = new System.Drawing.Point(0, 36);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(1428, 764);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // coverList
            // 
            this.coverList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.coverList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("coverList.ImageStream")));
            this.coverList.TransparentColor = System.Drawing.Color.Transparent;
            this.coverList.Images.SetKeyName(0, "unknown_cover.png");
            // 
            // GameLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1428, 835);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1450, 891);
            this.Name = "GameLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Library";
            this.Load += new System.EventHandler(this.GameLibrary_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStrip toolStrip1;
        private ToolStripButton AddButton;
        private ToolStripButton SyncButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton LogoutButton;
        private ListView listView1;
        private ToolStripButton ConfigButton;
        private ToolStripSeparator toolStripSeparator2;
        private ImageList coverList;
        private ToolStripButton AboutButton;
        private ToolStripButton ErrorLogButton;
        private ToolStripDropDownButton toolStripDropDownButton1;
    }
}