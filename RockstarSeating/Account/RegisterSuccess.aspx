<%@ Page Title="RegisterSuccess" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="RegisterSuccess.aspx.cs" Inherits="RockstarSeating.Account.RegisterSuccess" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>





<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

	<h1>Rockstar Seating</h1>

	<p>Your registration submission was successful.  A representative from Rockstar Seating will be contacting you shortly.  Please have your consignor code and a valid credit card ready for your Ticket Seller Account Verification process.</p>

	<p>Thanks again for using RockstarSeating.com!</p>

    <div style="margin:25px 0">return to <a class="link" href="<%: ResolveClientUrl("~/Default.aspx") %>">home</a></div>

</asp:Content>


