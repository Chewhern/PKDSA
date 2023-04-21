using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASodium;
using BCASodium;
using PKDSA_UMWinClient.Helper;
using PKDSA_UMWinClient.Model;
using PKDSA_UMWinClient.APIMethodHelper;
using System.Net.Http.Headers;
using System.Net;

namespace PKDSA_UMWinClient
{
    public partial class ChangeMasterKey : Form
    {
        public ChangeMasterKey()
        {
            InitializeComponent();
        }

        private void GenerateKeysBTN_Click(object sender, EventArgs e)
        {
            String User_ID = File.ReadAllText(Application.StartupPath + "\\User\\User_ID.txt");
            UserIDTB.Text = User_ID;
            if (Curve25519RB.Checked == true)
            {
                RevampedKeyPair MyKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                File.WriteAllBytes(Application.StartupPath + "\\Master_Key\\NewPublicKey.txt", MyKeyPair.PublicKey);
                File.WriteAllBytes(Application.StartupPath + "\\Master_Key\\NewPrivateKey.txt", MyKeyPair.PrivateKey);
                Byte[] SignedPublicKey = SodiumPublicKeyAuth.Sign(MyKeyPair.PublicKey, MyKeyPair.PrivateKey);
                PublicKeyTB.Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                SignedPublicKeyTB.Text = Convert.ToBase64String(SignedPublicKey);
                MyKeyPair.Clear();
            }
            else
            {
                ED448RevampedKeyPair MyKeyPair = SecureED448.GenerateED448RevampedKeyPair();
                File.WriteAllBytes(Application.StartupPath + "\\Master_Key\\NewPublicKey.txt", MyKeyPair.PublicKey);
                File.WriteAllBytes(Application.StartupPath + "\\Master_Key\\NewPrivateKey.txt", MyKeyPair.PrivateKey);
                Byte[] SignedPublicKey = SecureED448.GenerateSignatureMessage(MyKeyPair.PrivateKey, MyKeyPair.PublicKey, new Byte[] { });
                PublicKeyTB.Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                SignedPublicKeyTB.Text = Convert.ToBase64String(SignedPublicKey);
                MyKeyPair.Clear();
            }
        }

        private void SubmitInfoBTN_Click(object sender, EventArgs e)
        {
            LoginModels myLoginModel = new LoginModels();
            String User_ID = File.ReadAllText(Application.StartupPath + "\\User\\User_ID.txt");
            Byte[] Signed_Challenge = new Byte[] { };
            Byte[] Challenge = new Byte[] { };
            Byte[] UserSignedChallenge = new Byte[] { };
            Byte[] Server_PublicKey = new Byte[] { };
            Byte[] OldPrivateKey = File.ReadAllBytes(Application.StartupPath + "\\Master_Key\\PrivateKey.txt");
            try
            {
                MasterChallengeRequestor.RequestMasterChallengeFromServer(User_ID, ref myLoginModel);
            }
            catch 
            {
                MasterChallengeRequestor.GetLostChallengeFromServer(User_ID, ref myLoginModel);
            }            
            Server_PublicKey = Convert.FromBase64String(myLoginModel.ServerECDSAPKBase64String);
            Signed_Challenge = Convert.FromBase64String(myLoginModel.SignedRandomChallengeBase64String);
            Challenge = SodiumPublicKeyAuth.Verify(Signed_Challenge, Server_PublicKey);
            if (OldPrivateKey.Length == 57)
            {
                UserSignedChallenge = SecureED448.GenerateSignatureMessage(OldPrivateKey, Challenge, new Byte[] { },true);
            }
            else 
            {
                UserSignedChallenge = SodiumPublicKeyAuth.Sign(Challenge, OldPrivateKey, true);
            }
            if (TORMainOperations.UsingTor == true)
            {
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy(new Uri("socks5://localhost:19050"))
                };

                using (handler)
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("ChangeKey?User_ID=" + User_ID + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge)) + "&URLEncoded_Signed_PK=" + System.Web.HttpUtility.UrlEncode(SignedPublicKeyTB.Text) + "&URLEncoded_PK=" + System.Web.HttpUtility.UrlEncode(PublicKeyTB.Text));
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var Result = readTask.Result;

                        ChangeKeysStatusTB.Text = Result;

                        File.Delete(Application.StartupPath + "\\Master_Key\\PrivateKey.txt");
                        File.Delete(Application.StartupPath + "\\Master_Key\\PublicKey.txt");
                        File.Move(Application.StartupPath + "\\Master_Key\\NewPublicKey.txt", Application.StartupPath + "\\Master_Key\\PublicKey.txt");
                        File.Move(Application.StartupPath + "\\Master_Key\\NewPrivateKey.txt", Application.StartupPath + "\\Master_Key\\PrivateKey.txt");
                    }
                    else
                    {
                        MessageBox.Show("There's something wrong on the server side..", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else 
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("ChangeKey?User_ID=" + User_ID + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(UserSignedChallenge)) + "&URLEncoded_Signed_PK=" + System.Web.HttpUtility.UrlEncode(SignedPublicKeyTB.Text) + "&URLEncoded_PK=" + System.Web.HttpUtility.UrlEncode(PublicKeyTB.Text));
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var Result = readTask.Result;

                        ChangeKeysStatusTB.Text = Result;

                        File.Delete(Application.StartupPath + "\\Master_Key\\PrivateKey.txt");
                        File.Delete(Application.StartupPath + "\\Master_Key\\PublicKey.txt");
                        File.Move(Application.StartupPath + "\\Master_Key\\NewPublicKey.txt", Application.StartupPath + "\\Master_Key\\PublicKey.txt");
                        File.Move(Application.StartupPath + "\\Master_Key\\NewPrivateKey.txt", Application.StartupPath + "\\Master_Key\\PrivateKey.txt");
                    }
                    else
                    {
                        MessageBox.Show("There's something wrong on the server side..", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }            
        }

        private void OnFormClosing(object sender, EventArgs e)
        {
            MainFormHolder.myForm.Show();
        }
    }
}
