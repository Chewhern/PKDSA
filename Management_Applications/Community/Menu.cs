using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PKDSA_UMWinClient.Helper;
using PKDSA_UMWinClient.APIMethodHelper;

namespace PKDSA_UMWinClient
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\ServerIP") == true)
            {
                if (File.Exists(Application.StartupPath + "\\ServerIP\\IP.txt") == true) 
                {
                    EstablishConnection.CreateLinkWithServer();
                }
            }
        }

        private void IPConfigBTN_Click(object sender, EventArgs e)
        {
            ServerIPConfig NewForm = new ServerIPConfig();
            NewForm.Show();
            MainFormHolder.myForm = this;
            MainFormHolder.HasSet= true;
            this.Hide();
        }

        private void RegistrationBTN_Click(object sender, EventArgs e)
        {
            UserRegisterAccount NewForm = new UserRegisterAccount();
            NewForm.Show();
            MainFormHolder.myForm = this;
            MainFormHolder.HasSet = true;
            this.Hide();
        }

        private void ChangeMasterKeyBTN_Click(object sender, EventArgs e)
        {
            ChangeMasterKey NewForm = new ChangeMasterKey();
            NewForm.Show();
            MainFormHolder.myForm = this;
            MainFormHolder.HasSet = true;
            this.Hide();
        }

        private void AddRemoveKeyIdentifierBTN_Click(object sender, EventArgs e)
        {
            AddRemoveSubKeyIdentifiers NewForm = new AddRemoveSubKeyIdentifiers();
            NewForm.Show();
            MainFormHolder.myForm = this;
            MainFormHolder.HasSet = true;
            this.Hide();
        }

        private void AddChangeSubKeysBTN_Click(object sender, EventArgs e)
        {
            AddChangeSubKeys NewForm = new AddChangeSubKeys();
            NewForm.Show();
            MainFormHolder.myForm = this;
            MainFormHolder.HasSet = true;
            this.Hide();
        }

        private void UserLoginBTN_Click(object sender, EventArgs e)
        {
            LoginUsingSubKeys NewForm = new LoginUsingSubKeys();
            NewForm.Show();
            MainFormHolder.myForm = this;
            MainFormHolder.HasSet = true;
            this.Hide();
        }
    }
}
