using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StandAloneCloudScanrSampleWebApp.Models
{

    public enum EnumCaptureType
    {
        SingleCapture = 0,
        DoubleCapture = 1
    }
    public enum SingleCaptureMode
    {
        LeftFingerCapture = 0,
        RightFingerCapture = 1
    }
    public enum TemplateFormat
    {
        ISO = 0,
        ICS = 1,
        M2ICS = 2
    }
    public enum EnumCaptureMode
    {
        TemplateOnly = 0,
        TemplateWithImage = 1,
        ImageOnly = 2

    }
    public enum EnumBiometricImageFormat
    {
        PNG = 0,
        JPEG = 1,
        TIFF = 2,
        BMP = 3,
        GIF = 4,
        JPEG2000 = 5,
        WSQ = 6
    }
    public enum EnumFeatureMode
    {
        Disable = 0,
        Enable = 1
    }
    public class CloudScanrModels
    {

        /// <summary>
        /// Contains CloudScanr Capture Result
        /// </summary>
        public class CloudScanrCaptureResult : Common
        {
            /// <summary>
            /// Captured biometric template data in XML format. (Template data itself is Base64 encoded within XML message.)
            /// </summary>
            public string TemplateData { get; set; }
            /// <summary>
            /// Captured biometric image data in XML format. (Image data itself is Base64 encoded within XML message.)
            /// </summary>
            public string BioImageData { get; set; }
            /// <summary>
            /// Captured face image data. (Face image data itself is Base64 encoded.).Default face image format is JPEG
            /// </summary>
            public string FaceImageData { get; set; }


        }
        /// <summary>
        /// 
        /// </summary>
        public class Common
        {
            /// <summary>
            /// Common message
            /// </summary>
            public Common()
            {
                Success = false;
                Message = string.Empty;
                ResponseCode = string.Empty;
            }
            /// <summary>
            /// Request status. true/false
            /// </summary>
            public bool Success;
            /// <summary>
            /// Contains exception message if any authenticate issues raised, like unauthorised api calling or token has expired.
            /// </summary>
            public string Message;
            /// <summary>
            /// This value contains CloudScanr error code if any error occurred, otherwise this value will contain an empty string.
            /// </summary>
            public string ResponseCode;
        }

        /// <summary>
        /// Capture request object
        /// </summary>
        public class CloudScanrCapture
        {
            /// <summary>
            /// Customer-specific key provided by the vendor.
            /// </summary>
            [Required]
            public string CustomerKey { get; set; }
            /// <summary>
            /// Specifies whether a single biometric capture, or two biometric captures are performed. Default CaptureType is SingleCapture.
            /// </summary>
            public EnumCaptureType CaptureType { get; set; }
            /// <summary>
            /// Specifies whether a left single biometric capture, or right single biometric captures are performed. Default SingleCaptureMode is LeftFingerCapture.
            /// </summary>
            public SingleCaptureMode SingleCaptureMode { get; set; }
            /// <summary>
            /// Specifies quick scan perform or not from the capture process. If this value is enable then everything will be auto mode, ex: user do not need to select finger position, click on start button and submit after successful scane. Default value is Disable.
            /// </summary>
            public EnumFeatureMode QuickScan { get; set; }
            /// <summary>
            /// Format of the generated biometric template. Default format is ISO.
            /// </summary>
            public TemplateFormat TemplateFormat { get; set; }
            /// <summary>
            /// Format of the generated biometric image. Default format is WSQ.
            /// </summary>
            public EnumBiometricImageFormat BioMetricImageFormat { get; set; }
            /// <summary>
            /// Uniquely identified the client machine where the CloudScanr application is installed. You can get AccessPointID from CloudScanr system tray icon.
            /// </summary>
            [Required]
            public string AccessPointID { get; set; }
            /// <summary>
            /// Determines whether a biometric template or biometric image (or both) is generated from the capture process. Default value is TemplateOnly.
            /// </summary>
            public EnumCaptureMode CaptureMode { get; set; }
            /// <summary>
            /// How long (in seconds) CloudScanr client app waits for successful capture from biometric device. Default value is 120 seconds.
            /// </summary>
            public double CaptureTimeOut { get; set; }
            /// <summary>
            /// Specifies face image captured perform or not from the capture process. Default value is Disable.
            /// </summary>
            public EnumFeatureMode FaceImage { get; set; }
        }
        public class CloudScanrAuthenticate
        {
            [Required(ErrorMessage = "Customer Key Required")]
            public string CustomerKey { get; set; }
            [Required(ErrorMessage = "App Key Required")]
            public string AppKey { get; set; }
            [Required(ErrorMessage = "AppSecret Required")]
            public string AppSecret { get; set; }

        }
        public class CSTokenModel
        {

            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }
            [JsonProperty("token_type")]
            public string TokenType { get; set; }
            [JsonProperty("error")]
            public string Error { get; set; }
            [JsonProperty("error_description")]
            public string ErrorDescription { get; set; }
        }
    }
}