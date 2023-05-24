namespace PKDSA_UMWinClient
{
    partial class ComputeMasterPublicKeyDigest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComputeMasterPublicKeyDigest));
            label1 = new Label();
            UserIDTB = new TextBox();
            label2 = new Label();
            SystemPKDigestTB = new TextBox();
            ComputeDigestBTN = new Button();
            ServerPKDigestTB = new TextBox();
            label3 = new Label();
            FetchDigestBTN = new Button();
            CompareDigestsBTN = new Button();
            label4 = new Label();
            label5 = new Label();
            ProviderSessionUserIDTB = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 0;
            label1.Text = "User ID";
            // 
            // UserIDTB
            // 
            UserIDTB.Location = new Point(12, 32);
            UserIDTB.Multiline = true;
            UserIDTB.Name = "UserIDTB";
            UserIDTB.ReadOnly = true;
            UserIDTB.Size = new Size(185, 66);
            UserIDTB.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 111);
            label2.Name = "label2";
            label2.Size = new Size(149, 40);
            label2.TabIndex = 2;
            label2.Text = "System Master Public\r\nKey Digest";
            // 
            // SystemPKDigestTB
            // 
            SystemPKDigestTB.Location = new Point(12, 154);
            SystemPKDigestTB.Multiline = true;
            SystemPKDigestTB.Name = "SystemPKDigestTB";
            SystemPKDigestTB.ReadOnly = true;
            SystemPKDigestTB.Size = new Size(185, 84);
            SystemPKDigestTB.TabIndex = 3;
            // 
            // ComputeDigestBTN
            // 
            ComputeDigestBTN.Location = new Point(12, 253);
            ComputeDigestBTN.Name = "ComputeDigestBTN";
            ComputeDigestBTN.Size = new Size(185, 51);
            ComputeDigestBTN.TabIndex = 4;
            ComputeDigestBTN.Text = "Compute Digest";
            ComputeDigestBTN.UseVisualStyleBackColor = true;
            ComputeDigestBTN.Click += ComputeDigestBTN_Click;
            // 
            // ServerPKDigestTB
            // 
            ServerPKDigestTB.Location = new Point(287, 33);
            ServerPKDigestTB.Multiline = true;
            ServerPKDigestTB.Name = "ServerPKDigestTB";
            ServerPKDigestTB.ReadOnly = true;
            ServerPKDigestTB.Size = new Size(218, 77);
            ServerPKDigestTB.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(287, 10);
            label3.Name = "label3";
            label3.Size = new Size(218, 20);
            label3.TabIndex = 5;
            label3.Text = "Server Master Public Key Digest";
            // 
            // FetchDigestBTN
            // 
            FetchDigestBTN.Location = new Point(287, 126);
            FetchDigestBTN.Name = "FetchDigestBTN";
            FetchDigestBTN.Size = new Size(218, 51);
            FetchDigestBTN.TabIndex = 7;
            FetchDigestBTN.Text = "Fetch Digest From Server";
            FetchDigestBTN.UseVisualStyleBackColor = true;
            FetchDigestBTN.Click += FetchDigestBTN_Click;
            // 
            // CompareDigestsBTN
            // 
            CompareDigestsBTN.Location = new Point(287, 197);
            CompareDigestsBTN.Name = "CompareDigestsBTN";
            CompareDigestsBTN.Size = new Size(218, 51);
            CompareDigestsBTN.TabIndex = 8;
            CompareDigestsBTN.Text = "Compare Digests";
            CompareDigestsBTN.UseVisualStyleBackColor = true;
            CompareDigestsBTN.Click += CompareDigestsBTN_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(554, 9);
            label4.Name = "label4";
            label4.Size = new Size(423, 500);
            label4.TabIndex = 9;
            label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(1022, 9);
            label5.Name = "label5";
            label5.Size = new Size(226, 40);
            label5.TabIndex = 10;
            label5.Text = "Default Provider's Session User\r\nID";
            // 
            // ProviderSessionUserIDTB
            // 
            ProviderSessionUserIDTB.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProviderSessionUserIDTB.Location = new Point(1022, 52);
            ProviderSessionUserIDTB.Multiline = true;
            ProviderSessionUserIDTB.Name = "ProviderSessionUserIDTB";
            ProviderSessionUserIDTB.ReadOnly = true;
            ProviderSessionUserIDTB.Size = new Size(226, 86);
            ProviderSessionUserIDTB.TabIndex = 11;
            ProviderSessionUserIDTB.Text = "05573054e242144d0df881e763d4806d9eee207a81900d790d49401b5bd2f44c36";
            // 
            // ComputeMasterPublicKeyDigest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1255, 520);
            Controls.Add(ProviderSessionUserIDTB);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(CompareDigestsBTN);
            Controls.Add(FetchDigestBTN);
            Controls.Add(ServerPKDigestTB);
            Controls.Add(label3);
            Controls.Add(ComputeDigestBTN);
            Controls.Add(SystemPKDigestTB);
            Controls.Add(label2);
            Controls.Add(UserIDTB);
            Controls.Add(label1);
            Name = "ComputeMasterPublicKeyDigest";
            Text = "ComputeMasterPublicKeyDigest";
            FormClosing += OnFormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox UserIDTB;
        private Label label2;
        private TextBox SystemPKDigestTB;
        private Button ComputeDigestBTN;
        private TextBox ServerPKDigestTB;
        private Label label3;
        private Button FetchDigestBTN;
        private Button CompareDigestsBTN;
        private Label label4;
        private Label label5;
        private TextBox ProviderSessionUserIDTB;
    }
}