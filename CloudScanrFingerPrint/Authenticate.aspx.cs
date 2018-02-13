using StandAloneCloudScanrSampleWebApp.Models;
using StandAloneCloudScanrSampleWebApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StandAloneCloudScanrSampleWebApp
{
    public partial class Authenticate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Clear session
            SessionManager.CloudScanrAuthenticate = null;
            SessionManager.CloudScanrAPIToken = string.Empty;
            lblMessage.Text = "Current AccessPointID::" + GetAccessPointID();

        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CloudScanrHome.aspx");
        }

        protected void btnGetAuthenticate_Click(object sender, EventArgs e)
        {
            try
            {

                lblMessage.Text = "Start CloudScanr authenticating...";
                if (!string.IsNullOrEmpty(txtAppKey.Text.Trim().ToString())
                    && !string.IsNullOrEmpty(txtAppSecret.Text.Trim().ToString())
                    && !string.IsNullOrEmpty(txtCustomerKey.Text.Trim().ToString())
                    &&!string.IsNullOrEmpty(txtAccessPointID.Text.Trim().ToString()))
                {
                    CloudScanrModels.CloudScanrAuthenticate cloudscanrAuth = new CloudScanrModels.CloudScanrAuthenticate();
                    cloudscanrAuth.CustomerKey = txtCustomerKey.Text.Trim().ToString();
                    cloudscanrAuth.AppKey = txtAppKey.Text.Trim().ToString();
                    cloudscanrAuth.AppSecret = txtAppSecret.Text.Trim().ToString();
                    //cloudscanrAuth.AccessPointID = txtAccessPointID.Text.Trim().ToString();
                    DeleteAccessPointInfo();
                    SetAccessPointID(txtAccessPointID.Text.Trim().ToString());
                    SessionManager.CloudScanrAuthenticate = cloudscanrAuth;
                    if(ApiAuthenticate())
                    {
                        if (Response.IsClientConnected)
                            //Redirect to default page
                            Response.Redirect("CloudScanrHome.aspx", false);
                        else Response.End();
                    }
                    
                }
                else if (string.IsNullOrEmpty(txtAppKey.Text.Trim())) lblMessage.Text = "Please give app key";
                else if (string.IsNullOrEmpty(txtAppSecret.Text.Trim())) lblMessage.Text = "Please give app secret";
                else if (string.IsNullOrEmpty(txtAccessPointID.Text.Trim()) && string.IsNullOrEmpty(GetAccessPointID())) lblMessage.Text = "Please give access point id";
                else if (string.IsNullOrEmpty(txtCustomerKey.Text.Trim())) lblMessage.Text = "Please give customer key";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        private void DeleteAccessPointInfo()
        {
            if (Request.Cookies[AppSettingsReader.AccessPoint_Cookie_Key] != null)
            {
                Response.Cookies[AppSettingsReader.AccessPoint_Cookie_Key].Expires = DateTime.Now.AddDays(-1);
            }
        }
        private bool SetAccessPointID(string accessPointID)
        {
            HttpCookie csCookies = new HttpCookie(AppSettingsReader.AccessPoint_Cookie_Key);
            csCookies.Value = accessPointID;
            csCookies.Expires = DateTime.Now.AddDays(100);
            Response.Cookies.Add(csCookies);
            return true;
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
        private bool ApiAuthenticate()
        {
            try
            {
              

                CloudScanrApiManager.ApiHelper apiHelper = new CloudScanrApiManager.ApiHelper(AppSettingsReader.CloudScanr_API);
                CloudScanrModels.CSTokenModel csTokenModel = apiHelper.GetToken(SessionManager.CloudScanrAuthenticate.AppKey, SessionManager.CloudScanrAuthenticate.AppSecret);
                if (string.IsNullOrEmpty(csTokenModel.Error) && string.IsNullOrEmpty(csTokenModel.ErrorDescription) && !string.IsNullOrEmpty(csTokenModel.AccessToken))
                {
                    SessionManager.CloudScanrAPIToken = csTokenModel.AccessToken;

                    return true;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "CloudScanr Authentication failed:: Error: " + csTokenModel.Error + " Error_Desc::" + csTokenModel.ErrorDescription;
                }

            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
            return false;
        }
    }
}