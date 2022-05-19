﻿namespace OpenSaveCloudClient
{
    partial class AboutBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ClientInfoLabel = new System.Windows.Forms.Label();
            this.ServerInfoLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ApiVersionLabel = new System.Windows.Forms.Label();
            this.ServerVersionLabel = new System.Windows.Forms.Label();
            this.AllowRegisterLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(507, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Open Save Cloud";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // VersionLabel
            // 
            this.VersionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.VersionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VersionLabel.Location = new System.Drawing.Point(0, 204);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(507, 37);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.Text = "0.0.0.0";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(507, 114);
            this.label2.TabIndex = 3;
            this.label2.Text = "Made by Aurélie Delhaie\r\nThis project exist because all games \r\ndon\'t have the cl" +
    "oud save feature\r\n(Like The Sims 4)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Client:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Server:";
            // 
            // ClientInfoLabel
            // 
            this.ClientInfoLabel.AutoSize = true;
            this.ClientInfoLabel.Location = new System.Drawing.Point(86, 36);
            this.ClientInfoLabel.Name = "ClientInfoLabel";
            this.ClientInfoLabel.Size = new System.Drawing.Size(24, 25);
            this.ClientInfoLabel.TabIndex = 7;
            this.ClientInfoLabel.Text = "...";
            // 
            // ServerInfoLabel
            // 
            this.ServerInfoLabel.AutoSize = true;
            this.ServerInfoLabel.Location = new System.Drawing.Point(86, 61);
            this.ServerInfoLabel.Name = "ServerInfoLabel";
            this.ServerInfoLabel.Size = new System.Drawing.Size(24, 25);
            this.ServerInfoLabel.TabIndex = 8;
            this.ServerInfoLabel.Text = "...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ServerInfoLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ClientInfoLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 378);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 242);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Geek informations";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ApiVersionLabel);
            this.groupBox2.Controls.Add(this.ServerVersionLabel);
            this.groupBox2.Controls.Add(this.AllowRegisterLabel);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 143);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "API";
            // 
            // ApiVersionLabel
            // 
            this.ApiVersionLabel.AutoSize = true;
            this.ApiVersionLabel.Location = new System.Drawing.Point(231, 90);
            this.ApiVersionLabel.Name = "ApiVersionLabel";
            this.ApiVersionLabel.Size = new System.Drawing.Size(24, 25);
            this.ApiVersionLabel.TabIndex = 5;
            this.ApiVersionLabel.Text = "...";
            // 
            // ServerVersionLabel
            // 
            this.ServerVersionLabel.AutoSize = true;
            this.ServerVersionLabel.Location = new System.Drawing.Point(231, 65);
            this.ServerVersionLabel.Name = "ServerVersionLabel";
            this.ServerVersionLabel.Size = new System.Drawing.Size(50, 25);
            this.ServerVersionLabel.TabIndex = 4;
            this.ServerVersionLabel.Text = "0.0.0";
            // 
            // AllowRegisterLabel
            // 
            this.AllowRegisterLabel.AutoSize = true;
            this.AllowRegisterLabel.Location = new System.Drawing.Point(231, 40);
            this.AllowRegisterLabel.Name = "AllowRegisterLabel";
            this.AllowRegisterLabel.Size = new System.Drawing.Size(24, 25);
            this.AllowRegisterLabel.TabIndex = 3;
            this.AllowRegisterLabel.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "API Server version:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Server version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Allow registration of user:";
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 632);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(529, 688);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(529, 688);
            this.Name = "AboutBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About OSC";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label VersionLabel;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label ClientInfoLabel;
        private Label ServerInfoLabel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label ApiVersionLabel;
        private Label ServerVersionLabel;
        private Label AllowRegisterLabel;
        private Label label7;
        private Label label6;
        private Label label3;
    }
}