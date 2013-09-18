<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cvv2.aspx.cs" Inherits="RockstarSeating.content.cvv2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="cvv2">
        <h1>What is the Card Verification System?</h1>

        <div>For your online shopping safety and security, we require that you enter your card's verification number. We take this added step to ensure your credit card information is not being used fraudulently.</div>
		<div style="text-align: center;">
			<img alt="Visa, Mastercard or Discover" src="<%: ResolveClientUrl("~/assets/img/visa_mc_discover_ccv.jpg") %>" />
		</div>
		
		<div>If you are using a <span class="bold">Visa</span>, <span class="bold">MasterCard</span> or <span class="bold">Discover</span> card, you must provide the card's CVV2 number. This 3-digit number is printed on the back of your card. It appears after and to the right of your card number on the signature panel on the back of the credit card.</div>
		
		<div style="text-align: center;">
			<img alt="American Express" src="<%: ResolveClientUrl("~/assets/amex_ccv.jpg") %>" />
		</div>
		<div>If you are using an <span class="checkout_notice">American Express</span> card, the CVV2 number is the 4-digit number on the front of your card above the account number.</div>
</div>
</asp:Content>
