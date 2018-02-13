<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetAccessPointIDCustomerrKey.aspx.cs" Inherits="StandAloneCloudScanrSampleWebApp.ResetAccessPointIDCustomerrKey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset AccessPointID</title>
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
    </style>
</head>
<body style="background-color: ButtonHighlight">
    <form id="form1" runat="server">
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
                                    <td class="auto-style1">AccessPointID
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAccessPointID" Width="276px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td>
                                        <asp:Button  ID="btnSetAccessPointID" runat="server" Text="Update AccessPointID" Enabled="true" OnClick="btnSetAccessPointID_Click" Height="40px" Width="253px" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </div>
        <br />

        <div>

            <table cellpadding="0px" cellspacing="0px" align="center">
                <tr>

                    <td>
                        <fieldset style="width: 350px;">
                            <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />
                            &nbsp;<asp:Label ID="lblMessage" runat="server" Text="..."></asp:Label>
                        </fieldset>
                    </td>

                </tr>
            </table>


        </div>

    </form>
</body>
</html>
