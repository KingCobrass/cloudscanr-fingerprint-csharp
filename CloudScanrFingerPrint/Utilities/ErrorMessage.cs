using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StandAloneCloudScanrSampleWebApp.Utilities
{
    public class ErrorMessage
    {
        #region CloudScanr API general error code
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
        #endregion
    }
}