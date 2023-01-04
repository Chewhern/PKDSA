namespace PKDSA_WinClient
{
    partial class DeleteSignatureKeyPair
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
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Select a key pair folder name";
            // 
            // KeyPairFolderNameCB
            // 
            this.KeyPairFolderNameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyPairFolderNameCB.FormattingEnabled = true;
            this.KeyPairFolderNameCB.Location = new System.Drawing.Point(12, 40);
            this.KeyPairFolderNameCB.Name = "KeyPairFolderNameCB";
            this.KeyPairFolderNameCB.Size = new System.Drawing.Size(274, 28);
            this.KeyPairFolderNameCB.TabIndex = 13;
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Location = new System.Drawing.Point(12, 97);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(265, 48);
            this.DeleteBTN.TabIndex = 12;
            this.DeleteBTN.Text = "Delete Key Pair";
            this.DeleteBTN.UseVisualStyleBackColor = true;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // DeleteSignatureKeyPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KeyPairFolderNameCB);
            this.Controls.Add(this.DeleteBTN);
            this.MaximizeBox = false;
            this.Name = "DeleteSignatureKeyPair";
            this.Text = "Delete Signature Key Pair";
            this.Load += new System.EventHandler(this.DeleteSignatureKeyPair_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private ComboBox KeyPairFolderNameCB;
        private Button DeleteBTN;
    }
}