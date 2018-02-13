<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authenticate.aspx.cs" Inherits="StandAloneCloudScanrSampleWebApp.Authenticate" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>CloudScanr Authenticate
    </title>
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
                                    <td class="auto-style1">AppKey
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAppKey" Width="276px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">AppSecret
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAppSecret" Width="276px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">AccessPointID
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAccessPointID" Width="276px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">CustomerKey
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCustomerKey" Width="276px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnGetAuthenticate" runat="server" Text="Get Authenticate" Enabled="true" OnClick="btnGetAuthenticate_Click" Height="40px" Width="155px" />
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
                            <asp:Button ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />
                            &nbsp;<asp:Label ID="lblMessage" runat="server" Text="..."></asp:Label>
                        </fieldset>
                    </td>

                </tr>
            </table>


        </div>

    </form>
</body>
</html>

