namespace PKDSA_WinClient
{
    partial class SignChallenge
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
            this.ChallengeTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.KeyPairFolderNameCB = new System.Windows.Forms.ComboBox();
            this.RefreshBTN = new System.Windows.Forms.Button();
            this.SignBTN = new System.Windows.Forms.Button();
            this.SignedChallengeTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CurveTypeTB = new System.Windows.Forms.TextBox();
            this.KeyPairFolderNameTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Challenge From Provider (B64)";
            // 
            // ChallengeTB
            // 
            this.ChallengeTB.Location = new System.Drawing.Point(11, 33);
            this.ChallengeTB.Multiline = true;
            this.ChallengeTB.Name = "ChallengeTB";
            this.ChallengeTB.Size = new System.Drawing.Size(225, 97);
            this.ChallengeTB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select a key pair folder name";
            // 
            // KeyPairFolderNameCB
            // 
            this.KeyPairFolderNameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyPairFolderNameCB.FormattingEnabled = true;
            this.KeyPairFolderNameCB.Location = new System.Drawing.Point(11, 174);
            this.KeyPairFolderNameCB.Name = "KeyPairFolderNameCB";
            this.KeyPairFolderNameCB.Size = new System.Drawing.Size(274, 28);
            this.KeyPairFolderNameCB.TabIndex = 6;
            this.KeyPairFolderNameCB.SelectedIndexChanged += new System.EventHandler(this.KeyPairFolderNameCB_SelectedIndexChanged);
            // 
            // RefreshBTN
            // 
            this.RefreshBTN.Location = new System.Drawing.Point(11, 412);
            this.RefreshBTN.Name = "RefreshBTN";
            this.RefreshBTN.Size = new System.Drawing.Size(225, 50);
            this.RefreshBTN.TabIndex = 11;
            this.RefreshBTN.Text = "Refresh";
            this.RefreshBTN.UseVisualStyleBackColor = true;
            this.RefreshBTN.Click += new System.EventHandler(this.RefreshBTN_Click);
            // 
            // SignBTN
            // 
            this.SignBTN.Location = new System.Drawing.Point(11, 341);
            this.SignBTN.Name = "SignBTN";
            this.SignBTN.Size = new System.Drawing.Size(224, 49);
            this.SignBTN.TabIndex = 12;
            this.SignBTN.Text = "Sign Challenge";
            this.SignBTN.UseVisualStyleBackColor = true;
            this.SignBTN.Click += new System.EventHandler(this.SignBTN_Click);
            // 
            // SignedChallengeTB
            // 
            this.SignedChallengeTB.Location = new System.Drawing.Point(527, 33);
            this.SignedChallengeTB.Multiline = true;
            this.SignedChallengeTB.Name = "SignedChallengeTB";
            this.SignedChallengeTB.ReadOnly = true;
            this.SignedChallengeTB.Size = new System.Drawing.Size(225, 97);
            this.SignedChallengeTB.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(527, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Signed Challenge (B64)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Key Pair\'s Curve Type";
            // 
            // CurveTypeTB
            // 
            this.CurveTypeTB.Location = new System.Drawing.Point(528, 166);
            this.CurveTypeTB.Name = "CurveTypeTB";
            this.CurveTypeTB.ReadOnly = true;
            this.CurveTypeTB.Size = new System.Drawing.Size(224, 27);
            this.CurveTypeTB.TabIndex = 16;
            // 
            // KeyPairFolderNameTB
            // 
            this.KeyPairFolderNameTB.Location = new System.Drawing.Point(10, 254);
            this.KeyPairFolderNameTB.Multiline = true;
            this.KeyPairFolderNameTB.Name = "KeyPairFolderNameTB";
            this.KeyPairFolderNameTB.ReadOnly = true;
            this.KeyPairFolderNameTB.Size = new System.Drawing.Size(225, 72);
            this.KeyPairFolderNameTB.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Key Pair Folder Name";
            // 
            // SignChallenge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.KeyPairFolderNameTB);
            this.Controls.Add(this.CurveTypeTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SignedChallengeTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SignBTN);
            this.Controls.Add(this.RefreshBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KeyPairFolderNameCB);
            this.Controls.Add(this.ChallengeTB);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "SignChallenge";
            this.Text = "Signing Challenge From Provider";
            this.Load += new System.EventHandler(this.SignChallenge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox ChallengeTB;
        private Label label2;
        private ComboBox KeyPairFolderNameCB;
        private Button RefreshBTN;
        private Button SignBTN;
        private TextBox SignedChallengeTB;
        private Label label3;
        private Label label4;
        private TextBox CurveTypeTB;
        private TextBox KeyPairFolderNameTB;
        private Label label5;
    }
}