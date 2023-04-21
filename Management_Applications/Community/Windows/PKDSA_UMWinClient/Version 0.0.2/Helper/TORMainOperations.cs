using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knapcode.TorSharp;
using Knapcode.TorSharp.Adapters;
using Knapcode.TorSharp.Tools;
using System.Net;
using PKDSA_UMWinClient.APIMethodHelper;

namespace PKDSA_UMWinClient.Helper
{
    public static class TORMainOperations
    {
        private static String TOR;
        private static String ZippedDirectory;
        private static String ExtractedDirectory;
        private static TorSharpSettings mySettings = new TorSharpSettings
        {
            ZippedToolsDirectory = ZippedDirectory,
            ExtractedToolsDirectory = ExtractedDirectory,
            PrivoxySettings = { Disable = true }
        };
        private static TorSharpProxy myProxy;
        public static Boolean UsingTor = false;

        public static void SetToolsDirectory(String zippedDirectory,String extractedDirectory) 
        {
            ZippedDirectory= zippedDirectory;
            ExtractedDirectory= extractedDirectory;
            mySettings = new TorSharpSettings
            {
                ZippedToolsDirectory = ZippedDirectory,
                ExtractedToolsDirectory = ExtractedDirectory,
                PrivoxySettings = { Disable = true }
            };
        }

        public static async void DownloadTOR() 
        {

            using (var httpClient = new HttpClient())
            {
                var fetcher = new TorSharpToolFetcher(mySettings, httpClient);
                await fetcher.FetchAsync();
            }

            MessageBox.Show("TOR download completed", "TOR Download Status");
        }

        public static async void StartTOR() 
        {
            myProxy = new TorSharpProxy(mySettings);
            await myProxy.ConfigureAndStartAsync();

            UsingTor = true;

            MessageBox.Show("TOR configured and started", "TOR Start Up Status");
        }

        public static async void StartTORWithConnectionToServer()
        {
            myProxy = new TorSharpProxy(mySettings);
            await myProxy.ConfigureAndStartAsync();

            UsingTor = true;

            EstablishConnection.CreateLinkWithServer();

            MessageBox.Show("TOR configured and started"+Environment.NewLine+"Connection with server has been established..", "TOR Start Up Status");
        }

        public static void StopTOR() 
        {
            myProxy.Stop();
            UsingTor = false;

            MessageBox.Show("TOR stopped", "TOR Stop Status");
        }
    }
}
