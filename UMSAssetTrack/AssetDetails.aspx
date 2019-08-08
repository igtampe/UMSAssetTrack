<%@ Page Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AssetDetails.aspx.vb" Inherits="UMSAssetTrack.AssetDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="width:100%">
        <table align=center>
            <tr>
                <td rowspan="6" style="width: 320px; height:180px"><asp:Image runat="server" ID="AssetImage" Width="320px" Height="180px"/></td>
                <td style="width:20px"></td>
                <td colspan="4"><b><asp:Label runat="server" ID="AssetNameLabel" Text="ITEM NAME"/></b></td>
                
            </tr>
            <tr>
                <td style="width:20px"></td>
                <td style="width:125px">Owner:</td>
                <td style="width:125px"><asp:Label runat="server" ID="OwnerLabel"/></td>
                <td style="width:125px">Type:</td>
                <td style="width:125px"><asp:Label runat="server" ID="TypeLabel"/></td>
            </tr>
            
            <tr>
                <td style="width:20px"></td>
               <td style="width:125px">Location:</td>
                <td style="width:125px"><asp:Label runat="server" ID="LocationLabel"/></td>
                <td style="width:125px">Date of Creation:</td>
                <td style="width:125px"><asp:Label runat="server" ID="CreationDate"/></td>
            </tr>
            <tr>
                <td style="width:20px"></td>
               <td style="width:125px">Price:</td>
                <td style="width:125px"><asp:Label runat="server" ID="PriceLabel"/></td>
                <td style="width:125px">Total Income:</td>
                <td style="width:125px"><asp:Label runat="server" ID="IncomeLabel"/></td>
            </tr>
            <tr>
                <td style="width:20px"></td>
                <td>Details:</td>
                <td rowspan="2" colspan="3"><asp:Label runat="server" ID="StatusLabel"/></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <table align=center>
            <tr>
                
                <td style="width:100px">Studio Units:</td>
                <td style="width:25px"><asp:Label runat="server" ID="SUnitsLabel" Text="0"/></td>
                <td style="width:100px">Studio Units:</td>
                <td style="width:50px"><asp:Label runat="server" ID="SRentLabel" Text="500"/></td>
                <td style="width:100px">Rooms:</td>
                <td style="width:50px"><asp:Label runat="server" ID="RoomUnitLabel" Text="0"/></td>
                <td style="width:100px">Chairs:</td>
                <td style="width:25px"><asp:Label runat="server" ID="ChairsLabel" Text="0"/></td>
                
            </tr>
            <tr>
                <td style="width:100px">1 BR Units:</td>
                <td style="width:25px"><asp:Label runat="server" ID="BR1UnitsLabel" Text="0"/></td>
                <td style="width:100px">1 BR Rent:</td>
                <td style="width:50px"><asp:Label runat="server" ID="BR1RentLabel" Text="750"/></td>
                <td style="width:100px">Suites:</td>
                <td style="width:50px"><asp:Label runat="server" ID="SuiteUnitsLabel" Text="0"/></td>
                <td style="width:100px">Avg Spending:</td>
                <td style="width:25px"><asp:Label runat="server" ID="AvgSpendingLabel" Text="0"/></td>
            </tr>
            
            <tr>
               <td style="width:100px">2 BR Units:</td>
                <td style="width:25px"><asp:Label runat="server" ID="BR2UnitsLabel" Text="0"/></td>
                <td style="width:100px">2 BR Rent:</td>
                <td style="width:50px"><asp:Label runat="server" ID="BR2RentLabel" Text="1000"/></td>
                <td style="width:100px">Room Rate:</td>
                <td style="width:50px"><asp:Label runat="server" ID="RoomRateLabel" Text="200"/></td>
                <td style="width:100px">Customers/HR:</td>
                <td style="width:25px"><asp:Label runat="server" ID="CustomersPerHour" Text="0"/></td>
            </tr>
            <tr>
               <td style="width:100px">3 BR Units:</td>
                <td style="width:25px"><asp:Label runat="server" ID="BR3UnitsLabel" Text="0"/></td>
                <td style="width:100px">3 BR Rent:</td>
                <td style="width:50px"><asp:Label runat="server" ID="BR3RentLabel" Text="1250"/></td>
                
                <td style="width:100px">Suite Rate:</td>
                <td style="width:50px"><asp:Label runat="server" ID="SuiteRateLabel" Text="400"/></td>
                <td style="width:100px">Hours Open:</td>
                <td style="width:25px"><asp:Label runat="server" ID="HoursOpenLabel" Text="0"/></td>
            </tr>
            <tr>
                <td style="width:100px">PH Units:</td>
                <td style="width:25px"><asp:Label runat="server" ID="PHUnitsLabel" Text="0"/></td>
                <td style="width:100px">PH Rent:</td>
                <td style="width:50px"><asp:Label runat="server" ID="PHRentLabel" Text="1250"/></td>
                <td style="width:100px">Misc Income:</td>
                <td style="width:50px"><asp:Label runat="server" ID="MiscIncomeLabel" Text="0"/></td>
                
            </tr>
            <tr>
                <td colspan="8" style="text-align:right; color:darkgray"> <i>Last modified on <asp:Label runat="server" ID="LastModDate"/></i></td>
            </tr>
            </table>
        <br />
        <div style="text-align:center">Located at <asp:Label runat="server" ID="CoordinateLabel"/> and has dimensions <asp:Label runat="server" ID="XDimensionLabel"/>,<asp:Label runat="server" ID="YDimensionLabel"/>,<asp:Label runat="server" ID="ZDimensionLabel"/></div>
      
        
    </div>
   
</asp:Content>