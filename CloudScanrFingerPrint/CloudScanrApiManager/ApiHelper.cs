using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using StandAloneCloudScanrSampleWebApp.Models;
using StandAloneCloudScanrSampleWebApp.Utilities;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace StandAloneCloudScanrSampleWebApp.CloudScanrApiManager
{
    public class ApiHelper
    {
        private string _apiURL = string.Empty;
        public ApiHelper(string apiUrl)
        {
            if (string.IsNullOrEmpty(apiUrl))
                throw new Exception("API Url null or empty is not allowed.");

            int length = apiUrl.Length;
            int index = apiUrl.LastIndexOf("/");
            if (length != (index + 1))
                this._apiURL = string.Format("{0}/", apiUrl);
            else
                this._apiURL = apiUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        private async Task<CloudScanrModels.CSTokenModel> SendPostTokenRequest(string requestPath, string appKey, string appSecret)
        {
            try
            {
                var pairs = new List<KeyValuePair<string, string>>
                        {
                     new KeyValuePair<string, string>( "grant_type", "password" ),
                            new KeyValuePair<string, string>( "username", appKey ),
                            new KeyValuePair<string, string> ( "password", appSecret )

                        };
                var content = new FormUrlEncodedContent(pairs);

                using (var client = new HttpClient())
                {
                    string url = _apiURL + "cstoken";
                    var response =
                        client.PostAsync(url, content).Result;
                    return JsonConvert.DeserializeObject<CloudScanrModels.CSTokenModel>(response.Content.ReadAsStringAsync().Result);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal CloudScanrModels.CSTokenModel GetToken(string appKey, string appSecret)
        {
            try
            {
                return Task.Run(() => this.SendPostTokenRequest("cstoken", appKey, appSecret)).Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<CloudScanrModels.CloudScanrCaptureResult> SendCapturePostRequest(string requestPath, CloudScanrModels.CloudScanrCapture dataToSend, string accessToken)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(this._apiURL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    client.Timeout = new TimeSpan(0, 5, 0);
                    HttpResponseMessage response = await client.PostAsJsonAsync<CloudScanrModels.CloudScanrCapture>(requestPath, dataToSend);
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<CloudScanrModels.CloudScanrCaptureResult>(responseString);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal CloudScanrModels.CloudScanrCaptureResult Capture(CloudScanrModels.CloudScanrCapture cloudScanrCapture, string accessToken)
        {
            try
            {
                return Task.Run(() => this.SendCapturePostRequest("api/CloudScanr/Capture", cloudScanrCapture, accessToken)).Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}