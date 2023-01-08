namespace PKDSA_WinClient
{
    partial class ChangeSignatureKeyPair
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
            this.label2 = new System.Windows.Forms.Label();
            this.KeyPairFolderNameCB = new System.Windows.Forms.ComboBox();
            this.Curve448RB = new System.Windows.Forms.RadioButton();
            this.Curve25519RB = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChangeKeyBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select a key pair folder name";
            // 
            // KeyPairFolderNameCB
            // 
            this.KeyPairFolderNameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyPairFolderNameCB.FormattingEnabled = true;
            this.KeyPairFolderNameCB.Location = new System.Drawing.Point(12, 36);
            this.KeyPairFolderNameCB.Name = "KeyPairFolderNameCB";
            this.KeyPairFolderNameCB.Size = new System.Drawing.Size(274, 28);
            this.KeyPairFolderNameCB.TabIndex = 6;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Curve448RB);
            this.groupBox1.Controls.Add(this.Curve25519RB);
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 97);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose a digital signature algorithm";
            // 
            // ChangeKeyBTN
            // 
            this.ChangeKeyBTN.Location = new System.Drawing.Point(13, 185);
            this.ChangeKeyBTN.Name = "ChangeKeyBTN";
            this.ChangeKeyBTN.Size = new System.Drawing.Size(273, 57);
            this.ChangeKeyBTN.TabIndex = 9;
            this.ChangeKeyBTN.Text = "Change Keys";
            this.ChangeKeyBTN.UseVisualStyleBackColor = true;
            this.ChangeKeyBTN.Click += new System.EventHandler(this.ChangeKeyBTN_Click);
            // 
            // ChangeSignatureKeyPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChangeKeyBTN);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KeyPairFolderNameCB);
            this.Name = "ChangeSignatureKeyPair";
            this.Text = "ChangeSignatureKeyPair";
            this.Load += new System.EventHandler(this.ChangeSignatureKeyPair_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private ComboBox KeyPairFolderNameCB;
        private RadioButton Curve448RB;
        private RadioButton Curve25519RB;
        private GroupBox groupBox1;
        private Button ChangeKeyBTN;
    }
}