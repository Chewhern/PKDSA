using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PKDSA_WinClient
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            CreateSignatureKeyPair NewForm = new CreateSignatureKeyPair();
            NewForm.Show();
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            DeleteSignatureKeyPair NewForm = new DeleteSignatureKeyPair();
            NewForm.Show();
        }

        private void SignBTN_Click(object sender, EventArgs e)
        {
            SignChallenge NewForm = new SignChallenge();
            NewForm.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\Signatures_KeyPairs") == false) 
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Signatures_KeyPairs");
            }
        }
    }
}
