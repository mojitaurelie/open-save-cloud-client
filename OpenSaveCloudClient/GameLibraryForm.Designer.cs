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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TasksButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AboutButton = new System.Windows.Forms.Button();
            this.LogButton = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.UserSettingsButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.SyncButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.LargeImageList = this.coverList;
            this.listView1.Location = new System.Drawing.Point(0, 80);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(1004, 406);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_Click);
            // 
            // coverList
            // 
            this.coverList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.coverList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("coverList.ImageStream")));
            this.coverList.TransparentColor = System.Drawing.Color.Transparent;
            this.coverList.Images.SetKeyName(0, "unknown_cover.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TasksButton,
            this.StatusLabel,
            this.MainProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1004, 25);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TasksButton
            // 
            this.TasksButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TasksButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TasksButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TasksButton.Name = "TasksButton";
            this.TasksButton.ShowDropDownArrow = false;
            this.TasksButton.Size = new System.Drawing.Size(32, 23);
            this.TasksButton.Text = "";
            this.TasksButton.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 20);
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.MarqueeAnimationSpeed = 20;
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(100, 20);
            this.MainProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.MainProgressBar.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AboutButton);
            this.panel1.Controls.Add(this.LogButton);
            this.panel1.Controls.Add(this.LogoutButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.UserSettingsButton);
            this.panel1.Controls.Add(this.SettingsButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DownloadButton);
            this.panel1.Controls.Add(this.SyncButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 80);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 80);
            this.panel1.TabIndex = 5;
            // 
            // AboutButton
            // 
            this.AboutButton.Enabled = false;
            this.AboutButton.FlatAppearance.BorderSize = 0;
            this.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AboutButton.Location = new System.Drawing.Point(505, 3);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(57, 74);
            this.AboutButton.TabIndex = 9;
            this.AboutButton.Text = "\r\n\r\nAbout";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // LogButton
            // 
            this.LogButton.FlatAppearance.BorderSize = 0;
            this.LogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LogButton.Location = new System.Drawing.Point(442, 3);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(57, 74);
            this.LogButton.TabIndex = 8;
            this.LogButton.Text = "\r\n\r\nLog";
            this.LogButton.UseVisualStyleBackColor = true;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.Enabled = false;
            this.LogoutButton.FlatAppearance.BorderSize = 0;
            this.LogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoutButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LogoutButton.Location = new System.Drawing.Point(379, 3);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(57, 74);
            this.LogoutButton.TabIndex = 7;
            this.LogoutButton.Text = "\r\n\r\nLogout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(353, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "|";
            // 
            // UserSettingsButton
            // 
            this.UserSettingsButton.Enabled = false;
            this.UserSettingsButton.FlatAppearance.BorderSize = 0;
            this.UserSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserSettingsButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserSettingsButton.Location = new System.Drawing.Point(290, 3);
            this.UserSettingsButton.Name = "UserSettingsButton";
            this.UserSettingsButton.Size = new System.Drawing.Size(57, 74);
            this.UserSettingsButton.TabIndex = 5;
            this.UserSettingsButton.Text = "\r\n\r\nMe";
            this.UserSettingsButton.UseVisualStyleBackColor = true;
            // 
            // SettingsButton
            // 
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SettingsButton.Location = new System.Drawing.Point(227, 3);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(57, 74);
            this.SettingsButton.TabIndex = 4;
            this.SettingsButton.Text = "\r\n\r\nOptions";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(201, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "|";
            // 
            // DownloadButton
            // 
            this.DownloadButton.Enabled = false;
            this.DownloadButton.FlatAppearance.BorderSize = 0;
            this.DownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DownloadButton.Location = new System.Drawing.Point(138, 3);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(57, 74);
            this.DownloadButton.TabIndex = 2;
            this.DownloadButton.Text = "\r\n\r\nGet";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // SyncButton
            // 
            this.SyncButton.Enabled = false;
            this.SyncButton.FlatAppearance.BorderSize = 0;
            this.SyncButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SyncButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SyncButton.Location = new System.Drawing.Point(75, 3);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(57, 74);
            this.SyncButton.TabIndex = 1;
            this.SyncButton.Text = "\r\n\r\nSync";
            this.SyncButton.UseVisualStyleBackColor = true;
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddButton.Location = new System.Drawing.Point(12, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(57, 74);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "\r\n\r\nAdd";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // GameLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1004, 511);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1016, 538);
            this.Name = "GameLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Library";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameLibrary_FormClosing);
            this.Load += new System.EventHandler(this.GameLibrary_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListView listView1;
        private ImageList coverList;
        private StatusStrip statusStrip1;
        private ToolStripDropDownButton TasksButton;
        private ToolStripStatusLabel StatusLabel;
        private ToolStripProgressBar MainProgressBar;
        private Panel panel1;
        private Button AddButton;
        private Label label1;
        private Button DownloadButton;
        private Button SyncButton;
        private Button UserSettingsButton;
        private Button SettingsButton;
        private Button LogoutButton;
        private Label label2;
        private Button AboutButton;
        private Button LogButton;
    }
}