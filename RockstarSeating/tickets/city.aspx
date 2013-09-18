<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="city.aspx.cs" Inherits="RockstarSeating.tickets.ResultsCity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="citySearch">
		<h1><asp:Literal ID="searchCity" runat="server"></asp:Literal></h1>
		<asp:Literal ID="ticketDetail" runat="server"></asp:Literal>
	</div>
</asp:Content>
