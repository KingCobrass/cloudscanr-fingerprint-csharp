using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace StandAloneCloudScanrSampleWebApp.Utilities
{
    public class AppSettingsReader
    {

        /// <summary>
        /// 
        /// </summary>
        public static string CloudScanr_API
        {
            get { return ReadMyConfig("CloudScanr_API"); }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string AccessPoint_Cookie_Key
        {
            get { return ReadMyConfig("AccessPoint_Cookie_Key"); }
        }
        /// <summary>
        /// IsCaptured_Bio_XML_Store
        /// </summary>
        public static bool IsCaptured_Bio_XML_Store()
        {
            try
            {
                string isEnable = ReadMyConfig("Captured_Bio_XML_Store");
                if (isEnable.ToUpper().Equals("ENABLE")) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Captured_Bio_XML_Store_Path
        /// </summary>
        public static string Captured_Bio_XML_Store_Path
        {
            get { return ReadMyConfig("Captured_Bio_XML_Store_Path"); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static double Capture_TimeOut()
        {
            double captureTimeOut = 120;
            try
            {
                string timeOut = ReadMyConfig("Capture_TimeOut");
                double.TryParse(timeOut, out captureTimeOut);
                return captureTimeOut;
            }
            catch (Exception)
            {

                return captureTimeOut;
            }
        }
        /// <summary>
        /// Read application cofig value using the key
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        internal static string ReadMyConfig(string strKey)
        {
            try
            {
                return !string.IsNullOrEmpty(ConfigurationSettings.AppSettings[strKey]) ? ConfigurationSettings.AppSettings[strKey] : string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}