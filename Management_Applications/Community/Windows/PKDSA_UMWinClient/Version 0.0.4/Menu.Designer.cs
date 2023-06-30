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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            label1 = new Label();
            IPConfigBTN = new Button();
            RegistrationBTN = new Button();
            ChangeMasterKeyBTN = new Button();
            AddRemoveKeyIdentifierBTN = new Button();
            AddChangeSubKeysBTN = new Button();
            UserLoginBTN = new Button();
            TORBTN = new Button();
            ComputePublicKeyDigestBTN = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(217, 9);
            label1.Name = "label1";
            label1.Size = new Size(418, 28);
            label1.TabIndex = 0;
            label1.Text = "Please choose one of the following actions";
            // 
            // IPConfigBTN
            // 
            IPConfigBTN.BackColor = Color.LimeGreen;
            IPConfigBTN.FlatStyle = FlatStyle.Flat;
            IPConfigBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            IPConfigBTN.ForeColor = Color.White;
            IPConfigBTN.Location = new Point(237, 54);
            IPConfigBTN.Name = "IPConfigBTN";
            IPConfigBTN.Size = new Size(370, 56);
            IPConfigBTN.TabIndex = 1;
            IPConfigBTN.Text = "1. Server's IP address configuration";
            IPConfigBTN.UseVisualStyleBackColor = false;
            IPConfigBTN.Click += IPConfigBTN_Click;
            // 
            // RegistrationBTN
            // 
            RegistrationBTN.BackColor = Color.Red;
            RegistrationBTN.FlatStyle = FlatStyle.Flat;
            RegistrationBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            RegistrationBTN.ForeColor = Color.White;
            RegistrationBTN.Location = new Point(237, 199);
            RegistrationBTN.Name = "RegistrationBTN";
            RegistrationBTN.Size = new Size(370, 56);
            RegistrationBTN.TabIndex = 2;
            RegistrationBTN.Text = "2. Register an account";
            RegistrationBTN.UseVisualStyleBackColor = false;
            RegistrationBTN.Click += RegistrationBTN_Click;
            // 
            // ChangeMasterKeyBTN
            // 
            ChangeMasterKeyBTN.BackColor = Color.Red;
            ChangeMasterKeyBTN.FlatStyle = FlatStyle.Flat;
            ChangeMasterKeyBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ChangeMasterKeyBTN.ForeColor = Color.White;
            ChangeMasterKeyBTN.Location = new Point(237, 271);
            ChangeMasterKeyBTN.Name = "ChangeMasterKeyBTN";
            ChangeMasterKeyBTN.Size = new Size(370, 56);
            ChangeMasterKeyBTN.TabIndex = 3;
            ChangeMasterKeyBTN.Text = "3. Change Master Keys";
            ChangeMasterKeyBTN.UseVisualStyleBackColor = false;
            ChangeMasterKeyBTN.Click += ChangeMasterKeyBTN_Click;
            // 
            // AddRemoveKeyIdentifierBTN
            // 
            AddRemoveKeyIdentifierBTN.BackColor = Color.Red;
            AddRemoveKeyIdentifierBTN.FlatStyle = FlatStyle.Flat;
            AddRemoveKeyIdentifierBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AddRemoveKeyIdentifierBTN.ForeColor = Color.White;
            AddRemoveKeyIdentifierBTN.Location = new Point(237, 419);
            AddRemoveKeyIdentifierBTN.Name = "AddRemoveKeyIdentifierBTN";
            AddRemoveKeyIdentifierBTN.Size = new Size(370, 56);
            AddRemoveKeyIdentifierBTN.TabIndex = 4;
            AddRemoveKeyIdentifierBTN.Text = "3. Add or remove sub key identifiers";
            AddRemoveKeyIdentifierBTN.UseVisualStyleBackColor = false;
            AddRemoveKeyIdentifierBTN.Click += AddRemoveKeyIdentifierBTN_Click;
            // 
            // AddChangeSubKeysBTN
            // 
            AddChangeSubKeysBTN.BackColor = Color.Red;
            AddChangeSubKeysBTN.FlatStyle = FlatStyle.Flat;
            AddChangeSubKeysBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AddChangeSubKeysBTN.ForeColor = Color.White;
            AddChangeSubKeysBTN.Location = new Point(237, 490);
            AddChangeSubKeysBTN.Name = "AddChangeSubKeysBTN";
            AddChangeSubKeysBTN.Size = new Size(370, 56);
            AddChangeSubKeysBTN.TabIndex = 5;
            AddChangeSubKeysBTN.Text = "4. Add or change sub keys";
            AddChangeSubKeysBTN.UseVisualStyleBackColor = false;
            AddChangeSubKeysBTN.Click += AddChangeSubKeysBTN_Click;
            // 
            // UserLoginBTN
            // 
            UserLoginBTN.BackColor = Color.Green;
            UserLoginBTN.FlatStyle = FlatStyle.Flat;
            UserLoginBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            UserLoginBTN.ForeColor = Color.White;
            UserLoginBTN.Location = new Point(237, 564);
            UserLoginBTN.Name = "UserLoginBTN";
            UserLoginBTN.Size = new Size(370, 56);
            UserLoginBTN.TabIndex = 6;
            UserLoginBTN.Text = "5. User login using sub keys";
            UserLoginBTN.UseVisualStyleBackColor = false;
            UserLoginBTN.Click += UserLoginBTN_Click;
            // 
            // TORBTN
            // 
            TORBTN.BackColor = Color.LimeGreen;
            TORBTN.FlatStyle = FlatStyle.Flat;
            TORBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TORBTN.ForeColor = Color.White;
            TORBTN.Location = new Point(237, 126);
            TORBTN.Name = "TORBTN";
            TORBTN.Size = new Size(370, 56);
            TORBTN.TabIndex = 7;
            TORBTN.Text = "1. Download and start TOR deepweb";
            TORBTN.UseVisualStyleBackColor = false;
            TORBTN.Click += TORBTN_Click;
            // 
            // ComputePublicKeyDigestBTN
            // 
            ComputePublicKeyDigestBTN.BackColor = Color.Red;
            ComputePublicKeyDigestBTN.FlatStyle = FlatStyle.Flat;
            ComputePublicKeyDigestBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ComputePublicKeyDigestBTN.ForeColor = Color.White;
            ComputePublicKeyDigestBTN.Location = new Point(237, 343);
            ComputePublicKeyDigestBTN.Name = "ComputePublicKeyDigestBTN";
            ComputePublicKeyDigestBTN.Size = new Size(370, 56);
            ComputePublicKeyDigestBTN.TabIndex = 8;
            ComputePublicKeyDigestBTN.Text = "3. Compute and compare master public key digest";
            ComputePublicKeyDigestBTN.UseVisualStyleBackColor = false;
            ComputePublicKeyDigestBTN.Click += ComputePublicKeyDigestBTN_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(626, 54);
            label2.Name = "label2";
            label2.Size = new Size(255, 560);
            label2.TabIndex = 9;
            label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(886, 54);
            label3.Name = "label3";
            label3.Size = new Size(215, 580);
            label3.TabIndex = 10;
            label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 54);
            label4.Name = "label4";
            label4.Size = new Size(194, 640);
            label4.TabIndex = 11;
            label4.Text = resources.GetString("label4.Text");
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1104, 701);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ComputePublicKeyDigestBTN);
            Controls.Add(TORBTN);
            Controls.Add(UserLoginBTN);
            Controls.Add(AddChangeSubKeysBTN);
            Controls.Add(AddRemoveKeyIdentifierBTN);
            Controls.Add(ChangeMasterKeyBTN);
            Controls.Add(RegistrationBTN);
            Controls.Add(IPConfigBTN);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Menu";
            Text = "Public Key Digital Signature Authentication User Information Managing Menu";
            Load += Menu_Load;
            FormClosing += new FormClosingEventHandler(OnFormClosing);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button IPConfigBTN;
        private Button RegistrationBTN;
        private Button ChangeMasterKeyBTN;
        private Button AddRemoveKeyIdentifierBTN;
        private Button AddChangeSubKeysBTN;
        private Button UserLoginBTN;
        private Button TORBTN;
        private Button ComputePublicKeyDigestBTN;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}