using System.Net.Http.Headers;
using PKDSA_UMWinClient.Helper;

namespace PKDSA_UMWinClient.APIMethodHelper
{
    public static class EstablishConnection
    {
        public static void CreateLinkWithServer() 
        {
            String ServerIP = File.ReadAllText(Application.StartupPath + "\\ServerIP\\IP.txt");
            Boolean CheckServerOnline = true;
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
                    APIIPAddressHelper.IPAddress = File.ReadAllText(Application.StartupPath + "\\ServerIP\\IP.txt");
                    APIIPAddressHelper.HasSet = true;
                }
                else
                {
                    MessageBox.Show("The server is offline now please wait for awhile" + Environment.NewLine +
                        "You can also change the server IP address if you want to","Error Message",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

    }
}
