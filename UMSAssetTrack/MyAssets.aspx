<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAssets.aspx.vb" Inherits="UMSAssetTrack.MyAssets" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="text-align:center">Welcome back 
        <asp:Label runat="server" ID="UsernameLabel" Text="You Bobo! The Username didn't load"/> &nbsp;(<asp:Label runat="server" ID="IDLabel" Text="0000"/>)!
    </h1>
    <div style="width:100%;text-align:center;padding:10px">
            <asp:Button runat="server" ID="CreateBTN" Text="Create a New Asset" style="width:200px"/> &nbsp; <asp:Button runat="server" ID="LogoutBTN" Text="Log Out" style="width:200px"/>        
    </div>
    <div class="jumbotron" style="width:100%">
   
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Width="100%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="AName" HeaderText="Asset Name" SortExpression="AName" />
                <asp:BoundField DataField="AType" HeaderText="Type" SortExpression="AType" />
                <asp:BoundField DataField="City" HeaderText="Location" SortExpression="City" />
                <asp:BoundField DataField="Income" HeaderText="Income" SortExpression="Income" />
                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AssetDetails.aspx?ID={0}" Text="Details" />
                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AssetForm.aspx?mode=edit&amp;ID={0}" Text="Edit" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:doot %>" ProviderName="<%$ ConnectionStrings:doot.ProviderName %>" SelectCommand="SELECT [ID], [AName], [District], [City], [Complete], [Income], [CornerPos], [AType] FROM [Registry] WHERE ([OwnerID] = ?)">
            <SelectParameters>
                <asp:CookieParameter CookieName="UMSWEBID" Name="OwnerID" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
   
    </div>
        
    

    

</asp:Content>
