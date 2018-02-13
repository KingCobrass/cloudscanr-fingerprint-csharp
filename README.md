# cloudscanr-fingerprint-CSharp
This is the  ASP.NET (C#) Web application where I have used CloudScanr API to capture FingerPrint by the supported devices. Capture ISO/ICS/M2ICS formatted template based on given API parameter. I also, implement how to capture face image during fingerprint capture.

# Authenticate CloudScanr API
string appKey = "APP_KEY";  //Collect valid AppKey from M2SYS
string appSecret = "APP_SECRET"; //Collect from M2SYS
string requestPath = "https://cloudscanr.cloudabis.com/fpapiv1/cstoken";

      -----------------------------------------------Call Authenticate api to get access_token----------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        private async Task<CSTokenModel> SendPostTokenRequest(string requestPath, string appKey, string appSecret)
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
                    return JsonConvert.DeserializeObject<CSTokenModel>(response.Content.ReadAsStringAsync().Result);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
		
		***You will be get access_token to use CloudScanr capture API if given credentials is valid
		
		----------------------------------------CloudScanr CaptureAPI--------------------------------------------
		To get API documentation, please visit https://cloudscanr.cloudabis.com/fpapiv1/Help/Api/POST-api-CloudScanr-Capture
		
		Use "api/CloudScanr/Capture" to capture finger print
		
		string customerKey = "CUSTOMER_KEY"; //Collect from M2SYS
		string accessPointID = "ACCESS_POINT_ID"; //You have to install CloudScanr client app to getting access Point ID. AccessPointID can be take from system try by right click on "Copy Access Point ID". To get more info about CloudScanr client please visit  https://cloudscanr.cloudabis.com/fpapiv1/Home/ClientAppDocumention
		
		CloudScanrCapture dataToSend = new CloudScanrCapture();
		 dataToSend.CustomerKey = customerKey;
		 dataToSend.AccessPointID = accessPointID;
		string reguestPath = "https://cloudscanr.cloudabis.com/fpapiv1/api/CloudScanr/Capture";
		
	private async Task<CloudScanrCaptureResult> SendCapturePostRequest(string requestPath, CloudScanrCapture dataToSend, string accessToken)
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
                    return JsonConvert.DeserializeObject<CloudScanrCaptureResult>(responseString);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }	
		
		***If given credentials (CustomerKey,Access Token, AccessPointID) is valid then you will be get CloudScanrCaptureResult object.
		
		All possible response code message
		 /// <summary>
        /// CS003: Required parameter is empty or null
        /// </summary>
        public const string CS003 = "CS003";
        public const string CS003_MESSAGE = "Required parameter is empty or null";

        /// <summary>
        /// CS011: Customer not found
        /// </summary>
        public const string CS011 = "CS011";
        public const string CS011_MESSAGE = "Customer not found or InActive";
        /// <summary>
        /// CS012: CustomerKey is not active
        /// </summary>
        public const string CS012 = "CS012";
        public const string CS012_MESSAGE = "CustomerKey is not active";

        /// <summary>
        /// CS016: AccessPoint not found (Incorrect AccessPointID)
        /// </summary>
        public const string CS016 = "CS016";
        public const string CS016_MESSAGE = "AccessPoint not found (Incorrect AccessPointID)";
        /// <summary>
        /// CS017: AccessPoint is not active
        /// </summary>
        public const string CS017 = "CS017";
        public const string CS017_MESSAGE = "AccessPoint is not active";
        /// <summary>
        /// CS018: AccessPoint is not connected
        /// </summary>
        public const string CS018 = "CS018";
        public const string CS018_MESSAGE = "AccessPoint is not connected";

        /// <summary>
        /// CS031: Server not found or not responding
        /// </summary>
        public const string CS031 = "CS031";
        public const string CS031_MESSAGE = "Server not found or not responding";
        /// <summary>
        /// CS035: Unexpected system error (messaging server)
        /// </summary>
        public const string CS035 = "CS035";
        public const string CS035_MESSAGE = "Unexpected system error (messaging server)";
        /// <summary>
        /// CS036: Capture data not found
        /// </summary>
        public const string CS036 = "CS036";
        public const string CS036_MESSAGE = "Capture data not found";
        /// <summary>
        /// CS041: System Error
        /// </summary>
        public const string CS041 = "CS041";
        public const string CS041_MESSAGE = "Unexpected system error";
        /// <summary>
        /// CS057: Cancel Capture
        /// </summary>
        public const string CS057 = "CS057";
        public const string CS057_MESSAGE = "Cancel Capture";
        /// <summary>
        /// CS059: Biometric capture program not found
        /// </summary>
        public const string CS059 = "CS059";
        public const string CS059_MESSAGE = "Biometric capture program not found";
        /// <summary>
        /// CS061: Capture process timed out
        /// </summary>
        public const string CS061 = "CS061";
        public const string CS061_MESSAGE = "Capture process timed out";
        /// <summary>
        /// CS063: Face image not found or empty
        /// </summary>
        public const string CS063 = "CS063";
        public const string CS063_MESSAGE = "Face image not found or empty";
        /// <summary>
        /// CS076: FaceImage license not available
        /// </summary>
        public const string CS076 = "CS076";
        public const string CS076_MESSAGE = "FaceImage license not available";
        /// <summary>
        /// CS079: Biometric Image license not available
        /// </summary>
        public const string CS079 = "CS079";
        public const string CS079_MESSAGE = "Biometric Image license not available";
		
					
