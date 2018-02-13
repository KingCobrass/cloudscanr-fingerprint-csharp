<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudScanrHome.aspx.cs" Inherits="StandAloneCloudScanrSampleWebApp.CloudScanrHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome To CloudScanr web application</title>
    <script type="text/javascript">

        function openPopup() {


            var w = 850;
            var h = 350;

            // Fixes dual-screen position                         Most browsers      Firefox
            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ResetAccessPointIDCustomerrKey.aspx", "Reset AccessPointID", 'scrollbars=no, resizable=false, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            // Puts focus on the newWindow
            if (window.focus) {
                newWindow.focus();
            }

        }
        //<![CDATA[    
        //
    </script>
</head>
<body style="background-color: ButtonHighlight">
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div>

            <br />
            <br />
            <br />
            <br />
            <br />

            <br />
            <table cellpadding="3px" cellspacing="0" align="center">
                <tr>
                    <td class="pagetitle" style="font-size: larger"><b>Welcome To M2SYS CloudScanr Web Application</b></td>
                </tr>

                <tr>
                    <td style="font-size: larger">
                        <asp:LinkButton ID="lnkBioCapture" runat="server" OnClick="lnkFingerPrintBioCapture_Click">Capture</asp:LinkButton></td>
                </tr>
                <tr>
                    <td style="font-size: larger">
                        <asp:LinkButton ID="linkAuthenticate" runat="server" OnClick="lnkAuthenticate_Click">Re-Authenticate</asp:LinkButton></td>
                </tr>
                <tr>
                    <td style="font-size: larger">
                        <asp:LinkButton ID="linkResetAccessPointID" runat="server" OnClientClick="return openPopup()">Reset AccessPointID & CustomerKey</asp:LinkButton></td>
                </tr>

                <tr>
                    <td style="font-size: larger">
                        <asp:Label ID="lblStatus" runat="server" Visible="true" Text="CloudScanr: "></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

    </form>

</body>
</html>
