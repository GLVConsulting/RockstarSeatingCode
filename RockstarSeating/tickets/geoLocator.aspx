<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="geoLocator.aspx.cs" Inherits="RockstarSeating.Sandbox.geoLocator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

	<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true&amp;region=US"></script>
	<script type="text/javascript" src="http://www.google.com/jsapi"></script>
	<script type="text/javascript"src="../assets/Scripts/gears_init.js"></script>

	<script type="text/javascript" src="../assets/Scripts/geoLocator.js"></script>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<div class="bSpacer2">&nbsp;</div>
	
	<div id="localEvents">
		<asp:Label ID="errMsg" Runat="server" CssClass="errMsg" Visible="false"></asp:Label>
	    
		<asp:Literal ID="ticketDetail" runat="server"/>
		<asp:HiddenField ID="userZipCode" runat="server" />

		<!-- flag this as true when defaultZipCode is set by user, DON'T FORGET TO USE A COOKIE FOR  -->
		<asp:HiddenField ID="useZipCode" runat="server" Value="false" />


		<asp:GridView ID="TicketTable" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="540px">
			
			<HeaderStyle BackColor="#F2EFDE" Font-Bold="True" ForeColor="#6E878C" Font-Size="13px" CssClass="tn_results_colhead" />
			<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />

			<RowStyle BackColor="#D9E9FB" />
			<AlternatingRowStyle BackColor="#F5F5F5" />

			<Columns>

				<asp:HyperLinkField DataNavigateUrlFields="Name,ID" DataNavigateUrlFormatString="~/event.aspx?evtid={1}&event={0}" DataTextField="Name" HeaderText="Event" ControlStyle-ForeColor="#343434" ControlStyle-Font-Underline="true" />




				<asp:HyperLinkField DataNavigateUrlFields="VenueID" DataNavigateUrlFormatString="~/venue.aspx?venid={0}" DataTextField="Venue" HeaderText="Venue" ControlStyle-ForeColor="#343434" ControlStyle-Font-Underline="true" />

				<asp:BoundField DataField="DisplayDate" HeaderText="Date" />

				<asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/ResultsTicket.aspx?eventID={0}" HeaderText="" Text="View Tickets" />

			</Columns>


		</asp:GridView>


	</div>

	<div class="bSpacer2">&nbsp;</div>

</asp:Content>
