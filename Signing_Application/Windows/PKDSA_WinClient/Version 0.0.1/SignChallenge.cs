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
using BCASodium;
using ASodium;

namespace PKDSA_WinClient
{
    public partial class SignChallenge : Form
    {
        public static String SignatureKeyPairRootFolder = Application.StartupPath + "\\Signatures_KeyPairs\\";

        public SignChallenge()
        {
            InitializeComponent();
        }

        private void SignChallenge_Load(object sender, EventArgs e)
        {
            LoadKeyPairFolders();
        }

        private void RefreshBTN_Click(object sender, EventArgs e)
        {
            LoadKeyPairFolders();
        }

        private void SignBTN_Click(object sender, EventArgs e)
        {
            Byte[] PrivateKey = new Byte[] { };
            Byte[] Challenge = new Byte[] { };
            Byte[] SignedChallenge = new Byte[] { };
            Boolean TryParseFromBase64String = true;
            String CurveDeterminer = "";
            String ChallengeString = ChallengeTB.Text;
            String KeyPairFolderName = KeyPairFolderNameCB.Text;
            if (String.IsNullOrEmpty(KeyPairFolderName))
            {
                MessageBox.Show("There's no keypairs created or you have not choose any keypairs", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Directory.Exists(SignatureKeyPairRootFolder + KeyPairFolderName) == true)
                {
                    if (String.IsNullOrEmpty(ChallengeString) == true) 
                    {
                        MessageBox.Show("Please get the base 64 encoded challenge from provider", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else 
                    {
                        try 
                        {
                            Challenge = Convert.FromBase64String(ChallengeString);
                        }
                        catch 
                        {
                            TryParseFromBase64String = false;
                        }
                        if (TryParseFromBase64String == true) 
                        {
                            PrivateKey = File.ReadAllBytes(SignatureKeyPairRootFolder + KeyPairFolderName + "\\Private_Key.txt");
                            CurveDeterminer = File.ReadAllText(SignatureKeyPairRootFolder + KeyPairFolderName + "\\CurveType.txt");
                            if (CurveDeterminer.CompareTo("IsCurve25519") == 0)
                            {
                                SignedChallenge = SodiumPublicKeyAuth.Sign(Challenge, PrivateKey);
                                SignedChallengeTB.Text = Convert.ToBase64String(SignedChallenge);
                                CurveTypeTB.Text = CurveDeterminer;
                            }
                            else if (CurveDeterminer.CompareTo("IsCurve448") == 0)
                            {
                                SignedChallenge = SecureED448.GenerateSignatureMessage(PrivateKey, Challenge, new Byte[] { });
                                SignedChallengeTB.Text = Convert.ToBase64String(SignedChallenge);
                                CurveTypeTB.Text = CurveDeterminer;
                            }
                            else
                            {
                                MessageBox.Show("Something's wrong with the Curve Type File", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            SodiumSecureMemory.SecureClearBytes(PrivateKey);
                        }
                        else 
                        {
                            MessageBox.Show("This is not a valid Base 64 encoded string/challenge", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The specified keypairs folder can't be found", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void KeyPairFolderNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KeyPairFolderNameCB.SelectedIndex != -1) 
            {
                KeyPairFolderNameTB.Text = KeyPairFolderNameCB.Text;
            }
        }
    }
}
