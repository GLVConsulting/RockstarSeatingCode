<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RockstarSeating.Admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		#viewExportList
		{
			padding: 10px;
			margin: 20px 0;
		}
		#adminPage{ height:auto; }
	</style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="adminPage">
<div class="failureNotification errorBox" ID="validationBox" runat="server" visible="false">
    <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
</div>

<h1>Ticket Consignment Inventory Admin</h1>

<dl>
    <dt>Export Recent Uploads</dt>
    <dd>
        <asp:Button Text="export" id="exportBtn" runat="server" OnClick="exportBtn_click" />
        <asp:Button Text="view" ID="viewBtn" runat="server" OnClick="viewBtn_click" />
    </dd>
    <dd style="color:#777;"><small>last export time: <asp:literal id="lastExported" runat="server"/></small></dd>
	<dd>	
		<div id="viewExportList">
			<asp:GridView AutoGenerateColumns="false" CssClass="gridview" ID="gvExportList" runat="server" AllowSorting="true" CellPadding="5" SelectedRowStyle-Font-Bold="true" AlternatingRowStyle-BackColor="#F2EFDE" EnableViewState="false">
			</asp:GridView>
		</div>
		<asp:Literal ID="noExports" runat="server" Visible="false" />	
	</dd>

	<dt style="margin-top:40px;">Verify Consignor Application</dt>
	<dd>
		<asp:Label CssClass="statusMsg" ID="lblStatusMsg" runat="server" Visible="false" />
	</dd>
	<dd>
		<asp:Panel id="consingorApproveList" runat="server" Visible="false">
			<asp:GridView AutoGenerateColumns="false" CssClass="gridview" ID="gvConsingorApproveList" runat="server" AllowSorting="true" CellPadding="5" SelectedRowStyle-Font-Bold="true" AlternatingRowStyle-BackColor="#F2EFDE"  EnableViewState="false">
			</asp:GridView>
		</asp:Panel>
		<asp:Literal ID="noConsignors" runat="server" Visible="false" />
	</dd>
</dl>





</div>

</asp:Content>
