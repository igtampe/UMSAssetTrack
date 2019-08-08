<%@ Page Language="vb" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="MiniCard.aspx.vb" Inherits="UMSAssetTrack.MiniCard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table align=center style="width:250px">
    <tr>
        <td style="width:250px; text-align:center" colspan="2">
            <b><asp:hyperlink runat="server" ID="AssetNameLabel" Text="ITEM NAME"/></b>
        </td>
    </tr>
    <tr>
        <td style="width:250px; text-align:center" colspan="2">
            <asp:Image runat="server" ID="AssetImage" Width="250px" Height="141px"/>
        </td>
    </tr>
    <tr>
        <td style="width:125px;text-align:right">Owner:</td>
        <td style="width:125px"><asp:Label runat="server" ID="OwnerLabel"/></td>
    </tr>
    <tr>
        <td style="text-align:center;width:250px" colspan="2"><b><hr />Description</b></td>
    </tr>
    <tr>
        <td style="text-align:left;width:250px;height:auto" colspan="2"><asp:Label runat="server" ID="StatusLabel"/></td>
    </tr>   
    
  
</table>

        
       </asp:Content> 
    
   
    