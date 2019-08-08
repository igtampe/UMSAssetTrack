<%@ Page Title="Login" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.vb" Inherits="UMSAssetTrack.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="width:100%">
        <div class="jumbotron" style="width:50%; margin: 0 auto; text-align:center; background-color:lightgray">
            <img src="Content/umsweb.png" alt="UMSAT Logo" style="width:100px;height:100px">
            <br><br>
            <p class="lead">Log in with the UMSWEB</p><br />

            <div style="font-family:monospace">
                <table style="width:25%; margin:0 auto">
                    <tr>
                        <td style="vertical-align:central;text-align:right">ID:</td>
                        <td style="vertical-align:central"><asp:TextBox ID="LogonID" runat="server" Width="100px" MaxLength="5" ToolTip="Your UMSWEB ID"></asp:TextBox><br /></td>
                    </tr>
                    <tr>
                        <td style="vertical-align:central;text-align:right">PIN:</td>
                        <td style="vertical-align:central"><asp:TextBox ID="LogonPin" runat="server" Width="100px" MaxLength="4" TabIndex="1" TextMode="Password" ToolTip="Your UMSWEB Pin"></asp:TextBox> <br /></td>
                    </tr>

                </table>
                <br />

            </div>
            
                <asp:Button ID="LogonBTN" runat="server" Width="200px" CssClass="btn btn-primary btn-lg" Text="Logon" TabIndex="2" ToolTip="Click this to login you bobo" />
                
            <br />
                
            <br />
            <asp:Panel ID="NotifPanel" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Height="75px" style="margin-bottom: 0px" Visible="False">
                <div class="text-center" style="height:75px">
                    <strong>NOTE<br /> </strong>
                    <asp:Label ID="NotifLabel" runat="server" Text="The notification sub seems to have been sent an incorrect value!"></asp:Label>
                    <strong>
				<br />
				    </strong>
                </div>
            </asp:Panel>
                
    </div>
    
    </div>
</asp:Content>
