namespace PKDSA_WinClient
{
    partial class CreateSignatureKeyPair
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Curve448RB = new System.Windows.Forms.RadioButton();
            this.Curve25519RB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.KeyPairFolderNameTB = new System.Windows.Forms.TextBox();
            this.CreateBTN = new System.Windows.Forms.Button();
            this.KeyPairFolderNameCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PublicKeyTB = new System.Windows.Forms.TextBox();
            this.SignedPublicKeyTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RefreshBTN = new System.Windows.Forms.Button();
            this.ViewBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Curve448RB);
            this.groupBox1.Controls.Add(this.Curve25519RB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose a digital signature algorithm";
            // 
            // Curve448RB
            // 
            this.Curve448RB.AutoSize = true;
            this.Curve448RB.Location = new System.Drawing.Point(6, 56);
            this.Curve448RB.Name = "Curve448RB";
            this.Curve448RB.Size = new System.Drawing.Size(249, 24);
            this.Curve448RB.TabIndex = 1;
            this.Curve448RB.Text = "Curve448 - ED448 (Experimental)";
            this.Curve448RB.UseVisualStyleBackColor = true;
            // 
            // Curve25519RB
            // 
            this.Curve25519RB.AutoSize = true;
            this.Curve25519RB.Checked = true;
            this.Curve25519RB.Location = new System.Drawing.Point(6, 26);
            this.Curve25519RB.Name = "Curve25519RB";
            this.Curve25519RB.Size = new System.Drawing.Size(236, 24);
            this.Curve25519RB.TabIndex = 0;
            this.Curve25519RB.TabStop = true;
            this.Curve25519RB.Text = "Curve25519 - ED25519 (Stable)";
            this.Curve25519RB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key Pair Folder Name";
            // 
            // KeyPairFolderNameTB
            // 
            this.KeyPairFolderNameTB.Location = new System.Drawing.Point(11, 142);
            this.KeyPairFolderNameTB.Name = "KeyPairFolderNameTB";
            this.KeyPairFolderNameTB.Size = new System.Drawing.Size(266, 27);
            this.KeyPairFolderNameTB.TabIndex = 2;
            // 
            // CreateBTN
            // 
            this.CreateBTN.Location = new System.Drawing.Point(12, 179);
            this.CreateBTN.Name = "CreateBTN";
            this.CreateBTN.Size = new System.Drawing.Size(265, 48);
            this.CreateBTN.TabIndex = 3;
            this.CreateBTN.Text = "Create KeyPair";
            this.CreateBTN.UseVisualStyleBackColor = true;
            this.CreateBTN.Click += new System.EventHandler(this.CreateBTN_Click);
            // 
            // KeyPairFolderNameCB
            // 
            this.KeyPairFolderNameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyPairFolderNameCB.FormattingEnabled = true;
            this.KeyPairFolderNameCB.Location = new System.Drawing.Point(461, 38);
            this.KeyPairFolderNameCB.Name = "KeyPairFolderNameCB";
            this.KeyPairFolderNameCB.Size = new System.Drawing.Size(274, 28);
            this.KeyPairFolderNameCB.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select a key pair folder name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Corresponding Public Key (B64)";
            // 
            // PublicKeyTB
            // 
            this.PublicKeyTB.Location = new System.Drawing.Point(461, 112);
            this.PublicKeyTB.Multiline = true;
            this.PublicKeyTB.Name = "PublicKeyTB";
            this.PublicKeyTB.ReadOnly = true;
            this.PublicKeyTB.Size = new System.Drawing.Size(274, 67);
            this.PublicKeyTB.TabIndex = 7;
            // 
            // SignedPublicKeyTB
            // 
            this.SignedPublicKeyTB.Location = new System.Drawing.Point(461, 234);
            this.SignedPublicKeyTB.Multiline = true;
            this.SignedPublicKeyTB.Name = "SignedPublicKeyTB";
            this.SignedPublicKeyTB.ReadOnly = true;
            this.SignedPublicKeyTB.Size = new System.Drawing.Size(274, 67);
            this.SignedPublicKeyTB.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Corresponding Signed Public Key (B64)";
            // 
            // RefreshBTN
            // 
            this.RefreshBTN.Location = new System.Drawing.Point(14, 240);
            this.RefreshBTN.Name = "RefreshBTN";
            this.RefreshBTN.Size = new System.Drawing.Size(263, 50);
            this.RefreshBTN.TabIndex = 10;
            this.RefreshBTN.Text = "Refresh";
            this.RefreshBTN.UseVisualStyleBackColor = true;
            this.RefreshBTN.Click += new System.EventHandler(this.RefreshBTN_Click);
            // 
            // ViewBTN
            // 
            this.ViewBTN.Location = new System.Drawing.Point(461, 318);
            this.ViewBTN.Name = "ViewBTN";
            this.ViewBTN.Size = new System.Drawing.Size(274, 50);
            this.ViewBTN.TabIndex = 11;
            this.ViewBTN.Text = "View Public Keys";
            this.ViewBTN.UseVisualStyleBackColor = true;
            this.ViewBTN.Click += new System.EventHandler(this.ViewBTN_Click);
            // 
            // CreateSignatureKeyPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ViewBTN);
            this.Controls.Add(this.RefreshBTN);
            this.Controls.Add(this.SignedPublicKeyTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PublicKeyTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KeyPairFolderNameCB);
            this.Controls.Add(this.CreateBTN);
            this.Controls.Add(this.KeyPairFolderNameTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "CreateSignatureKeyPair";
            this.Text = "Create Public Key Digital Signature Key Pair/View Public Keys";
            this.Load += new System.EventHandler(this.CreateSignatureKeyPair_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton Curve448RB;
        private RadioButton Curve25519RB;
        private Label label1;
        private TextBox KeyPairFolderNameTB;
        private Button CreateBTN;
        private ComboBox KeyPairFolderNameCB;
        private Label label2;
        private Label label3;
        private TextBox PublicKeyTB;
        private TextBox SignedPublicKeyTB;
        private Label label4;
        private Button RefreshBTN;
        private Button ViewBTN;
    }
}