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
using ASodium;
using BCASodium;

namespace PKDSA_WinClient
{
    public partial class CreateSignatureKeyPair : Form
    {
        public static String SignatureKeyPairRootFolder = Application.StartupPath + "\\Signatures_KeyPairs\\";
        public CreateSignatureKeyPair()
        {
            InitializeComponent();
        }

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            String KeyPairFolderName = KeyPairFolderNameTB.Text;
            RevampedKeyPair MyED25519KeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
            ED448RevampedKeyPair MyED448KeyPair = SecureED448.GenerateED448RevampedKeyPair();
            Byte[] SignedPublicKey = new Byte[] { };
            Byte[] MergedPublicKey = new Byte[] { };
            if (String.IsNullOrEmpty(KeyPairFolderName) == true) 
            {
                MessageBox.Show("Please enter a folder name for storing the signature key pair","Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else 
            {
                if (Directory.Exists(SignatureKeyPairRootFolder+KeyPairFolderName)==true) 
                {
                    MessageBox.Show("This folder name has been used, try another memorizable folder name","Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                {
                    Directory.CreateDirectory(SignatureKeyPairRootFolder + KeyPairFolderName);
                    //Strongly secured elliptic curves which was highly tested by cryptographers and recommended by D.J.B
                    if (Curve25519RB.Checked == true) 
                    {
                        File.WriteAllText(SignatureKeyPairRootFolder + KeyPairFolderName+"\\CurveType.txt","IsCurve25519");
                        //As the function copies and doesn't modify the keypair object's private key
                        //That's why we need to clear the private key after signing ASAP in memory given that
                        //you are able to understand security or cryptography
                        SignedPublicKey = SodiumPublicKeyAuth.Sign(MyED25519KeyPair.PublicKey, MyED25519KeyPair.PrivateKey, true);
                        File.WriteAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Private_Key.txt",MyED25519KeyPair.PrivateKey);
                        File.WriteAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Public_Key.txt", MyED25519KeyPair.PublicKey);
                    }
                    if (Curve448RB.Checked == true) 
                    {
                        File.WriteAllText(SignatureKeyPairRootFolder + KeyPairFolderName + "\\CurveType.txt", "IsCurve448");
                        SignedPublicKey = SecureED448.GenerateSignatureMessage(MyED448KeyPair.PrivateKey,MyED448KeyPair.PublicKey,new Byte[] { },true);
                        File.WriteAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Private_Key.txt", MyED448KeyPair.PrivateKey);
                        File.WriteAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Public_Key.txt", MyED448KeyPair.PublicKey);
                    }
                    //I was not quite sure whether this is an industry standard but personally storing both public key and signed public
                    //key can be used to prove the legitimacy of the public key given I and A aspects in C.I.A. was properly implemented
                    //However, this does not mean the owner of the public key can be proven
                    //There's identity issue here which men doesn't have proper solutions to this unsolvable and addressable issue
                    File.WriteAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Signed_Public_Key.txt", SignedPublicKey);
                    MessageBox.Show("The signature keypairs have been created", "Success Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            MyED448KeyPair.Clear();
            MyED25519KeyPair.Clear();
            LoadKeyPairFolders();
        }

        private void RefreshBTN_Click(object sender, EventArgs e)
        {
            LoadKeyPairFolders();
        }

        private void ViewBTN_Click(object sender, EventArgs e)
        {
            Byte[] PublicKey = new Byte[] { };
            Byte[] SignedPublicKey = new Byte[] { };
            String KeyPairFolderName = KeyPairFolderNameCB.Text;
            if (String.IsNullOrEmpty(KeyPairFolderName)) 
            {
                MessageBox.Show("There's no keypairs created or you have not choose any keypairs", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                if (Directory.Exists(SignatureKeyPairRootFolder + KeyPairFolderName) == true) 
                {
                    PublicKey = File.ReadAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Public_Key.txt");
                    SignedPublicKey = File.ReadAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Signed_Public_Key.txt");
                    PublicKeyTB.Text = Convert.ToBase64String(PublicKey);
                    SignedPublicKeyTB.Text = Convert.ToBase64String(SignedPublicKey);
                }
                else 
                {
                    MessageBox.Show("The specified keypairs folder can't be found", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CreateSignatureKeyPair_Load(object sender, EventArgs e)
        {
            LoadKeyPairFolders();
        }
        
        private void LoadKeyPairFolders()
        {
            String[] KeyPairFolderNamesFullPath = Directory.GetDirectories(SignatureKeyPairRootFolder);
            int Loop = 0;
            String[] KeyPairFolderNames=new String[KeyPairFolderNamesFullPath.Length];
            int RootDirectoryPathLength = SignatureKeyPairRootFolder.Length;
            while (Loop < KeyPairFolderNamesFullPath.Length) 
            {
                KeyPairFolderNames[Loop] = KeyPairFolderNamesFullPath[Loop].Remove(0,RootDirectoryPathLength);
                Loop+=1;
            }
            KeyPairFolderNameCB.Items.Clear();
            KeyPairFolderNameCB.Items.AddRange(KeyPairFolderNames);
        }
    }
}
