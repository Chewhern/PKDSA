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
using PKDSA_UMWinClient.Helper;
using PKDSA_UMWinClient.Model;
using PKDSA_UMWinClient.APIMethodHelper;
using System.Net.Http.Headers;
using System.Net;

namespace PKDSA_UMWinClient
{
    public partial class LoginUsingSubKeys : Form
    {
        public LoginUsingSubKeys()
        {
            InitializeComponent();
        }

        private void RequestChallengeBTN_Click(object sender, EventArgs e)
        {
            if (SubKeyIdentifierTB.Text.CompareTo("") != 0)
            {
                LoginModels myLoginModel = new LoginModels();
                String User_ID = File.ReadAllText(Application.StartupPath + "\\User\\User_ID.txt");
                UserIDTB.Text = User_ID;
                String Key_Identifier = SubKeyIdentifierTB.Text;
                Byte[] Signed_Challenge = new Byte[] { };
                Byte[] Challenge = new Byte[] { };
                Byte[] UserSignedChallenge = new Byte[] { };
                Byte[] Server_PublicKey = new Byte[] { };
                try
                {
                    ChallengeRequestor.RequestChallengeFromServer(User_ID, Key_Identifier, ref myLoginModel);
                }
                catch 
                {
                    ChallengeRequestor.GetLostChallengeFromServer(User_ID, Key_Identifier, ref myLoginModel);
                }                
                Server_PublicKey = Convert.FromBase64String(myLoginModel.ServerECDSAPKBase64String);
                Signed_Challenge = Convert.FromBase64String(myLoginModel.SignedRandomChallengeBase64String);
                Challenge = SodiumPublicKeyAuth.Verify(Signed_Challenge, Server_PublicKey);
                ServerChallengeTB.Text = Convert.ToBase64String(Challenge);
            }
            else 
            {
                MessageBox.Show("Please enter a key identifier in the given text box", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            if (SubKeyIdentifierTB.Text.CompareTo("") != 0 && UserSignedChallengeTB.Text.CompareTo("")!=0)
            {
                String User_ID = File.ReadAllText(Application.StartupPath + "\\User\\User_ID.txt");
                UserIDTB.Text = User_ID;
                String URL = "";
                URL = "UserLogin?User_ID=" + User_ID + "&Key_Identifier=" + SubKeyIdentifierTB.Text + "&URLEncoded_Signed_Challenge=" + System.Web.HttpUtility.UrlEncode(UserSignedChallengeTB.Text);
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
                        var response = client.GetAsync(URL);
                        response.Wait();
                        var result = response.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();

                            var Result = readTask.Result;

                            StatusTB.Text = Result;
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
                        var response = client.GetAsync(URL);
                        response.Wait();
                        var result = response.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();

                            var Result = readTask.Result;

                            StatusTB.Text = Result;
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
                MessageBox.Show("Please enter the signed challenge you generated from other application", "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnFormClosing(object sender, EventArgs e)
        {
            MainFormHolder.myForm.Show();
        }
    }
}
