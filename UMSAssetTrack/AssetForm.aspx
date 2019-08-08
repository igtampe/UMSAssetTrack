<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssetForm.aspx.vb" Inherits="UMSAssetTrack.AssetForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="width:100%">
        <h1 style="text-align:center"> <b> <asp:Label runat="server" ID="FormTitle" Text="ASSET CREATION FORM"></asp:Label> </b></h1>
        <h6 style="text-align:center"> <i> Please fill out this form and we'll do what you need us to do</i></h6>

        <hr />

        <table align=center>

            <tr>
                <td style="font-size:50px;width:50px;height:50px;text-align:center;vertical-align:center"><asp:Label runat="server" ID="AssetID" Text="1"/></td>
                <td colspan="4"><b><asp:textbox runat="server" ID="AssetNametextbox" Text="ITEM NAME" Width="600px"/></b></td>
                
            </tr>
        
        </table>
            

                <table align=center>
            <tr>
                <td style="width:100px" class="text-right">Owner:</td>
                <td style="width:125px"><asp:textbox runat="server" ID="Ownertextbox"/></td>
                <td style="width:125px" class="text-right">OwnerID:</td>
                <td style="width:125px"><asp:textbox runat="server" ID="OwnerIDTextbox"/></td>
            </tr>
            
            <tr>
               <td style="width:100px; height: 22px;" class="text-right">District:</td>
                <td style="width:125px; height: 22px;"><asp:textbox runat="server" ID="Districttextbox"/></td>
                <td style="width:125px; height: 22px;" class="text-right">City:</td>
                <td style="width:125px; height: 22px;"><asp:textbox runat="server" ID="CityTextBox"/></td>
            </tr>
            <tr>
               <td style="width:100px" class="text-right">Price:</td>
                <td style="width:125px"><asp:textbox runat="server" ID="Pricetextbox"/></td>
                <td style="width:125px" class="text-right">Total Income:</td>
                <td style="width:125px"><asp:textbox runat="server" ID="Incometextbox"/></td>
            </tr>
            <tr>
                <td class="text-right">Description:</td>
                <td rowspan="2" colspan="3"><asp:textbox runat="server" ID="Statustextbox" Width="500px" Height="100px" TextMode="MultiLine"/></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 31px" class="text-right">Image:</td>
                <td colspan="3" style="height: 31px">
                    <asp:textbox runat="server" ID="ImageURLTextBox" Width="500px" Text="http://igtnet-w.ddns.net:100/databaseimages/blank.png"/>
                </td>
            </tr>
            <tr>
                <td style="height: 31px" class="text-right">Item Type</td>
                <td colspan="3" style="height: 31px">
                <asp:DropDownList runat="server" ID="TypeDropdown" Width="500px">
                    <asp:ListItem>Building</asp:ListItem>
                    <asp:ListItem>House</asp:ListItem>
                    <asp:ListItem>Land</asp:ListItem>
                    <asp:ListItem>Plane</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            </table>
        <br />
        <br />
        <table align=center>
            <tr>
                
                <td style="width:100px" class="text-right">Studio Units:</td>
                <td style="width:25px"><asp:textbox runat="server" ID="SUnitstextbox" Text="0" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">Studio Units:</td>
                <td style="width:50px"><asp:textbox runat="server" ID="SRenttextbox" Text="500" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">Rooms:</td>
                <td style="width:50px"><asp:textbox runat="server" ID="RoomUnittextbox" Text="0" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">Chairs:</td>
                <td style="width:25px"><asp:textbox runat="server" ID="Chairstextbox" Text="0" Width="50px" TextMode="Number"/></td>
                
            </tr>
            <tr>
                <td style="width:100px" class="text-right">1 BR Units:</td>
                <td style="width:25px"><asp:textbox runat="server" ID="BR1Unitstextbox" Text="0" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">1 BR Rent:</td>
                <td style="width:50px"><asp:textbox runat="server" ID="BR1Renttextbox" Text="750" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">Suites:</td>
                <td style="width:50px"><asp:textbox runat="server" ID="SuiteUnitstextbox" Text="0" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">Avg Spending:</td>
                <td style="width:25px"><asp:textbox runat="server" ID="AvgSpendingtextbox" Text="0" Width="50px" TextMode="Number"/></td>
            </tr>
            
            <tr>
               <td style="width:100px" class="text-right">2 BR Units:</td>
                <td style="width:25px"><asp:textbox runat="server" ID="BR2Unitstextbox" Text="0" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">2 BR Rent:</td>
                <td style="width:50px"><asp:textbox runat="server" ID="BR2Renttextbox" Text="1000" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">Room Rate:</td>
                <td style="width:50px"><asp:textbox runat="server" ID="RoomRatetextbox" Text="200" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">Customers/HR:</td>
                <td style="width:25px"><asp:textbox runat="server" ID="CustomersPerHour" Text="0" Width="50px" TextMode="Number"/></td>
            </tr>
            <tr>
               <td style="width:100px" class="text-right">3 BR Units:</td>
                <td style="width:25px"><asp:textbox runat="server" ID="BR3Unitstextbox" Text="0" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">3 BR Rent:</td>
                <td style="width:50px"><asp:textbox runat="server" ID="BR3Renttextbox" Text="1250" Width="50px" TextMode="Number"/></td>
                
                <td style="width:100px" class="text-right">Suite Rate:</td>
                <td style="width:50px"><asp:textbox runat="server" ID="SuiteRatetextbox" Text="400" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">Hours Open:</td>
                <td style="width:25px"><asp:textbox runat="server" ID="HoursOpentextbox" Text="0" Width="50px" TextMode="Number"/></td>
            </tr>
            <tr>
                <td style="width:100px" class="text-right">PH Units:</td>
                <td style="width:25px"><asp:textbox runat="server" ID="PHUnitstextbox" Text="0" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">PH Rent:</td>
                <td style="width:50px"><asp:textbox runat="server" ID="PHRenttextbox" Text="1250" Width="50px" TextMode="Number"/></td>
                <td style="width:100px" class="text-right">Misc Income:</td>
                <td style="width:50px"><asp:textbox runat="server" ID="MiscIncometextbox" Text="0" Width="50px" TextMode="Number"/></td>
                
            </tr>
            
                
            
            </table>
        <br />
        <div style="text-align:center">North-westmost corner at <asp:textbox runat="server" ID="Coordinatetextbox" Text="0,0,0" Width="150px"/> and has dimensions <asp:textbox runat="server" ID="XDimensiontextbox" Text="0" Width="50px" TextMode="Number"/>,<asp:textbox runat="server" ID="YDimensiontextbox" Text="0" Width="50px" TextMode="Number"/>,<asp:textbox runat="server" text="0" ID="ZDimensiontextbox" Width="50px" TextMode="Number"/></div>
        <br />
        <br />
        <div style="text-align:center"><asp:Button runat="server" ID="CreateModBtn" Text="Create Asset" Width="125px"/>&nbsp;&nbsp; <asp:Button runat="server" ID="CancelBTN" Text="Cancel" Width="125px"/></div>
        
    </div>

            <asp:Panel ID="NotifPanel" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Inset" Width="75%" Height="75px" style="margin:0 auto" Visible="False">
                <div class="text-center" style="height:75px">
                    <strong>NOTE<br /> </strong>
                    <asp:Label ID="NotifLabel" runat="server" Text="The notification sub seems to have been sent an incorrect value!"></asp:Label>
                    <strong>
				<br />
				    </strong>
                </div>
            </asp:Panel>
                
    </asp:Content>