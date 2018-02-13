using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Web;
using System.Xml;

namespace StandAloneCloudScanrSampleWebApp.Utilities
{
    public class Utils
    {
        public static string ParseCloudScanrAPIErrorMessage(string errorCode)
        {
            string errorMessage = string.Empty;
            switch (errorCode)
            {
                case ErrorMessage.CS003:
                    errorMessage = ErrorMessage.CS003_MESSAGE;
                    break;

                case ErrorMessage.CS011:
                    errorMessage = ErrorMessage.CS011_MESSAGE;
                    break;
                case ErrorMessage.CS012:
                    errorMessage = ErrorMessage.CS012_MESSAGE;
                    break;
                case ErrorMessage.CS016:
                    errorMessage = ErrorMessage.CS016_MESSAGE;
                    break;
                case ErrorMessage.CS017:
                    errorMessage = ErrorMessage.CS017_MESSAGE;
                    break;
                case ErrorMessage.CS018:
                    errorMessage = ErrorMessage.CS018_MESSAGE;
                    break;

                case ErrorMessage.CS031:
                    errorMessage = ErrorMessage.CS031_MESSAGE;
                    break;
                case ErrorMessage.CS035:
                    errorMessage = ErrorMessage.CS035_MESSAGE;
                    break;
                case ErrorMessage.CS036:
                    errorMessage = ErrorMessage.CS036_MESSAGE;
                    break;
                case ErrorMessage.CS041:
                    errorMessage = ErrorMessage.CS041_MESSAGE;
                    break;

                case ErrorMessage.CS057:
                    errorMessage = ErrorMessage.CS057_MESSAGE;
                    break;
                case ErrorMessage.CS059:
                    errorMessage = ErrorMessage.CS059_MESSAGE;
                    break;
                case ErrorMessage.CS061:
                    errorMessage = ErrorMessage.CS061_MESSAGE;
                    break;
                case ErrorMessage.CS063:
                    errorMessage = ErrorMessage.CS063_MESSAGE;
                    break;
                case ErrorMessage.CS076:
                    errorMessage = ErrorMessage.CS076_MESSAGE;
                    break;
                case ErrorMessage.CS079:
                    errorMessage = ErrorMessage.CS079_MESSAGE;
                    break;
                default:
                    errorMessage = errorCode;
                    break;
            }
            return errorMessage;

        }
        public static void ParserImageXML(string xmlBioImageData, out string leftImage, out int fingerPos)
        {
            leftImage = string.Empty;
            fingerPos = 0;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlBioImageData);

                XmlNode node = xmlDoc.SelectSingleNode("BioMetricImage");
                if (node != null && node.HasChildNodes)
                {
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if (childNode.Name.Equals("Image"))
                        {
                            fingerPos = Convert.ToInt16(childNode.Attributes["FingerPosition"].Value.ToString());
                            leftImage = childNode.InnerText.ToString();
                            break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ParserImageXML(string xmlBioImageData, out string leftImage, out int leftFingerPos, out string rightImage, out int rightFingerPos)
        {
            leftImage = string.Empty;
            rightImage = string.Empty;
            leftFingerPos = 0;
            rightFingerPos = 0;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlBioImageData);

                XmlNode node = xmlDoc.SelectSingleNode("BioMetricImage");
                if (node != null && node.HasChildNodes)
                {
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if (childNode.Name.Equals("LeftImage"))
                        {
                            leftFingerPos = Convert.ToInt16(childNode.Attributes["FingerPosition"].Value.ToString());
                            leftImage = childNode.InnerText.ToString();
                        }
                        else if (childNode.Name.Equals("RightImage"))
                        {
                            rightFingerPos = Convert.ToInt16(childNode.Attributes["FingerPosition"].Value.ToString());
                            rightImage = childNode.InnerText.ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public static bool GrantAccess(string fullPath)
        {
            try
            {

                DirectoryInfo dInfo = new DirectoryInfo(fullPath);
                DirectorySecurity dSecurity = dInfo.GetAccessControl();
                dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                    FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                    PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                dInfo.SetAccessControl(dSecurity);
                return true;
            }
            catch (Exception ex)
            {
                throw;
                //ShowMessage(ex.Message + "\nPath: " + fullPath, "GrantAccess");
                //return false;
            }
            return false;
        }


    }
}