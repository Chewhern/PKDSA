namespace PKDSA_UMWinClient
{
    partial class LoginUsingSubKeys
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
            this.StatusTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SubKeyIdentifierTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UserIDTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UserSignedChallengeTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerChallengeTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RequestChallengeBTN = new System.Windows.Forms.Button();
            this.LoginBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StatusTB
            // 
            this.StatusTB.Location = new System.Drawing.Point(393, 141);
            this.StatusTB.Multiline = true;
            this.StatusTB.Name = "StatusTB";
            this.StatusTB.ReadOnly = true;
            this.StatusTB.Size = new System.Drawing.Size(250, 69);
            this.StatusTB.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Status";
            // 
            // SubKeyIdentifierTB
            // 
            this.SubKeyIdentifierTB.Location = new System.Drawing.Point(12, 141);
            this.SubKeyIdentifierTB.Multiline = true;
            this.SubKeyIdentifierTB.Name = "SubKeyIdentifierTB";
            this.SubKeyIdentifierTB.Size = new System.Drawing.Size(250, 69);
            this.SubKeyIdentifierTB.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Sub Key Identifier";
            // 
            // UserIDTB
            // 
            this.UserIDTB.Location = new System.Drawing.Point(12, 34);
            this.UserIDTB.Multiline = true;
            this.UserIDTB.Name = "UserIDTB";
            this.UserIDTB.ReadOnly = true;
            this.UserIDTB.Size = new System.Drawing.Size(250, 69);
            this.UserIDTB.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Your User ID";
            // 
            // UserSignedChallengeTB
            // 
            this.UserSignedChallengeTB.Location = new System.Drawing.Point(393, 34);
            this.UserSignedChallengeTB.Multiline = true;
            this.UserSignedChallengeTB.Name = "UserSignedChallengeTB";
            this.UserSignedChallengeTB.Size = new System.Drawing.Size(250, 69);
            this.UserSignedChallengeTB.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "User Signed Challenge";
            // 
            // ServerChallengeTB
            // 
            this.ServerChallengeTB.Location = new System.Drawing.Point(12, 251);
            this.ServerChallengeTB.Multiline = true;
            this.ServerChallengeTB.Name = "ServerChallengeTB";
            this.ServerChallengeTB.ReadOnly = true;
            this.ServerChallengeTB.Size = new System.Drawing.Size(250, 69);
            this.ServerChallengeTB.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Server\'s Challenge";
            // 
            // RequestChallengeBTN
            // 
            this.RequestChallengeBTN.Location = new System.Drawing.Point(12, 330);
            this.RequestChallengeBTN.Name = "RequestChallengeBTN";
            this.RequestChallengeBTN.Size = new System.Drawing.Size(250, 64);
            this.RequestChallengeBTN.TabIndex = 33;
            this.RequestChallengeBTN.Text = "Request Challenge";
            this.RequestChallengeBTN.UseVisualStyleBackColor = true;
            this.RequestChallengeBTN.Click += new System.EventHandler(this.RequestChallengeBTN_Click);
            // 
            // LoginBTN
            // 
            this.LoginBTN.Location = new System.Drawing.Point(393, 228);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Size = new System.Drawing.Size(250, 64);
            this.LoginBTN.TabIndex = 34;
            this.LoginBTN.Text = "Login using sub keys";
            this.LoginBTN.UseVisualStyleBackColor = true;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            // 
            // LoginUsingSubKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 556);
            this.Controls.Add(this.LoginBTN);
            this.Controls.Add(this.RequestChallengeBTN);
            this.Controls.Add(this.ServerChallengeTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UserSignedChallengeTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StatusTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SubKeyIdentifierTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserIDTB);
            this.Controls.Add(this.label5);
            this.Name = "LoginUsingSubKeys";
            this.Text = "LoginUsingSubKeys";
            this.FormClosing += new FormClosingEventHandler(OnFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox StatusTB;
        private Label label1;
        private TextBox SubKeyIdentifierTB;
        private Label label2;
        private TextBox UserIDTB;
        private Label label5;
        private TextBox UserSignedChallengeTB;
        private Label label3;
        private TextBox ServerChallengeTB;
        private Label label4;
        private Button RequestChallengeBTN;
        private Button LoginBTN;
    }
}