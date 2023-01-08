namespace PKDSA_WinClient
{
    partial class Menu
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
            this.CreateBTN = new System.Windows.Forms.Button();
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.SignBTN = new System.Windows.Forms.Button();
            this.ChangeBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(308, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select A Button\r\n";
            // 
            // CreateBTN
            // 
            this.CreateBTN.Location = new System.Drawing.Point(244, 53);
            this.CreateBTN.Name = "CreateBTN";
            this.CreateBTN.Size = new System.Drawing.Size(324, 67);
            this.CreateBTN.TabIndex = 1;
            this.CreateBTN.Text = "1. Create Signature Key Pair\r\n2. View Signature Key Pair";
            this.CreateBTN.UseVisualStyleBackColor = true;
            this.CreateBTN.Click += new System.EventHandler(this.CreateBTN_Click);
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Location = new System.Drawing.Point(244, 228);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(324, 67);
            this.DeleteBTN.TabIndex = 2;
            this.DeleteBTN.Text = "2. Delete Signature Key Pair";
            this.DeleteBTN.UseVisualStyleBackColor = true;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // SignBTN
            // 
            this.SignBTN.Location = new System.Drawing.Point(244, 315);
            this.SignBTN.Name = "SignBTN";
            this.SignBTN.Size = new System.Drawing.Size(324, 63);
            this.SignBTN.TabIndex = 3;
            this.SignBTN.Text = "2/3. Sign Challenge";
            this.SignBTN.UseVisualStyleBackColor = true;
            this.SignBTN.Click += new System.EventHandler(this.SignBTN_Click);
            // 
            // ChangeBTN
            // 
            this.ChangeBTN.Location = new System.Drawing.Point(244, 139);
            this.ChangeBTN.Name = "ChangeBTN";
            this.ChangeBTN.Size = new System.Drawing.Size(324, 67);
            this.ChangeBTN.TabIndex = 4;
            this.ChangeBTN.Text = "2. Change Signature Key Pair";
            this.ChangeBTN.UseVisualStyleBackColor = true;
            this.ChangeBTN.Click += new System.EventHandler(this.ChangeBTN_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChangeBTN);
            this.Controls.Add(this.SignBTN);
            this.Controls.Add(this.DeleteBTN);
            this.Controls.Add(this.CreateBTN);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Text = "Public Key Digital Signature Authentication Windows Client Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button CreateBTN;
        private Button DeleteBTN;
        private Button SignBTN;
        private Button ChangeBTN;
    }
}