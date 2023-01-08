namespace PKDSA_UMWinClient
{
    partial class AddRemoveSubKeyIdentifiers
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
            this.UserIDTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SubKeyIdentifierTB = new System.Windows.Forms.TextBox();
            this.ActionBTN = new System.Windows.Forms.Button();
            this.StatusTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddRB = new System.Windows.Forms.RadioButton();
            this.RemoveRB = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your User ID";
            // 
            // UserIDTB
            // 
            this.UserIDTB.Location = new System.Drawing.Point(273, 31);
            this.UserIDTB.Multiline = true;
            this.UserIDTB.Name = "UserIDTB";
            this.UserIDTB.ReadOnly = true;
            this.UserIDTB.Size = new System.Drawing.Size(250, 69);
            this.UserIDTB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sub Key Identifier";
            // 
            // SubKeyIdentifierTB
            // 
            this.SubKeyIdentifierTB.Location = new System.Drawing.Point(273, 138);
            this.SubKeyIdentifierTB.Multiline = true;
            this.SubKeyIdentifierTB.Name = "SubKeyIdentifierTB";
            this.SubKeyIdentifierTB.Size = new System.Drawing.Size(250, 69);
            this.SubKeyIdentifierTB.TabIndex = 3;
            // 
            // ActionBTN
            // 
            this.ActionBTN.Location = new System.Drawing.Point(273, 441);
            this.ActionBTN.Name = "ActionBTN";
            this.ActionBTN.Size = new System.Drawing.Size(250, 50);
            this.ActionBTN.TabIndex = 4;
            this.ActionBTN.Text = "Add Or Remove Key Identifier";
            this.ActionBTN.UseVisualStyleBackColor = true;
            this.ActionBTN.Click += new System.EventHandler(this.ActionBTN_Click);
            // 
            // StatusTB
            // 
            this.StatusTB.Location = new System.Drawing.Point(273, 246);
            this.StatusTB.Multiline = true;
            this.StatusTB.Name = "StatusTB";
            this.StatusTB.ReadOnly = true;
            this.StatusTB.Size = new System.Drawing.Size(250, 69);
            this.StatusTB.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RemoveRB);
            this.groupBox1.Controls.Add(this.AddRB);
            this.groupBox1.Location = new System.Drawing.Point(273, 330);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 96);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Or Remove Key Identifier?";
            // 
            // AddRB
            // 
            this.AddRB.AutoSize = true;
            this.AddRB.Checked = true;
            this.AddRB.Location = new System.Drawing.Point(9, 26);
            this.AddRB.Name = "AddRB";
            this.AddRB.Size = new System.Drawing.Size(150, 24);
            this.AddRB.TabIndex = 0;
            this.AddRB.TabStop = true;
            this.AddRB.Text = "Add Key Identifier";
            this.AddRB.UseVisualStyleBackColor = true;
            // 
            // RemoveRB
            // 
            this.RemoveRB.AutoSize = true;
            this.RemoveRB.Location = new System.Drawing.Point(9, 56);
            this.RemoveRB.Name = "RemoveRB";
            this.RemoveRB.Size = new System.Drawing.Size(176, 24);
            this.RemoveRB.TabIndex = 1;
            this.RemoveRB.TabStop = true;
            this.RemoveRB.Text = "Remove Key Identifier";
            this.RemoveRB.UseVisualStyleBackColor = true;
            // 
            // AddRemoveSubKeyIdentifiers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 533);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StatusTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ActionBTN);
            this.Controls.Add(this.SubKeyIdentifierTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserIDTB);
            this.Controls.Add(this.label1);
            this.Name = "AddRemoveSubKeyIdentifiers";
            this.Text = "AddRemoveSubKeyIdentifiers";
            this.FormClosing += new FormClosingEventHandler(OnFormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox UserIDTB;
        private Label label2;
        private TextBox SubKeyIdentifierTB;
        private Button ActionBTN;
        private TextBox StatusTB;
        private Label label3;
        private GroupBox groupBox1;
        private RadioButton RemoveRB;
        private RadioButton AddRB;
    }
}