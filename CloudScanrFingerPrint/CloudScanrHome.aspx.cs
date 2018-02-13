using StandAloneCloudScanrSampleWebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StandAloneCloudScanrSampleWebApp
{
    public partial class CloudScanrHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadApiToken();
            }

        }

        private void LoadApiToken()
        {
            try
            {
                if (string.IsNullOrEmpty(SessionManager.CloudScanrAPIToken) || SessionManager.CloudScanrAuthenticate == null ||  string.IsNullOrEmpty(GetAccessPointID()))
                {
                    Response.Redirect("Authenticate.aspx");
                }
                else lblStatus.Text = "CloudScanr Server Status:: everything is okay";

            }
            catch (Exception ex)
            {
                lblStatus.Text = "CloudScanr Server Status:: Check API Address, Error: " + ex.Message; ;
            }
        }
        private string GetAccessPointID()
        {
            try
            {
                return Request.Cookies[AppSettingsReader.AccessPoint_Cookie_Key].Value;
            }
            catch (Exception)
            {

                return null;
            }
        }
        protected void lnkFingerPrintBioCapture_Click(object sender, EventArgs e)
        {
            Response.Redirect("CloudScanrCapture.aspx");
        }
        protected void lnkAuthenticate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Authenticate.aspx");
        }
    }
}