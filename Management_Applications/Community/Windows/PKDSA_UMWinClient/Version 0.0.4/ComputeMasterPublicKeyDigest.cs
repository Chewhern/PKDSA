using PKDSA_UMWinClient.Helper;
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
using System.Net.Http.Headers;
using System.Net;

namespace PKDSA_UMWinClient
{
    public partial class ComputeMasterPublicKeyDigest : Form
    {
        public ComputeMasterPublicKeyDigest()
        {
            InitializeComponent();
        }

        private void ComputeDigestBTN_Click(object sender, EventArgs e)
        {
            String User_ID = File.ReadAllText(Application.StartupPath + "\\User\\User_ID.txt");
            UserIDTB.Text = User_ID;
            Byte[] MasterPublicKey = File.ReadAllBytes(Application.StartupPath + "\\Master_Key\\PublicKey.txt");
            Byte[] MasterPublicKeyDigest = SodiumGenericHash.ComputeHash(64, MasterPublicKey);
            SystemPKDigestTB.Text = Convert.ToBase64String(MasterPublicKeyDigest);
        }

        private async void FetchDigestBTN_Click(object sender, EventArgs e)
        {
            String User_ID = "";
            User_ID = UserIDTB.Text;
            if (User_ID.CompareTo("") != 0)
            {
                if (TORMainOperations.UsingTor == true)
                {
                    ServerPKDigestTB.Text = await TORProxyFetchDigest(User_ID);
                }
                else
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(APIIPAddressHelper.IPAddress);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.GetAsync("UserPublicKeyDigest?User_ID=" + User_ID);
                        response.Wait();
                        var result = response.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();

                            var Result = readTask.Result;
                            ServerPKDigestTB.Text = Result.Substring(1, Result.Length - 2);
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
                MessageBox.Show("First, please compute the master public key digest locally", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CompareDigestsBTN_Click(object sender, EventArgs e)
        {
            String SystemMasterPublicKeyDigest = SystemPKDigestTB.Text;
            String ServerMasterPublicKeyDigest = ServerPKDigestTB.Text;
            if (SystemMasterPublicKeyDigest.CompareTo("") != 0 && ServerMasterPublicKeyDigest.CompareTo("") != 0)
            {
                //Not really that important if it's constant time compare
                //Ultimately these are publicly disclosable data
                //The digest of public keys are as well
                Boolean Comparison = SystemMasterPublicKeyDigest.CompareTo(ServerMasterPublicKeyDigest) == 0;
                if (Comparison == true)
                {
                    MessageBox.Show("Both digest matched.. Yay..", "Digest Comparison Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please refer to the GUI for more information", "Digest Comparison Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("If you don't fetch the digest from server and compute a digest locally, comparison operations couldn't be done", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<String> TORProxyFetchDigest(String User_ID) 
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
                var response = await client.GetAsync("UserPublicKeyDigest?User_ID=" + User_ID);
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var Result = readTask.Result;
                    return Result.Substring(1, Result.Length - 2);
                }
                else
                {
                    MessageBox.Show("There's something wrong on the server side..", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
        }

        private void OnFormClosing(object sender, EventArgs e)
        {
            MainFormHolder.myForm.Show();
        }
    }
}
