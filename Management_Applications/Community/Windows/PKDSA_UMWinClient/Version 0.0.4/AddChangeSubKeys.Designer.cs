namespace PKDSA_UMWinClient
{
    partial class AddChangeSubKeys
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
            this.SignedPublicKeyTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PublicKeyTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChangeRB = new System.Windows.Forms.RadioButton();
            this.AddRB = new System.Windows.Forms.RadioButton();
            this.StatusTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SubKeyIdentifierTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UserIDTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ActionBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SignedPublicKeyTB
            // 
            this.SignedPublicKeyTB.Location = new System.Drawing.Point(347, 141);
            this.SignedPublicKeyTB.Multiline = true;
            this.SignedPublicKeyTB.Name = "SignedPublicKeyTB";
            this.SignedPublicKeyTB.Size = new System.Drawing.Size(274, 67);
            this.SignedPublicKeyTB.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Corresponding Signed Public Key (B64)";
            // 
            // PublicKeyTB
            // 
            this.PublicKeyTB.Location = new System.Drawing.Point(347, 34);
            this.PublicKeyTB.Multiline = true;
            this.PublicKeyTB.Name = "PublicKeyTB";
            this.PublicKeyTB.Size = new System.Drawing.Size(274, 67);
            this.PublicKeyTB.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Corresponding Public Key (B64)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChangeRB);
            this.groupBox1.Controls.Add(this.AddRB);
            this.groupBox1.Location = new System.Drawing.Point(12, 333);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 96);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Or Change Sub Key?";
            // 
            // ChangeRB
            // 
            this.ChangeRB.AutoSize = true;
            this.ChangeRB.Location = new System.Drawing.Point(9, 56);
            this.ChangeRB.Name = "ChangeRB";
            this.ChangeRB.Size = new System.Drawing.Size(137, 24);
            this.ChangeRB.TabIndex = 1;
            this.ChangeRB.TabStop = true;
            this.ChangeRB.Text = "Change Sub Key";
            this.ChangeRB.UseVisualStyleBackColor = true;
            // 
            // AddRB
            // 
            this.AddRB.AutoSize = true;
            this.AddRB.Checked = true;
            this.AddRB.Location = new System.Drawing.Point(9, 26);
            this.AddRB.Name = "AddRB";
            this.AddRB.Size = new System.Drawing.Size(115, 24);
            this.AddRB.TabIndex = 0;
            this.AddRB.TabStop = true;
            this.AddRB.Text = "Add Sub Key";
            this.AddRB.UseVisualStyleBackColor = true;
            // 
            // StatusTB
            // 
            this.StatusTB.Location = new System.Drawing.Point(12, 249);
            this.StatusTB.Multiline = true;
            this.StatusTB.Name = "StatusTB";
            this.StatusTB.ReadOnly = true;
            this.StatusTB.Size = new System.Drawing.Size(250, 69);
            this.StatusTB.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Status";
            // 
            // SubKeyIdentifierTB
            // 
            this.SubKeyIdentifierTB.Location = new System.Drawing.Point(12, 141);
            this.SubKeyIdentifierTB.Multiline = true;
            this.SubKeyIdentifierTB.Name = "SubKeyIdentifierTB";
            this.SubKeyIdentifierTB.Size = new System.Drawing.Size(250, 69);
            this.SubKeyIdentifierTB.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Sub Key Identifier";
            // 
            // UserIDTB
            // 
            this.UserIDTB.Location = new System.Drawing.Point(12, 34);
            this.UserIDTB.Multiline = true;
            this.UserIDTB.Name = "UserIDTB";
            this.UserIDTB.ReadOnly = true;
            this.UserIDTB.Size = new System.Drawing.Size(250, 69);
            this.UserIDTB.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Your User ID";
            // 
            // ActionBTN
            // 
            this.ActionBTN.Location = new System.Drawing.Point(347, 226);
            this.ActionBTN.Name = "ActionBTN";
            this.ActionBTN.Size = new System.Drawing.Size(274, 50);
            this.ActionBTN.TabIndex = 18;
            this.ActionBTN.Text = "Add Or Change Sub Keys";
            this.ActionBTN.UseVisualStyleBackColor = true;
            this.ActionBTN.Click += new System.EventHandler(this.ActionBTN_Click);
            // 
            // AddChangeSubKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 578);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StatusTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SubKeyIdentifierTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserIDTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ActionBTN);
            this.Controls.Add(this.SignedPublicKeyTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PublicKeyTB);
            this.Controls.Add(this.label3);
            this.Name = "AddChangeSubKeys";
            this.Text = "AddRemoveSubKeys";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox SignedPublicKeyTB;
        private Label label4;
        private TextBox PublicKeyTB;
        private Label label3;
        private GroupBox groupBox1;
        private RadioButton ChangeRB;
        private RadioButton AddRB;
        private TextBox StatusTB;
        private Label label1;
        private TextBox SubKeyIdentifierTB;
        private Label label2;
        private TextBox UserIDTB;
        private Label label5;
        private Button ActionBTN;
    }
}