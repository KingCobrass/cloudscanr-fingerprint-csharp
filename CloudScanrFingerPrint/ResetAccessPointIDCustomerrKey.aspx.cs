using StandAloneCloudScanrSampleWebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StandAloneCloudScanrSampleWebApp
{
    public partial class ResetAccessPointIDCustomerrKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.CloudScanrAuthenticate != null)
                {
                    txtAccessPointID.Text = GetAccessPointID();
                }

                else Response.Redirect("Authenticate.aspx");
            }
        }

        private void DeleteAccessPointInfo()
        {
            if (Request.Cookies[AppSettingsReader.AccessPoint_Cookie_Key] != null)
            {
                Response.Cookies[AppSettingsReader.AccessPoint_Cookie_Key].Expires = DateTime.Now.AddDays(-1);
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
        private bool SetAccessPointID(string accessPointID)
        {
            HttpCookie StudentCookies = new HttpCookie(AppSettingsReader.AccessPoint_Cookie_Key);
            StudentCookies.Value = accessPointID;
            StudentCookies.Expires = DateTime.Now.AddDays(100);
            Response.Cookies.Add(StudentCookies);
            return true;
        }

        protected void btnSetAccessPointID_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAccessPointID.Text.Trim().ToString()))
            {
                DeleteAccessPointInfo();
                SetAccessPointID(txtAccessPointID.Text.Trim().ToString());
                Response.Write("<script language='javascript'> { self.close() }</script>");
            }
            else lblMessage.Text = "Please put Access Point ID";

        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { self.close() }</script>");
        }
    }
}