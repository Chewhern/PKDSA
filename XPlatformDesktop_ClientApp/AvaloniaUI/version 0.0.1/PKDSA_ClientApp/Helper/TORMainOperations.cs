﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Knapcode.TorSharp;
using PKDSA_ClientApp.APIMethodHelper;

namespace PKDSA_ClientApp.Helper
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

        public static async Task<String> DownloadTOR() 
        {

            using (var httpClient = new HttpClient())
            {
                var fetcher = new TorSharpToolFetcher(mySettings, httpClient);
                await fetcher.FetchAsync();
            }

            return "TOR download completed";
        }

        public static async Task<String> StartTOR() 
        {
            myProxy = new TorSharpProxy(mySettings);
            await myProxy.ConfigureAndStartAsync();

            UsingTor = true;

            return "TOR configured and started";
        }

        public static async Task<String> StartTORWithConnectionToServer()
        {
            myProxy = new TorSharpProxy(mySettings);
            await myProxy.ConfigureAndStartAsync();

            UsingTor = true;

            EstablishConnection.CreateLinkWithServer();

            return "TOR configured and started";
        }

        public static String StopTOR() 
        {
            myProxy.Stop();
            UsingTor = false;

            return "TOR stopped";
        }
    }
}
