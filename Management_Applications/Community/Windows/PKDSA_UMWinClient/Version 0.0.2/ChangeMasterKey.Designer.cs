namespace PKDSA_UMWinClient
{
    partial class ChangeMasterKey
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
            this.SubmitInfoBTN = new System.Windows.Forms.Button();
            this.ChangeKeysStatusTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GenerateKeysBTN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Curve448RB = new System.Windows.Forms.RadioButton();
            this.Curve25519RB = new System.Windows.Forms.RadioButton();
            this.SignedPublicKeyTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PublicKeyTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UserIDTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubmitInfoBTN
            // 
            this.SubmitInfoBTN.Location = new System.Drawing.Point(455, 158);
            this.SubmitInfoBTN.Name = "SubmitInfoBTN";
            this.SubmitInfoBTN.Size = new System.Drawing.Size(267, 56);
            this.SubmitInfoBTN.TabIndex = 23;
            this.SubmitInfoBTN.Text = "Submit Information to Server";
            this.SubmitInfoBTN.UseVisualStyleBackColor = true;
            this.SubmitInfoBTN.Click += new System.EventHandler(this.SubmitInfoBTN_Click);
            // 
            // ChangeKeysStatusTB
            // 
            this.ChangeKeysStatusTB.Location = new System.Drawing.Point(455, 29);
            this.ChangeKeysStatusTB.Multiline = true;
            this.ChangeKeysStatusTB.Name = "ChangeKeysStatusTB";
            this.ChangeKeysStatusTB.ReadOnly = true;
            this.ChangeKeysStatusTB.Size = new System.Drawing.Size(267, 114);
            this.ChangeKeysStatusTB.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Change Keys on server\'s status";
            // 
            // GenerateKeysBTN
            // 
            this.GenerateKeysBTN.Location = new System.Drawing.Point(12, 410);
            this.GenerateKeysBTN.Name = "GenerateKeysBTN";
            this.GenerateKeysBTN.Size = new System.Drawing.Size(305, 64);
            this.GenerateKeysBTN.TabIndex = 20;
            this.GenerateKeysBTN.Text = "Generate Keys Locally";
            this.GenerateKeysBTN.UseVisualStyleBackColor = true;
            this.GenerateKeysBTN.Click += new System.EventHandler(this.GenerateKeysBTN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Curve448RB);
            this.groupBox1.Controls.Add(this.Curve25519RB);
            this.groupBox1.Location = new System.Drawing.Point(12, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 100);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose a key type";
            // 
            // Curve448RB
            // 
            this.Curve448RB.AutoSize = true;
            this.Curve448RB.Location = new System.Drawing.Point(6, 56);
            this.Curve448RB.Name = "Curve448RB";
            this.Curve448RB.Size = new System.Drawing.Size(224, 24);
            this.Curve448RB.TabIndex = 1;
            this.Curve448RB.Text = "Curve448 (Stability Unknown)";
            this.Curve448RB.UseVisualStyleBackColor = true;
            // 
            // Curve25519RB
            // 
            this.Curve25519RB.AutoSize = true;
            this.Curve25519RB.Checked = true;
            this.Curve25519RB.Location = new System.Drawing.Point(6, 26);
            this.Curve25519RB.Name = "Curve25519RB";
            this.Curve25519RB.Size = new System.Drawing.Size(163, 24);
            this.Curve25519RB.TabIndex = 0;
            this.Curve25519RB.TabStop = true;
            this.Curve25519RB.Text = "Curve25519 (Stable)";
            this.Curve25519RB.UseVisualStyleBackColor = true;
            // 
            // SignedPublicKeyTB
            // 
            this.SignedPublicKeyTB.Location = new System.Drawing.Point(12, 210);
            this.SignedPublicKeyTB.Multiline = true;
            this.SignedPublicKeyTB.Name = "SignedPublicKeyTB";
            this.SignedPublicKeyTB.ReadOnly = true;
            this.SignedPublicKeyTB.Size = new System.Drawing.Size(305, 74);
            this.SignedPublicKeyTB.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Randomly Generated Signed Public Key (B64)";
            // 
            // PublicKeyTB
            // 
            this.PublicKeyTB.Location = new System.Drawing.Point(12, 112);
            this.PublicKeyTB.Multiline = true;
            this.PublicKeyTB.Name = "PublicKeyTB";
            this.PublicKeyTB.ReadOnly = true;
            this.PublicKeyTB.Size = new System.Drawing.Size(305, 68);
            this.PublicKeyTB.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Randomly Generated Public Key (B64)";
            // 
            // UserIDTB
            // 
            this.UserIDTB.Location = new System.Drawing.Point(12, 29);
            this.UserIDTB.Multiline = true;
            this.UserIDTB.Name = "UserIDTB";
            this.UserIDTB.ReadOnly = true;
            this.UserIDTB.Size = new System.Drawing.Size(305, 55);
            this.UserIDTB.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Randomly Generated User ID";
            // 
            // ChangeMasterKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 532);
            this.Controls.Add(this.SubmitInfoBTN);
            this.Controls.Add(this.ChangeKeysStatusTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GenerateKeysBTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SignedPublicKeyTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PublicKeyTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserIDTB);
            this.Controls.Add(this.label1);
            this.Name = "ChangeMasterKey";
            this.Text = "ChangeMasterKey";
            this.FormClosing += new FormClosingEventHandler(OnFormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SubmitInfoBTN;
        private TextBox ChangeKeysStatusTB;
        private Label label4;
        private Button GenerateKeysBTN;
        private GroupBox groupBox1;
        private RadioButton Curve448RB;
        private RadioButton Curve25519RB;
        private TextBox SignedPublicKeyTB;
        private Label label3;
        private TextBox PublicKeyTB;
        private Label label2;
        private TextBox UserIDTB;
        private Label label1;
    }
}