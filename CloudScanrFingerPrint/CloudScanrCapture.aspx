<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudScanrCapture.aspx.cs" Inherits="StandAloneCloudScanrSampleWebApp.CloudScanrCapture" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>BioMetric Capture</title>
    <link rel="Stylesheet" type="text/css" href="style.css" />


    <style type="text/css">
        .auto-style1 {
            width: 157px;
        }

        .auto-style2 {
            width: 471px;
        }

        .auto-style3 {
            width: 376px;
        }

        .centerBlock {
            margin-left: auto;
            margin-right: auto;
            width: 576px;
        }
    </style>


</head>
<body style="background-color: ButtonHighlight">
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div>
            <table cellpadding="0px" cellspacing="0px" align="center">

                <tr>
                    <td class="auto-style3">
                        <fieldset style="width: 350px;">

                            <table cellpadding="3px" cellspacing="0">
                                <tr>
                                    <td class="auto-style1">CaptureMode
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="captureMode" runat="server" AppendDataBoundItems="true" Height="25px" Width="278px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">TemplateFormat
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="templateFormat" runat="server" AppendDataBoundItems="true" Height="25px" Width="278px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">BioImageFormat
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="bioImageFormat" runat="server" AppendDataBoundItems="true" Height="25px" Width="278px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">CaptureType
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="captureType" runat="server" AppendDataBoundItems="true" Height="25px" Width="278px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">SingleCaptureMode
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="singleCaptureMode" runat="server" AppendDataBoundItems="true" Height="25px" Width="278px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">QuickScan
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="quickScan" runat="server" AppendDataBoundItems="true" Height="25px" Width="278px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">FaceImage
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="faceImage" runat="server" AppendDataBoundItems="true" Height="25px" Width="278px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Current AccessPointID
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentAccessPointID" runat="server" Text="..."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnBioCapture" runat="server" Text="BioMetricCapture" Enabled="true" OnClick="btnBioCapture_Click" Height="40px" Width="155px" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <div class="centerBlock">
            <tr>
                <td class="auto-style3">

                    <table cellpadding="3px" cellspacing="0">
                        <br>
                        <asp:Label ID="lblFaceImageData" runat="server" CssClass="pagetitleValue" Visible="false" Text="Face Image Data"></asp:Label>
                        <br />
                        <asp:Image ID="imgFaceImage" runat="server" Visible="false" />
                        <asp:TextBox ID="txtFaceImageData" runat="server" CssClass="pagetitleValue" Visible="false" TextMode="MultiLine" Text="" Height="363px" Width="663px"></asp:TextBox>

                    </table>
                </td>
            </tr>
            <tr>
                <br>
                <asp:Label ID="lblTemplate" runat="server" CssClass="pagetitleValue" Visible="false" Text="Template"></asp:Label>
                <br />

                <asp:TextBox ID="templateXML" runat="server" CssClass="pagetitleValue" Visible="false" TextMode="MultiLine" Text="" Height="263px" Width="663px"></asp:TextBox>
            </tr>
            <tr>
                <br />
                <asp:Label ID="lblBioImage" runat="server" CssClass="pagetitleValue" Visible="false" Text="BioMetric Image"></asp:Label>

                <br />

                <asp:TextBox ID="imageXML" runat="server" CssClass="pagetitleValue" Visible="false" TextMode="MultiLine" Text="" Height="563px" Width="663px"></asp:TextBox>

                <br />
            </tr>
        </div>
        <div>

            <table cellpadding="0px" cellspacing="0px" align="center">
                <tr>

                    <td>
                        <fieldset style="width: 350px;">
                            <asp:Button ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />
                            &nbsp;<asp:Label ID="lblMessage" runat="server" Text="..."></asp:Label>

                        </fieldset>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:TextBox  width="350px" ID="fileStaveStatus" runat="server" Visible="false" TextMode="MultiLine" Text="Captured Status">

                        </asp:TextBox>
                    </td>
                </tr>

            </table>
        </div>

    </form>
</body>
</html>

