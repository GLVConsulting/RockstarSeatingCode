<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="ResultsEmpty.aspx.cs" Inherits="RockstarSeating.tickets.ResultsEmpty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:Literal ID="ticketDetail" runat="server"></asp:Literal>
	<div class="main_content">
		<h1>Rockstar Seating</h1>
		<p>search returned zero(0) results....</p>
		
		<input type="text" class="searchTxt" onkeydown="trap_EnterKey(event);" />
		<input class="searchFrmBtn" type="image" src="<%: ResolveClientUrl("~/assets/img/searchIcon.png") %>"
			onclick="searchFrmSubmit($(this));" />
	</div>
</asp:Content>
