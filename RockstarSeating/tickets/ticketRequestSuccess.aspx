<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ticketRequestSuccess.aspx.cs" Inherits="RockstarSeating.tickets.ticketRequestSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="ticketRequestSuccess" style="width:530px;">

	<h1>Thanks for using Rockstar Seating!</h1>
	
	<p>Your request has been received and will be processed as soon as possible.  You should receive an email shortly detailing the confirmation of your Ticket Request Submission.</p>
	
	<div style="text-align:right;">
		<a style="margin-top:25px;color:#333;text-decoration:underline;" href="<%: ResolveClientUrl("~/Default.aspx") %>">back to home</a>
	</div>

</div>


</asp:Content>
