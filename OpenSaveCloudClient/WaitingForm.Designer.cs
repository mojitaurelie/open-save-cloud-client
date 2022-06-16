namespace OpenSaveCloudClient
{
    partial class WaitingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.LoadingIndicator = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(103, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sorry but some tasks are in progress\r\nBe sure to wait for the tasks to be complet" +
    "ed...\r\n";
            // 
            // LoadingIndicator
            // 
            this.LoadingIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadingIndicator.Image = ((System.Drawing.Image)(resources.GetObject("LoadingIndicator.Image")));
            this.LoadingIndicator.Location = new System.Drawing.Point(12, 27);
            this.LoadingIndicator.Name = "LoadingIndicator";
            this.LoadingIndicator.Size = new System.Drawing.Size(80, 82);
            this.LoadingIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadingIndicator.TabIndex = 8;
            this.LoadingIndicator.TabStop = false;
            // 
            // WaitingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(528, 136);
            this.Controls.Add(this.LoadingIndicator);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(528, 136);
            this.MinimumSize = new System.Drawing.Size(528, 136);
            this.Name = "WaitingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WaitingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaitingForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private PictureBox LoadingIndicator;
        private System.Windows.Forms.Timer timer1;
    }
}