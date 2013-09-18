<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="generalErr.aspx.cs" Inherits="RockstarSeating.content.generalErr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="generalErr" style="width:530px;">

	<h1><span style="color:red;">Oops!</span> An error occurred while processing your request.</h1>
	
	   
    <div class="failureNotification errorBox" ID="validationBox" runat="server" visible="false">
        <asp:Literal ID="ErrMessage" runat="server"></asp:Literal>
    </div>


	<p>We are sorry for any inconvenience this might have caused.  Please bear with us and our Technical Difficulties at this time.  Should you happen to re-experience this problem, please <a style="color:#394a5e;text-decoration:underline;" href="mailto:support@rockstarseating.com">email us</a> detailing your issue and our Support Team will do their best to quickly resolve this issue on our website.</p>

	<p>Thanks for using Rockstar Seating!</p>
	
	<div style="text-align:right;">
		<a style="margin-top:25px;color:#394a5e;text-decoration:underline;" href="<%: ResolveClientUrl("~/Default.aspx") %>">back to home</a>
	</div>

</div>


</asp:Content>
