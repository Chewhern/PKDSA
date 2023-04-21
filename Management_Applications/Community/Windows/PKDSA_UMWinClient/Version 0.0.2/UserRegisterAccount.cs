using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASodium;
using BCASodium;
using Newtonsoft.Json;
using PKDSA_UMWinClient.Helper;
using PKDSA_UMWinClient.Model;

namespace PKDSA_UMWinClient
{
    public partial class UserRegisterAccount : Form
    {
        public UserRegisterAccount()
        {
            InitializeComponent();
        }

        private void UserRegisterAccount_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\User") == false) 
            {
                Directory.CreateDirectory(Application.StartupPath + "\\User");
            }
            if (Directory.Exists(Application.StartupPath + "\\Master_Key") == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Master_Key");
            }
        }

        private void GenerateKeysBTN_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\User\\User_ID.txt") == false)
            {
                String User_ID = CryptographicSecureIDGenerator.GenerateUniqueString();
                if (User_ID.Length > 48) 
                {
                    User_ID = User_ID.Substring(0, 48);
                }
                File.WriteAllText(Application.StartupPath + "\\User\\User_ID.txt", User_ID);
                UserIDTB.Text = User_ID;
                if (Curve25519RB.Checked == true)
                {
                    RevampedKeyPair MyKeyPair = SodiumPublicKeyAuth.GenerateRevampedKeyPair();
                    File.WriteAllBytes(Application.StartupPath + "\\Master_Key\\PublicKey.txt", MyKeyPair.PublicKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Master_Key\\PrivateKey.txt", MyKeyPair.PrivateKey);
                    Byte[] SignedPublicKey = SodiumPublicKeyAuth.Sign(MyKeyPair.PublicKey, MyKeyPair.PrivateKey);
                    PublicKeyTB.Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                    SignedPublicKeyTB.Text = Convert.ToBase64String(SignedPublicKey);
                    MyKeyPair.Clear();
                }
                else 
                {
                    ED448RevampedKeyPair MyKeyPair = SecureED448.GenerateED448RevampedKeyPair();
                    File.WriteAllBytes(Application.StartupPath + "\\Master_Key\\PublicKey.txt", MyKeyPair.PublicKey);
                    File.WriteAllBytes(Application.StartupPath + "\\Master_Key\\PrivateKey.txt", MyKeyPair.PrivateKey);
                    Byte[] SignedPublicKey = SecureED448.GenerateSignatureMessage(MyKeyPair.PrivateKey,MyKeyPair.PublicKey,new Byte[] { });
                    PublicKeyTB.Text = Convert.ToBase64String(MyKeyPair.PublicKey);
                    SignedPublicKeyTB.Text = Convert.ToBase64String(SignedPublicKey);
                    MyKeyPair.Clear();
                }
            }
            else 
            {
                MessageBox.Show("You already have an account with the service provider", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SubmitInfoBTN_Click(object sender, EventArgs e)
        {
            if (UserIDTB.Text.CompareTo("") != 0 && PublicKeyTB.Text.CompareTo("") != 0 && SignedPublicKeyTB.Text.CompareTo("") != 0 && SessionIDTB.Text.CompareTo("")!=0)
            {
                String UserID = UserIDTB.Text;
                String PublicKey = PublicKeyTB.Text;
                String SignedPublicKey = SignedPublicKeyTB.Text;
                String Session_ID = SessionIDTB.Text;
                RegisterModel myModel = new RegisterModel();
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
                        var response = client.GetAsync("RegisterAccount?User_ID=" + UserID + "&Session_ID=" + Session_ID + "&URLEncoded_Master_Signed_PK=" + System.Web.HttpUtility.UrlEncode(SignedPublicKey) + "&URLEncoded_Master_PK=" + System.Web.HttpUtility.UrlEncode(PublicKey));
                        response.Wait();
                        var result = response.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();

                            var Result = readTask.Result;
                            myModel = JsonConvert.DeserializeObject<RegisterModel>(Result);
                            if (myModel.Status.Contains("Error") == true)
                            {
                                SubmissionStatusTB.Text = myModel.Status;
                            }
                            else
                            {
                                SubmissionStatusTB.Text = "Status: " + myModel.Status + "\nUser ID Checker: " + myModel.UserIDChecker + "\nUser ID Count: " + myModel.UserIDCount;
                            }
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
                        var response = client.GetAsync("RegisterAccount?User_ID=" + UserID + "&Session_ID=" + Session_ID + "&URLEncoded_Master_Signed_PK=" + System.Web.HttpUtility.UrlEncode(SignedPublicKey) + "&URLEncoded_Master_PK=" + System.Web.HttpUtility.UrlEncode(PublicKey));
                        response.Wait();
                        var result = response.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();

                            var Result = readTask.Result;
                            myModel = JsonConvert.DeserializeObject<RegisterModel>(Result);
                            if (myModel.Status.Contains("Error") == true)
                            {
                                SubmissionStatusTB.Text = myModel.Status;
                            }
                            else
                            {
                                SubmissionStatusTB.Text = "Status: " + myModel.Status + "\nUser ID Checker: " + myModel.UserIDChecker + "\nUser ID Count: " + myModel.UserIDCount;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There's something wrong on the server side..", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }                
            }
            else 
            {
                MessageBox.Show("You didn't generate keys locally or fill in the required information", "Denying Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OnFormClosing(object sender, EventArgs e)
        {
            MainFormHolder.myForm.Show();
        }
    }
}
