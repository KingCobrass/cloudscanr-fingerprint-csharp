using StandAloneCloudScanrSampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StandAloneCloudScanrSampleWebApp.Utilities
{
    public class SessionManager
    {
       
        public static CloudScanrModels.CloudScanrAuthenticate CloudScanrAuthenticate
        {
            get { return (CloudScanrModels.CloudScanrAuthenticate)HttpContext.Current.Session["CloudScanrAuthenticate"]; }
            set { HttpContext.Current.Session["CloudScanrAuthenticate"] = value; }
        }
        public static string CloudScanrAPIToken
        {
            get { return (string)HttpContext.Current.Session["CloudScanrAPIToken"]; }
            set { HttpContext.Current.Session["CloudScanrAPIToken"] = value; }
        }
    }

}