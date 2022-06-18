namespace OpenSaveCloudClient
{
    partial class UserManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagementForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UserSettingsButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveUsernameButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SavePasswordButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordAgainBox = new System.Windows.Forms.TextBox();
            this.NewPasswordBox = new System.Windows.Forms.TextBox();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name});
            this.listView1.Location = new System.Drawing.Point(12, 86);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 352);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 220;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.UserSettingsButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 80);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 80);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(138, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "|";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeleteButton.Location = new System.Drawing.Point(75, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(57, 74);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "\r\n\r\nDelete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UserSettingsButton
            // 
            this.UserSettingsButton.FlatAppearance.BorderSize = 0;
            this.UserSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserSettingsButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserSettingsButton.Location = new System.Drawing.Point(164, 3);
            this.UserSettingsButton.Name = "UserSettingsButton";
            this.UserSettingsButton.Size = new System.Drawing.Size(57, 74);
            this.UserSettingsButton.TabIndex = 8;
            this.UserSettingsButton.Text = "\r\n\r\nMe";
            this.UserSettingsButton.UseVisualStyleBackColor = true;
            this.UserSettingsButton.Click += new System.EventHandler(this.UserSettingsButton_Click);
            // 
            // AddButton
            // 
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.saveUsernameButton);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.UsernameBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(252, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 352);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail";
            // 
            // saveUsernameButton
            // 
            this.saveUsernameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveUsernameButton.Enabled = false;
            this.saveUsernameButton.Location = new System.Drawing.Point(444, 83);
            this.saveUsernameButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveUsernameButton.Name = "saveUsernameButton";
            this.saveUsernameButton.Size = new System.Drawing.Size(75, 23);
            this.saveUsernameButton.TabIndex = 4;
            this.saveUsernameButton.Text = "Save";
            this.saveUsernameButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.SavePasswordButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.PasswordAgainBox);
            this.groupBox2.Controls.Add(this.NewPasswordBox);
            this.groupBox2.Location = new System.Drawing.Point(5, 135);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(526, 158);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change password";
            // 
            // SavePasswordButton
            // 
            this.SavePasswordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SavePasswordButton.Enabled = false;
            this.SavePasswordButton.Location = new System.Drawing.Point(439, 124);
            this.SavePasswordButton.Margin = new System.Windows.Forms.Padding(2);
            this.SavePasswordButton.Name = "SavePasswordButton";
            this.SavePasswordButton.Size = new System.Drawing.Size(75, 23);
            this.SavePasswordButton.TabIndex = 2;
            this.SavePasswordButton.Text = "Save";
            this.SavePasswordButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "The new password again";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "New password";
            // 
            // PasswordAgainBox
            // 
            this.PasswordAgainBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordAgainBox.Enabled = false;
            this.PasswordAgainBox.Location = new System.Drawing.Point(14, 89);
            this.PasswordAgainBox.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordAgainBox.Name = "PasswordAgainBox";
            this.PasswordAgainBox.Size = new System.Drawing.Size(500, 23);
            this.PasswordAgainBox.TabIndex = 1;
            this.PasswordAgainBox.UseSystemPasswordChar = true;
            // 
            // NewPasswordBox
            // 
            this.NewPasswordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewPasswordBox.Enabled = false;
            this.NewPasswordBox.Location = new System.Drawing.Point(14, 41);
            this.NewPasswordBox.Margin = new System.Windows.Forms.Padding(2);
            this.NewPasswordBox.Name = "NewPasswordBox";
            this.NewPasswordBox.Size = new System.Drawing.Size(500, 23);
            this.NewPasswordBox.TabIndex = 0;
            this.NewPasswordBox.UseSystemPasswordChar = true;
            // 
            // UsernameBox
            // 
            this.UsernameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameBox.CausesValidation = false;
            this.UsernameBox.Enabled = false;
            this.UsernameBox.Location = new System.Drawing.Point(19, 44);
            this.UsernameBox.Margin = new System.Windows.Forms.Padding(2);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(500, 23);
            this.UsernameBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Username";
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "UserManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Management";
            this.Load += new System.EventHandler(this.UserManagementForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView1;
        private ColumnHeader name;
        private Panel panel1;
        private Button DeleteButton;
        private Button AddButton;
        private GroupBox groupBox1;
        private Label label2;
        private Button UserSettingsButton;
        private Button saveUsernameButton;
        private GroupBox groupBox2;
        private Button SavePasswordButton;
        private Label label3;
        private Label label1;
        private TextBox PasswordAgainBox;
        private TextBox NewPasswordBox;
        private TextBox UsernameBox;
        private Label label4;
    }
}