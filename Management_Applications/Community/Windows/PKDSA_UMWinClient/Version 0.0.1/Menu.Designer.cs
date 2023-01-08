namespace PKDSA_UMWinClient
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
            this.IPConfigBTN = new System.Windows.Forms.Button();
            this.RegistrationBTN = new System.Windows.Forms.Button();
            this.ChangeMasterKeyBTN = new System.Windows.Forms.Button();
            this.AddRemoveKeyIdentifierBTN = new System.Windows.Forms.Button();
            this.AddChangeSubKeysBTN = new System.Windows.Forms.Button();
            this.UserLoginBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(188, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please choose one of the following actions";
            // 
            // IPConfigBTN
            // 
            this.IPConfigBTN.Location = new System.Drawing.Point(228, 54);
            this.IPConfigBTN.Name = "IPConfigBTN";
            this.IPConfigBTN.Size = new System.Drawing.Size(334, 56);
            this.IPConfigBTN.TabIndex = 1;
            this.IPConfigBTN.Text = "1. Server\'s IP address configuration";
            this.IPConfigBTN.UseVisualStyleBackColor = true;
            this.IPConfigBTN.Click += new System.EventHandler(this.IPConfigBTN_Click);
            // 
            // RegistrationBTN
            // 
            this.RegistrationBTN.Location = new System.Drawing.Point(228, 125);
            this.RegistrationBTN.Name = "RegistrationBTN";
            this.RegistrationBTN.Size = new System.Drawing.Size(334, 56);
            this.RegistrationBTN.TabIndex = 2;
            this.RegistrationBTN.Text = "2. Register an account";
            this.RegistrationBTN.UseVisualStyleBackColor = true;
            this.RegistrationBTN.Click += new System.EventHandler(this.RegistrationBTN_Click);
            // 
            // ChangeMasterKeyBTN
            // 
            this.ChangeMasterKeyBTN.Location = new System.Drawing.Point(228, 197);
            this.ChangeMasterKeyBTN.Name = "ChangeMasterKeyBTN";
            this.ChangeMasterKeyBTN.Size = new System.Drawing.Size(334, 56);
            this.ChangeMasterKeyBTN.TabIndex = 3;
            this.ChangeMasterKeyBTN.Text = "3. Change Master Keys";
            this.ChangeMasterKeyBTN.UseVisualStyleBackColor = true;
            this.ChangeMasterKeyBTN.Click += new System.EventHandler(this.ChangeMasterKeyBTN_Click);
            // 
            // AddRemoveKeyIdentifierBTN
            // 
            this.AddRemoveKeyIdentifierBTN.Location = new System.Drawing.Point(228, 270);
            this.AddRemoveKeyIdentifierBTN.Name = "AddRemoveKeyIdentifierBTN";
            this.AddRemoveKeyIdentifierBTN.Size = new System.Drawing.Size(334, 56);
            this.AddRemoveKeyIdentifierBTN.TabIndex = 4;
            this.AddRemoveKeyIdentifierBTN.Text = "3. Add or remove sub key identifiers";
            this.AddRemoveKeyIdentifierBTN.UseVisualStyleBackColor = true;
            this.AddRemoveKeyIdentifierBTN.Click += new System.EventHandler(this.AddRemoveKeyIdentifierBTN_Click);
            // 
            // AddChangeSubKeysBTN
            // 
            this.AddChangeSubKeysBTN.Location = new System.Drawing.Point(228, 341);
            this.AddChangeSubKeysBTN.Name = "AddChangeSubKeysBTN";
            this.AddChangeSubKeysBTN.Size = new System.Drawing.Size(334, 56);
            this.AddChangeSubKeysBTN.TabIndex = 5;
            this.AddChangeSubKeysBTN.Text = "4. Add or change sub keys";
            this.AddChangeSubKeysBTN.UseVisualStyleBackColor = true;
            this.AddChangeSubKeysBTN.Click += new System.EventHandler(this.AddChangeSubKeysBTN_Click);
            // 
            // UserLoginBTN
            // 
            this.UserLoginBTN.Location = new System.Drawing.Point(228, 415);
            this.UserLoginBTN.Name = "UserLoginBTN";
            this.UserLoginBTN.Size = new System.Drawing.Size(334, 56);
            this.UserLoginBTN.TabIndex = 6;
            this.UserLoginBTN.Text = "5. User login using sub keys";
            this.UserLoginBTN.UseVisualStyleBackColor = true;
            this.UserLoginBTN.Click += new System.EventHandler(this.UserLoginBTN_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 499);
            this.Controls.Add(this.UserLoginBTN);
            this.Controls.Add(this.AddChangeSubKeysBTN);
            this.Controls.Add(this.AddRemoveKeyIdentifierBTN);
            this.Controls.Add(this.ChangeMasterKeyBTN);
            this.Controls.Add(this.RegistrationBTN);
            this.Controls.Add(this.IPConfigBTN);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Text = "Public Key Digital Signature Authentication User Information Managing Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button IPConfigBTN;
        private Button RegistrationBTN;
        private Button ChangeMasterKeyBTN;
        private Button AddRemoveKeyIdentifierBTN;
        private Button AddChangeSubKeysBTN;
        private Button UserLoginBTN;
    }
}