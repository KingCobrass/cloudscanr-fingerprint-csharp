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
    public partial class CloudScanrCapture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (string.IsNullOrEmpty(SessionManager.CloudScanrAPIToken) || SessionManager.CloudScanrAuthenticate == null || string.IsNullOrEmpty(GetAccessPointID())) Response.Redirect("Authenticate.aspx");
                    else
                    {
                        LoadBioWith();
                        LoadTemplateFormat();
                        LoadBioImageFormat();
                        LoadcaptureType();
                        LoadFaceImageFeature();
                        LoadSingleCaptureMode();
                        LoadQuickScanFeature();
                        captureMode.SelectedIndex = 0;
                        templateFormat.SelectedIndex = 0;
                        bioImageFormat.SelectedIndex = 6;
                        captureType.SelectedIndex = 0;
                        singleCaptureMode.SelectedIndex = 0;
                        faceImage.SelectedIndex = 1;
                        quickScan.SelectedIndex = 1;

                        lblCurrentAccessPointID.Text = GetAccessPointID();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "From Session Veriable:: " + ex.Message;
                }

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
        private void LoadBioWith()
        {

            captureMode.Items.Add(new ListItem(EnumCaptureMode.TemplateOnly.ToString(), EnumCaptureMode.TemplateOnly.ToString()));
            captureMode.Items.Add(new ListItem(EnumCaptureMode.TemplateWithImage.ToString(), EnumCaptureMode.TemplateWithImage.ToString()));
            captureMode.Items.Add(new ListItem(EnumCaptureMode.ImageOnly.ToString(), EnumCaptureMode.ImageOnly.ToString()));


        }
        private void LoadcaptureType()
        {

            captureType.Items.Add(new ListItem(EnumCaptureType.SingleCapture.ToString(), EnumCaptureType.SingleCapture.ToString()));
            captureType.Items.Add(new ListItem(EnumCaptureType.DoubleCapture.ToString(), EnumCaptureType.DoubleCapture.ToString()));
        }
        private void LoadFaceImageFeature()
        {

            faceImage.Items.Add(new ListItem(EnumFeatureMode.Enable.ToString(), EnumFeatureMode.Enable.ToString()));
            faceImage.Items.Add(new ListItem(EnumFeatureMode.Disable.ToString(), EnumFeatureMode.Disable.ToString()));
        }
        private void LoadQuickScanFeature()
        {

            quickScan.Items.Add(new ListItem(EnumFeatureMode.Enable.ToString(), EnumFeatureMode.Enable.ToString()));
            quickScan.Items.Add(new ListItem(EnumFeatureMode.Disable.ToString(), EnumFeatureMode.Disable.ToString()));
        }
        private void LoadSingleCaptureMode()
        {

            singleCaptureMode.Items.Add(new ListItem(SingleCaptureMode.LeftFingerCapture.ToString(), SingleCaptureMode.LeftFingerCapture.ToString()));
            singleCaptureMode.Items.Add(new ListItem(SingleCaptureMode.RightFingerCapture.ToString(), SingleCaptureMode.RightFingerCapture.ToString()));
        }
        private void LoadTemplateFormat()
        {

            templateFormat.Items.Add(new ListItem(TemplateFormat.ISO.ToString(), TemplateFormat.ISO.ToString()));
            templateFormat.Items.Add(new ListItem(TemplateFormat.ICS.ToString(), TemplateFormat.ICS.ToString()));
            templateFormat.Items.Add(new ListItem(TemplateFormat.M2ICS.ToString(), TemplateFormat.M2ICS.ToString()));


        }
        private void LoadBioImageFormat()
        {
            bioImageFormat.Items.Add(new ListItem(EnumBiometricImageFormat.WSQ.ToString(), EnumBiometricImageFormat.WSQ.ToString()));
            bioImageFormat.Items.Add(new ListItem(EnumBiometricImageFormat.BMP.ToString(), EnumBiometricImageFormat.BMP.ToString()));
            bioImageFormat.Items.Add(new ListItem(EnumBiometricImageFormat.GIF.ToString(), EnumBiometricImageFormat.GIF.ToString()));
            bioImageFormat.Items.Add(new ListItem(EnumBiometricImageFormat.JPEG.ToString(), EnumBiometricImageFormat.JPEG.ToString()));
            bioImageFormat.Items.Add(new ListItem(EnumBiometricImageFormat.PNG.ToString(), EnumBiometricImageFormat.PNG.ToString()));
            bioImageFormat.Items.Add(new ListItem(EnumBiometricImageFormat.TIFF.ToString(), EnumBiometricImageFormat.TIFF.ToString()));


        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CloudScanrHome.aspx");
        }


        protected void btnBioCapture_Click(object sender, EventArgs e)
        {
            try
            {
                ResetAll();
                lblMessage.Text = "Start biometric capture...";

                CloudScanrModels.CloudScanrCapture cloudScanrparam = new CloudScanrModels.CloudScanrCapture();
                cloudScanrparam.CustomerKey = SessionManager.CloudScanrAuthenticate.CustomerKey;
                cloudScanrparam.AccessPointID = GetAccessPointID();//SessionManager.CloudScanrAuthenticate.AccessPointID;
                cloudScanrparam.CaptureTimeOut = AppSettingsReader.Capture_TimeOut();//120.0;
                cloudScanrparam.CaptureMode = (EnumCaptureMode)Enum.Parse(typeof(EnumCaptureMode), captureMode.SelectedItem.Value.ToString());
                cloudScanrparam.TemplateFormat = (TemplateFormat)Enum.Parse(typeof(TemplateFormat), templateFormat.SelectedItem.Value.ToString());
                cloudScanrparam.BioMetricImageFormat = (EnumBiometricImageFormat)Enum.Parse(typeof(EnumBiometricImageFormat), bioImageFormat.SelectedItem.Value.ToString());
                cloudScanrparam.CaptureType = (EnumCaptureType)Enum.Parse(typeof(EnumCaptureType), captureType.SelectedItem.Value.ToString());
                cloudScanrparam.SingleCaptureMode = (SingleCaptureMode)Enum.Parse(typeof(SingleCaptureMode), singleCaptureMode.SelectedItem.Value.ToString());
                cloudScanrparam.FaceImage = (EnumFeatureMode)Enum.Parse(typeof(EnumFeatureMode), faceImage.SelectedItem.Value.ToString());
                cloudScanrparam.QuickScan = (EnumFeatureMode)Enum.Parse(typeof(EnumFeatureMode), quickScan.SelectedItem.Value.ToString());

                FingerPrintCapture(cloudScanrparam);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "From button click:: " + ex.Message;
            }
        }

        private void ResetAll()
        {
            lblTemplate.Visible = false;
            templateXML.Text = "";
            templateXML.Visible = false;

            imageXML.Text = "";
            imageXML.Visible = false;

            lblBioImage.Visible = false;

            lblFaceImageData.Visible = false;
            imgFaceImage.Visible = false;
            txtFaceImageData.Text = "";
            txtFaceImageData.Visible = false;

            fileStaveStatus.Visible = false;

        }

        private void FingerPrintCapture(CloudScanrModels.CloudScanrCapture cloudScanrparam)
        {
            try
            {
                CloudScanrApiManager.ApiHelper apiHelper = new CloudScanrApiManager.ApiHelper(AppSettingsReader.CloudScanr_API);
                CloudScanrModels.CloudScanrCaptureResult transactionInfo = new CloudScanrModels.CloudScanrCaptureResult();

                transactionInfo = apiHelper.Capture(cloudScanrparam, SessionManager.CloudScanrAPIToken);

                PraseResult(transactionInfo, cloudScanrparam);
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "From API Calling:: " + ex.Message;
            }
        }

        private void PraseResult(CloudScanrModels.CloudScanrCaptureResult cloudScanrCaptureResult, CloudScanrModels.CloudScanrCapture cloudScanrparam)
        {


            try
            {
                if (!cloudScanrCaptureResult.Success && !string.IsNullOrEmpty(cloudScanrCaptureResult.ResponseCode))
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = Utils.ParseCloudScanrAPIErrorMessage(cloudScanrCaptureResult.ResponseCode);
                }

                else if (!cloudScanrCaptureResult.Success && !string.IsNullOrEmpty(cloudScanrCaptureResult.Message))
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = cloudScanrCaptureResult.Message;
                }
                else
                {
                    if (!string.IsNullOrEmpty(cloudScanrCaptureResult.TemplateData))
                    {
                        lblMessage.Text = "Capture completed";
                        lblTemplate.Visible = true;
                        templateXML.Visible = true;
                        templateXML.Text = cloudScanrCaptureResult.TemplateData;
                    }
                    if (!string.IsNullOrEmpty(cloudScanrCaptureResult.BioImageData))
                    {
                        lblBioImage.Visible = true;
                        imageXML.Visible = true;
                        imageXML.Text = cloudScanrCaptureResult.BioImageData;
                    }
                    if (!string.IsNullOrEmpty(cloudScanrCaptureResult.FaceImageData))
                    {
                        lblFaceImageData.Visible = true;
                        txtFaceImageData.Visible = true;

                        imgFaceImage.Visible = true;
                        imgFaceImage.ImageUrl = "data:image/jpeg;base64," + cloudScanrCaptureResult.FaceImageData;

                        txtFaceImageData.Text = cloudScanrCaptureResult.FaceImageData;
                    }

                }
            }
            catch (Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }

        }

    }
}