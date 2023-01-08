using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCASodium;
using ASodium;

namespace PKDSA_WinClient
{
    public partial class ChangeSignatureKeyPair : Form
    {
        public static String SignatureKeyPairRootFolder = Application.StartupPath + "\\Signatures_KeyPairs\\";

        public ChangeSignatureKeyPair()
        {
            InitializeComponent();
        }

        private void ChangeSignatureKeyPair_Load(object sender, EventArgs e)
        {
            LoadKeyPairFolders();
        }

        private void ChangeKeyBTN_Click(object sender, EventArgs e)
        {
            if (KeyPairFolderNameCB.SelectedIndex != -1) 
            {
                String KeyPairFolderName = KeyPairFolderNameCB.Text;
                RevampedKeyPair MyED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                ED448RevampedKeyPair MyED448KeyPair = SecureED448.GenerateED448RevampedKeyPair();
                Byte[] SignedPublicKey = new Byte[] { };
                //Strongly secured elliptic curves which was highly tested by cryptographers and recommended by D.J.B
                if (Curve25519RB.Checked == true)
                {
                    File.WriteAllText(SignatureKeyPairRootFolder + KeyPairFolderName + "\\CurveType.txt", "IsCurve25519");
                    SignedPublicKey = SodiumPublicKeyAuth.Sign(MyED25519KeyPair.PublicKey, MyED25519KeyPair.PrivateKey);
                    File.WriteAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Private_Key.txt", MyED25519KeyPair.PrivateKey);
                    File.WriteAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Public_Key.txt", MyED25519KeyPair.PublicKey);
                }
                else
                {
                    File.WriteAllText(SignatureKeyPairRootFolder + KeyPairFolderName + "\\CurveType.txt", "IsCurve448");
                    SignedPublicKey = SecureED448.GenerateSignatureMessage(MyED448KeyPair.PrivateKey, MyED448KeyPair.PublicKey, new Byte[] { });
                    File.WriteAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Private_Key.txt", MyED448KeyPair.PrivateKey);
                    File.WriteAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Public_Key.txt", MyED448KeyPair.PublicKey);
                }
                //I was not quite sure whether this is an industry standard but personally storing both public key and signed public
                //key can be used to prove the legitimacy of the public key given I and A aspects in C.I.A. was properly implemented
                //However, this does not mean the owner of the public key can be proven
                //There's identity issue here which men doesn't have proper solutions to this unsolvable and addressable issue
                File.WriteAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Signed_Public_Key.txt", SignedPublicKey);
                MessageBox.Show("The signature keypairs have been changed", "Success Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyED448KeyPair.Clear();
                MyED25519KeyPair.Clear();
                LoadKeyPairFolders();
            }            
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
