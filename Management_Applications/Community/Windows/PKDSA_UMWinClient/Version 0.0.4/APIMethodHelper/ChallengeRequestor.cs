using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PKDSA_UMWinClient.Model;
using Newtonsoft.Json;
using PKDSA_UMWinClient.Helper;
using System.Net.Http.Headers;
using System.Net;

namespace PKDSA_UMWinClient.APIMethodHelper
{
    public static class ChallengeRequestor
    {
        public static async Task<LoginModels> RequestChallengeFromServer(String User_ID, String Key_Identifier)
        {
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
                    var response = await client.GetAsync("ChallengeRequestor?User_ID=" + User_ID + "&Key_Identifier=" + Key_Identifier);
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var Result = readTask.Result;
                        return JsonConvert.DeserializeObject<LoginModels>(Result);
                    }
                    else
                    {
                        MessageBox.Show("There's something wrong on the server side..", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new LoginModels();
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
                    var response = await client.GetAsync("ChallengeRequestor?User_ID=" + User_ID + "&Key_Identifier=" + Key_Identifier);
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var Result = readTask.Result;
                        return JsonConvert.DeserializeObject<LoginModels>(Result);
                    }
                    else
                    {
                        MessageBox.Show("There's something wrong on the server side..", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new LoginModels();
                    }
                }
            }            
        }

        public static async Task<LoginModels> GetLostChallengeFromServer(String User_ID, String Key_Identifier)
        {
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
                    var response = await client.GetAsync("ChallengeRequestor/GetLostChallenge?User_ID=" + User_ID + "&Key_Identifier=" + Key_Identifier);
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var Result = readTask.Result;
                        return JsonConvert.DeserializeObject<LoginModels>(Result);
                    }
                    else
                    {
                        MessageBox.Show("There's something wrong on the server side..", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new LoginModels();
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
                    var response = await client.GetAsync("ChallengeRequestor/GetLostChallenge?User_ID=" + User_ID + "&Key_Identifier=" + Key_Identifier);
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var Result = readTask.Result;
                        return JsonConvert.DeserializeObject<LoginModels>(Result);
                    }
                    else
                    {
                        MessageBox.Show("There's something wrong on the server side..", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new LoginModels();
                    }
                }
            }            
        }
    }
}
