using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using PKDSA_ClientApp.Helper;
using System.Runtime.InteropServices;

namespace PKDSA_ClientApp.APIMethodHelper
{
    public static class EstablishConnection
    {
        public static String ConnectionStatus = "";

        public static void CreateLinkWithServer() 
        {
            String ServerIP = "";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == true)
            {
                ServerIP = File.ReadAllText(AppContext.BaseDirectory + "\\ServerIP\\IP.txt");
            }
            else 
            {
                ServerIP = File.ReadAllText(AppContext.BaseDirectory + "/ServerIP/IP.txt");
            }
            Boolean CheckServerOnline = true;
            if (TORMainOperations.UsingTor == true)
            {
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
                        APIIPAddressHelper.IPAddress = ServerIP;
                        APIIPAddressHelper.HasSet = true;
                        ConnectionStatus = "The connection with server had been started";
                    }
                    else
                    {
                        ConnectionStatus = "The server is offline now please wait for awhile" + Environment.NewLine +
                            "You can also change the server IP address if you want to";
                    }
                }
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
                        APIIPAddressHelper.IPAddress = ServerIP;
                        APIIPAddressHelper.HasSet = true;
                        ConnectionStatus = "The connection with server had been started";
                    }
                    else
                    {
                        ConnectionStatus= "The server is offline now please wait for awhile" + Environment.NewLine +
                            "You can also change the server IP address if you want to";
                    }
                }
            }            
        }

    }
}
