<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="RockstarSeating.tickets.ResultsCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<h1><asp:Literal id="pluginCategory" runat="server"></asp:Literal></h1>
	    <asp:Literal ID="ticketDetail" runat="server"></asp:Literal>
</asp:Content>
