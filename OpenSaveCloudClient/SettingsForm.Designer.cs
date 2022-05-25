namespace OpenSaveCloudClient
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IgdbClientSecret = new System.Windows.Forms.TextBox();
            this.IgdbClientID = new System.Windows.Forms.TextBox();
            this.IgdbCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AtCreationCheckBox = new System.Windows.Forms.CheckBox();
            this.AtLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.IgdbClientSecret);
            this.groupBox1.Controls.Add(this.IgdbClientID);
            this.groupBox1.Controls.Add(this.IgdbCheckBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(340, 287);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IGDB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 242);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Client Secret";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Client ID";
            // 
            // IgdbClientSecret
            // 
            this.IgdbClientSecret.Enabled = false;
            this.IgdbClientSecret.Location = new System.Drawing.Point(4, 259);
            this.IgdbClientSecret.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IgdbClientSecret.Name = "IgdbClientSecret";
            this.IgdbClientSecret.Size = new System.Drawing.Size(331, 23);
            this.IgdbClientSecret.TabIndex = 6;
            // 
            // IgdbClientID
            // 
            this.IgdbClientID.Enabled = false;
            this.IgdbClientID.Location = new System.Drawing.Point(4, 215);
            this.IgdbClientID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IgdbClientID.Name = "IgdbClientID";
            this.IgdbClientID.Size = new System.Drawing.Size(331, 23);
            this.IgdbClientID.TabIndex = 5;
            // 
            // IgdbCheckBox
            // 
            this.IgdbCheckBox.AutoSize = true;
            this.IgdbCheckBox.Enabled = false;
            this.IgdbCheckBox.Location = new System.Drawing.Point(4, 176);
            this.IgdbCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IgdbCheckBox.Name = "IgdbCheckBox";
            this.IgdbCheckBox.Size = new System.Drawing.Size(90, 19);
            this.IgdbCheckBox.TabIndex = 4;
            this.IgdbCheckBox.Text = "Enable IGDB";
            this.IgdbCheckBox.UseVisualStyleBackColor = true;
            this.IgdbCheckBox.CheckedChanged += new System.EventHandler(this.IgdbCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hint: OAuth Redirect URLs can be http://localhost";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(4, 154);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(120, 15);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://dev.twitch.tv/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 105);
            this.label2.TabIndex = 0;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 424);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AtCreationCheckBox);
            this.groupBox2.Controls.Add(this.AtLoginCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(8, 338);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(340, 73);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto synchronization";
            // 
            // AtCreationCheckBox
            // 
            this.AtCreationCheckBox.AutoSize = true;
            this.AtCreationCheckBox.Checked = true;
            this.AtCreationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AtCreationCheckBox.Location = new System.Drawing.Point(4, 48);
            this.AtCreationCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AtCreationCheckBox.Name = "AtCreationCheckBox";
            this.AtCreationCheckBox.Size = new System.Drawing.Size(170, 19);
            this.AtCreationCheckBox.TabIndex = 1;
            this.AtCreationCheckBox.Text = "After creating a game entry";
            this.AtCreationCheckBox.UseVisualStyleBackColor = true;
            // 
            // AtLoginCheckBox
            // 
            this.AtLoginCheckBox.AutoSize = true;
            this.AtLoginCheckBox.Checked = true;
            this.AtLoginCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AtLoginCheckBox.Location = new System.Drawing.Point(4, 27);
            this.AtLoginCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AtLoginCheckBox.Name = "AtLoginCheckBox";
            this.AtLoginCheckBox.Size = new System.Drawing.Size(82, 19);
            this.AtLoginCheckBox.TabIndex = 0;
            this.AtLoginCheckBox.Text = "After login";
            this.AtLoginCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(359, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(375, 426);
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private Label label5;
        private Label label4;
        private TextBox IgdbClientSecret;
        private TextBox IgdbClientID;
        private CheckBox IgdbCheckBox;
        private Label label3;
        private LinkLabel linkLabel1;
        private Button button1;
        private GroupBox groupBox2;
        private CheckBox AtCreationCheckBox;
        private CheckBox AtLoginCheckBox;
    }
}