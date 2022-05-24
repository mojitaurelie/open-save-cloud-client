namespace OpenSaveCloudClient
{
    partial class DownloadGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadGameForm));
            this.label1 = new System.Windows.Forms.Label();
            this.LoadingIndicator = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pathButton = new System.Windows.Forms.Button();
            this.LocationBox = new System.Windows.Forms.TextBox();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.RemoteList = new System.Windows.Forms.ListView();
            this.GameName = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingIndicator)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Download a game save";
            // 
            // LoadingIndicator
            // 
            this.LoadingIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadingIndicator.Image = ((System.Drawing.Image)(resources.GetObject("LoadingIndicator.Image")));
            this.LoadingIndicator.Location = new System.Drawing.Point(854, 12);
            this.LoadingIndicator.Name = "LoadingIndicator";
            this.LoadingIndicator.Size = new System.Drawing.Size(48, 48);
            this.LoadingIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadingIndicator.TabIndex = 7;
            this.LoadingIndicator.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pathButton);
            this.groupBox1.Controls.Add(this.LocationBox);
            this.groupBox1.Location = new System.Drawing.Point(396, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 516);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set up the save";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(311, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Where will the save folder be located?";
            // 
            // pathButton
            // 
            this.pathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pathButton.Enabled = false;
            this.pathButton.Location = new System.Drawing.Point(453, 101);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(47, 34);
            this.pathButton.TabIndex = 6;
            this.pathButton.Text = "...";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.pathButton_Click);
            // 
            // LocationBox
            // 
            this.LocationBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LocationBox.Enabled = false;
            this.LocationBox.Location = new System.Drawing.Point(6, 104);
            this.LocationBox.Name = "LocationBox";
            this.LocationBox.Size = new System.Drawing.Size(441, 31);
            this.LocationBox.TabIndex = 5;
            this.LocationBox.TextChanged += new System.EventHandler(this.LocationBox_TextChanged);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadButton.Enabled = false;
            this.DownloadButton.Location = new System.Drawing.Point(790, 605);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(112, 34);
            this.DownloadButton.TabIndex = 9;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // RemoteList
            // 
            this.RemoteList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoteList.CheckBoxes = true;
            this.RemoteList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GameName});
            this.RemoteList.Location = new System.Drawing.Point(12, 83);
            this.RemoteList.Name = "RemoteList";
            this.RemoteList.Size = new System.Drawing.Size(378, 516);
            this.RemoteList.TabIndex = 10;
            this.RemoteList.UseCompatibleStateImageBehavior = false;
            this.RemoteList.View = System.Windows.Forms.View.Details;
            this.RemoteList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.RemoteList_ItemChecked);
            this.RemoteList.SelectedIndexChanged += new System.EventHandler(this.RemoteList_SelectedIndexChanged);
            // 
            // GameName
            // 
            this.GameName.Text = "Game name";
            this.GameName.Width = 373;
            // 
            // DownloadGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(914, 651);
            this.Controls.Add(this.RemoteList);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LoadingIndicator);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(936, 707);
            this.Name = "DownloadGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download a game save";
            this.Load += new System.EventHandler(this.DownloadGameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingIndicator)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private PictureBox LoadingIndicator;
        private GroupBox groupBox1;
        private Button DownloadButton;
        private ListView RemoteList;
        private ColumnHeader GameName;
        private Label label3;
        private Button pathButton;
        private TextBox LocationBox;
    }
}