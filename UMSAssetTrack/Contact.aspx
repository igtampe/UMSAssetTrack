<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="UMSAssetTrack.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100%;text-align:center;padding:10px">
        <asp:TextBox runat="server"  ID="searchbox" TextMode="search" Width="500px" />

        &nbsp; <asp:Button runat="server" ID="LogoutBTN" Text="Search" style="width:200px"/>
        <br />
        <br />
        <div style="text-align:center"><b><asp:Label runat="server" ID="ResultsLabel" /></b></div>
    </div>
    <div class="jumbotron" style="width:100%">
   
        
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Width="100%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="AName" HeaderText="Asset Name" SortExpression="AName" />
                <asp:BoundField DataField="AType" HeaderText="Type" SortExpression="AType" />
                <asp:BoundField DataField="City" HeaderText="Location" SortExpression="City" />
                <asp:BoundField DataField="Owner" HeaderText="Owner" SortExpression="Owner" />
                <asp:BoundField DataField="Income" HeaderText="Income" SortExpression="Income" />
                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AssetDetails.aspx?ID={0}" Text="Details" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:doot %>" ProviderName="<%$ ConnectionStrings:doot.ProviderName %>" SelectCommand="SELECT ID, AName, District, City, Owner, Income, CornerPos, AType 
FROM Registry 
WHERE AName Like '%'+?+'%';">
            <SelectParameters>
                <asp:QueryStringParameter Name="OwnerID" QueryStringField="search" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
   
    </div>
        
</asp:Content>
