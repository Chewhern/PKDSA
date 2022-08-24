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
    public partial class DeleteSignatureKeyPair : Form
    {
        public static String SignatureKeyPairRootFolder = Application.StartupPath + "\\Signatures_KeyPairs\\";


        public DeleteSignatureKeyPair()
        {
            InitializeComponent();
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            String KeyPairFolderName = KeyPairFolderNameCB.Text;
            if (String.IsNullOrEmpty(KeyPairFolderName))
            {
                MessageBox.Show("There's no keypairs created or you have not choose any keypairs", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Directory.Exists(SignatureKeyPairRootFolder + KeyPairFolderName) == true)
                {
                    Directory.Delete(SignatureKeyPairRootFolder + KeyPairFolderName, true);
                    MessageBox.Show("The specified keypair folder has been deleted","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The specified keypairs folder can't be found", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadKeyPairFolders();
        }

        private void DeleteSignatureKeyPair_Load(object sender, EventArgs e)
        {
            LoadKeyPairFolders();
        }

        private void LoadKeyPairFolders()
        {
            String[] KeyPairFolderNamesFullPath = Directory.GetDirectories(SignatureKeyPairRootFolder);
            int Loop = 0;
            String[] KeyPairFolderNames = new String[KeyPairFolderNamesFullPath.Length];
            int RootDirectoryPathLength = SignatureKeyPairRootFolder.Length;
            while (Loop < KeyPairFolderNamesFullPath.Length)
            {
                KeyPairFolderNames[Loop] = KeyPairFolderNamesFullPath[Loop].Remove(0, RootDirectoryPathLength);
                Loop += 1;
            }
            KeyPairFolderNameCB.Items.Clear();
            KeyPairFolderNameCB.Items.AddRange(KeyPairFolderNames);
        }
    }
}
