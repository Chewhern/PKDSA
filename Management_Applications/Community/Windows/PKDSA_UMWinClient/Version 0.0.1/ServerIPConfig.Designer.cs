namespace PKDSA_UMWinClient
{
    partial class ServerIPConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.IPTB = new System.Windows.Forms.TextBox();
            this.SetIPBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.StatusTB = new System.Windows.Forms.TextBox();
            this.CheckOnlineStatusBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "What\'s the server IP address that provides\r\nPublic Key Digital Signature as a\r\npa" +
    "sswordless authentication?";
            // 
            // IPTB
            // 
            this.IPTB.Location = new System.Drawing.Point(12, 72);
            this.IPTB.Multiline = true;
            this.IPTB.Name = "IPTB";
            this.IPTB.Size = new System.Drawing.Size(283, 91);
            this.IPTB.TabIndex = 1;
            // 
            // SetIPBTN
            // 
            this.SetIPBTN.Location = new System.Drawing.Point(12, 175);
            this.SetIPBTN.Name = "SetIPBTN";
            this.SetIPBTN.Size = new System.Drawing.Size(283, 56);
            this.SetIPBTN.TabIndex = 2;
            this.SetIPBTN.Text = "Add/Update Server IP Address";
            this.SetIPBTN.UseVisualStyleBackColor = true;
            this.SetIPBTN.Click += new System.EventHandler(this.SetIPBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(514, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "The online status of the server";
            // 
            // StatusTB
            // 
            this.StatusTB.Location = new System.Drawing.Point(514, 32);
            this.StatusTB.Multiline = true;
            this.StatusTB.Name = "StatusTB";
            this.StatusTB.ReadOnly = true;
            this.StatusTB.Size = new System.Drawing.Size(215, 131);
            this.StatusTB.TabIndex = 4;
            // 
            // CheckOnlineStatusBTN
            // 
            this.CheckOnlineStatusBTN.Location = new System.Drawing.Point(514, 175);
            this.CheckOnlineStatusBTN.Name = "CheckOnlineStatusBTN";
            this.CheckOnlineStatusBTN.Size = new System.Drawing.Size(215, 51);
            this.CheckOnlineStatusBTN.TabIndex = 5;
            this.CheckOnlineStatusBTN.Text = "Check Server Online Status";
            this.CheckOnlineStatusBTN.UseVisualStyleBackColor = true;
            this.CheckOnlineStatusBTN.Click += new System.EventHandler(this.CheckOnlineStatusBTN_Click);
            // 
            // ServerIPConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CheckOnlineStatusBTN);
            this.Controls.Add(this.StatusTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SetIPBTN);
            this.Controls.Add(this.IPTB);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ServerIPConfig";
            this.Text = "Server IP Configuration Or Checking";
            this.Load += new System.EventHandler(this.ServerIPConfig_Load);
            this.FormClosing += new FormClosingEventHandler(OnFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox IPTB;
        private Button SetIPBTN;
        private Label label2;
        private TextBox StatusTB;
        private Button CheckOnlineStatusBTN;
    }
}