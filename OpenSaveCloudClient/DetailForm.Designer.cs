namespace OpenSaveCloudClient
{
    partial class DetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailForm));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RevisionLabel = new System.Windows.Forms.Label();
            this.PathLabel = new System.Windows.Forms.Label();
            this.SyncedLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ChecksumBox = new System.Windows.Forms.TextBox();
            this.UploadButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.AutoEllipsis = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(941, 48);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "_";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Revision";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Synced";
            // 
            // RevisionLabel
            // 
            this.RevisionLabel.AutoSize = true;
            this.RevisionLabel.Location = new System.Drawing.Point(125, 95);
            this.RevisionLabel.Name = "RevisionLabel";
            this.RevisionLabel.Size = new System.Drawing.Size(16, 25);
            this.RevisionLabel.TabIndex = 4;
            this.RevisionLabel.Text = ".";
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(125, 120);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(16, 25);
            this.PathLabel.TabIndex = 5;
            this.PathLabel.Text = ".";
            // 
            // SyncedLabel
            // 
            this.SyncedLabel.AutoSize = true;
            this.SyncedLabel.Location = new System.Drawing.Point(125, 145);
            this.SyncedLabel.Name = "SyncedLabel";
            this.SyncedLabel.Size = new System.Drawing.Size(16, 25);
            this.SyncedLabel.TabIndex = 6;
            this.SyncedLabel.Text = ".";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Checksum";
            // 
            // ChecksumBox
            // 
            this.ChecksumBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChecksumBox.Location = new System.Drawing.Point(125, 173);
            this.ChecksumBox.Name = "ChecksumBox";
            this.ChecksumBox.ReadOnly = true;
            this.ChecksumBox.Size = new System.Drawing.Size(828, 31);
            this.ChecksumBox.TabIndex = 8;
            // 
            // UploadButton
            // 
            this.UploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UploadButton.Location = new System.Drawing.Point(12, 244);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(112, 34);
            this.UploadButton.TabIndex = 9;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DownloadButton.Location = new System.Drawing.Point(130, 244);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(112, 34);
            this.DownloadButton.TabIndex = 10;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 290);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.ChecksumBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SyncedLabel);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.RevisionLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TitleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(987, 346);
            this.Name = "DetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detail of";
            this.Load += new System.EventHandler(this.DetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label TitleLabel;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label RevisionLabel;
        private Label PathLabel;
        private Label SyncedLabel;
        private Label label8;
        private TextBox ChecksumBox;
        private Button UploadButton;
        private Button DownloadButton;
    }
}