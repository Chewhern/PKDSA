using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using PKDSA_UMWinClient.Helper;
using System.Net;

namespace PKDSA_UMWinClient
{
    public partial class ServerIPConfig : Form
    {
        public ServerIPConfig()
        {
            InitializeComponent();
        }

        private void ServerIPConfig_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\ServerIP") == false) 
            {
                Directory.CreateDirectory(Application.StartupPath + "\\ServerIP");
            }
        }

        private void SetIPBTN_Click(object sender, EventArgs e)
        {
            String ServerIP = "";
            ServerIP = IPTB.Text;
            if (String.IsNullOrEmpty(ServerIP) == true)
            {
                MessageBox.Show("Please enter a valid server IP address","Error Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else 
            {
                File.WriteAllText(Application.StartupPath + "\\ServerIP\\IP.txt", ServerIP);
                MessageBox.Show("The server IP address has been recorded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void CheckOnlineStatusBTN_Click(object sender, EventArgs e)
        {
            //The following code will be put into SDK later if I have the time to do so 🤣🤣🤣
            String ServerIP = File.ReadAllText(Application.StartupPath + "\\ServerIP\\IP.txt");
            Boolean CheckServerOnline = true;
            if (TORMainOperations.UsingTor == true)
            {
                await TORProxyCheckServerOnline(ServerIP);
            }
            else 
            {
                using (var InitializeHandShakeHttpclient = new HttpClient())
                {
                    InitializeHandShakeHttpclient.BaseAddress = new Uri(ServerIP);
                    InitializeHandShakeHttpclient.DefaultRequestHeaders.Accept.Clear();
                    InitializeHandShakeHttpclient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = InitializeHandShakeHttpclient.GetAsync("ServerStatus");
                    try
                    {
                        response.Wait();
                    }
                    catch
                    {
                        CheckServerOnline = false;
                    }
                    if (CheckServerOnline == true)
                    {
                        StatusTB.Text = "The server was online";
                        APIIPAddressHelper.IPAddress = File.ReadAllText(Application.StartupPath + "\\ServerIP\\IP.txt");
                        APIIPAddressHelper.HasSet = true;
                    }
                    else
                    {
                        StatusTB.Text = "The server is offline now please wait for awhile" + Environment.NewLine +
                            "You can also change the server IP address if you want to";
                    }
                }
            }            
        }

        private async Task<Boolean> TORProxyCheckServerOnline(String ServerIP) 
        {
            Boolean CheckServerOnline = true;
            var handler = new HttpClientHandler
            {
                Proxy = new WebProxy(new Uri("socks5://localhost:19050"))
            };

            using (handler)
            using (var InitializeHandShakeHttpclient = new HttpClient(handler))
            {
                InitializeHandShakeHttpclient.BaseAddress = new Uri(ServerIP);
                InitializeHandShakeHttpclient.DefaultRequestHeaders.Accept.Clear();
                InitializeHandShakeHttpclient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response= new HttpResponseMessage();
                try
                {
                    response = await InitializeHandShakeHttpclient.GetAsync("ServerStatus");
                }
                catch
                {
                    CheckServerOnline = false;
                }

                if (CheckServerOnline == true)
                {
                    StatusTB.Text = "The server was online";
                    APIIPAddressHelper.IPAddress = File.ReadAllText(Application.StartupPath + "\\ServerIP\\IP.txt");
                    APIIPAddressHelper.HasSet = true;
                }
                else
                {
                    StatusTB.Text = "The server is offline now please wait for awhile" + Environment.NewLine +
                        "You can also change the server IP address if you want to";
                }
            }
            return CheckServerOnline;
        }


        private void OnFormClosing(object sender, EventArgs e) 
        {
            MainFormHolder.myForm.Show();
        }
    }
}
