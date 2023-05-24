namespace PKDSA_UMWinClient
{
    partial class TOREnablingDisabling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TOREnablingDisabling));
            this.DownloadBTN = new System.Windows.Forms.Button();
            this.StartTORBTN = new System.Windows.Forms.Button();
            this.StopTORBTN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DownloadBTN
            // 
            this.DownloadBTN.Location = new System.Drawing.Point(306, 176);
            this.DownloadBTN.Name = "DownloadBTN";
            this.DownloadBTN.Size = new System.Drawing.Size(260, 58);
            this.DownloadBTN.TabIndex = 6;
            this.DownloadBTN.Text = "1. Download TOR";
            this.DownloadBTN.UseVisualStyleBackColor = true;
            this.DownloadBTN.Click += new System.EventHandler(this.DownloadBTN_Click);
            // 
            // StartTORBTN
            // 
            this.StartTORBTN.Location = new System.Drawing.Point(306, 254);
            this.StartTORBTN.Name = "StartTORBTN";
            this.StartTORBTN.Size = new System.Drawing.Size(257, 54);
            this.StartTORBTN.TabIndex = 7;
            this.StartTORBTN.Text = "2. Start TOR";
            this.StartTORBTN.UseVisualStyleBackColor = true;
            this.StartTORBTN.Click += new System.EventHandler(this.StartTORBTN_Click);
            // 
            // StopTORBTN
            // 
            this.StopTORBTN.Location = new System.Drawing.Point(306, 330);
            this.StopTORBTN.Name = "StopTORBTN";
            this.StopTORBTN.Size = new System.Drawing.Size(257, 54);
            this.StopTORBTN.TabIndex = 8;
            this.StopTORBTN.Text = "3. Stop TOR";
            this.StopTORBTN.UseVisualStyleBackColor = true;
            this.StopTORBTN.Click += new System.EventHandler(this.StopTORBTN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 480);
            this.label4.TabIndex = 9;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(614, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 500);
            this.label5.TabIndex = 10;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // TOREnablingDisabling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 565);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StopTORBTN);
            this.Controls.Add(this.StartTORBTN);
            this.Controls.Add(this.DownloadBTN);
            this.Name = "TOREnablingDisabling";
            this.Text = "TOR Download,Install,Enable,Disable";
            this.FormClosing += new FormClosingEventHandler(OnFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button DownloadBTN;
        private Button StartTORBTN;
        private Button StopTORBTN;
        private Label label4;
        private Label label5;
    }
}