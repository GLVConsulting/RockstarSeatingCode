<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Testimonials.aspx.cs" Inherits="RockstarSeating.Admin.Testimonials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<meta content="NOINDEX, NOFOLLOW" name="ROBOTS"/>

	<style type="text/css">
		#testimonialsForm
		{
			padding:10px;	
		}
		#testimonialsForm input[type=text], #testimonialsForm textarea
		{
			margin-top:4px;
			padding:4px;	
		}
		#testimonialsForm #adminGetAll_Lnk:link, 
		#testimonialsForm #adminGetAll_Lnk:visited, 
		#testimonialsForm #adminGetAll_Lnk:hover, 
		#testimonialsForm #adminGetAll_Lnk:active
		{
			color:#63A787;
			font-weight:bold;
			text-decoration:underline;	
		}
		#testimonialsForm #adminGetAll_Lnk:hover
		{
			text-decoration:none;
		}
	
	</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

		<!-- user messaging -->
		<asp:Label CssClass="errMsg" runat="server" id="errMsg" Visible="false"></asp:Label>

		<asp:Label CssClass="statusMsg" runat="server" ID="statusMsg" Visible="false"></asp:Label>
		<!-- user messaging -->

	<asp:Panel ID="viewPanel" runat="server" Visible="false">
		
		<div id="viewTestimonials">
			<asp:GridView AutoGenerateColumns="false" CssClass="gridview" ID="gvTestimonials" runat="server" AllowSorting="true" CellPadding="5" SelectedRowStyle-Font-Bold="true" AlternatingRowStyle-BackColor="#F2EFDE" EnableViewState="false">
			</asp:GridView>
		</div>

		<div style="margin:25px;">
			<a href="Testimonials.aspx" style="font-weight:bold;"><< BACK</a>		
		</div>

	</asp:Panel>



	<asp:Panel ID="formPanel" runat="server">																																																	<fieldset id="testimonialsForm">

			<!-- user messaging -->
			<asp:ValidationSummary ID="Testimonials_ValidationGroupSummary" runat="server" CssClass="errMsg" 
					ValidationGroup="Testimonials_ValidationGroup"/>
			<!-- user messaging -->

			<a href="Testimonials.aspx?action=view" id="adminGetAll_Lnk">View All Testimonials</a>

			<legend>Fill out this form as completely as possible</legend>

				<div class="p">
					<asp:Label ID="lblCustomerName" runat="server" AssociatedControlID="CustomerName">Customer Name:</asp:Label>
					<asp:TextBox ID="CustomerName" runat="server" CssClass="textEntry" Width="438px" MaxLength="60" />
					<asp:RequiredFieldValidator ID="EventRequired" runat="server" ControlToValidate="CustomerName"
						CssClass="failureNotification" ErrorMessage="Customer Name is a required field!" ToolTip="Customer Name is required."
						ValidationGroup="Testimonials_ValidationGroup">*</asp:RequiredFieldValidator>
				</div>

				<div class="p">
					<asp:Label ID="lblCustomerLocation" runat="server" AssociatedControlID="CustomerLocation">Customer Location:</asp:Label>
					<asp:TextBox ID="CustomerLocation" runat="server" CssClass="textEntry" Width="438px" MaxLength="60" />
					<asp:RequiredFieldValidator ID="CustomerLocationRequired" runat="server" ControlToValidate="CustomerLocation" CssClass="failureNotification" ErrorMessage="Customer Location is a required field!" ToolTip="Customer Location is required." ValidationGroup="Testimonials_ValidationGroup">*</asp:RequiredFieldValidator>
				</div>

				<div class="p">
					<asp:Label ID="lblCustomerEvent" runat="server" AssociatedControlID="CustomerEvent">Customer Event:</asp:Label>
					<asp:TextBox ID="CustomerEvent" runat="server" CssClass="textEntry" Width="438px" MaxLength="60" />
					<asp:RequiredFieldValidator ID="CustomerEventRequired" runat="server" ControlToValidate="CustomerEvent" CssClass="failureNotification" ErrorMessage="Customer Event is a required field!" ToolTip="Customer Event is required." ValidationGroup="Testimonials_ValidationGroup">*</asp:RequiredFieldValidator>
				</div>

				<div class="p">
					<asp:Label ID="lblTestimonial" runat="server" AssociatedControlID="CustomerBlurb">Customer Testimonial:</asp:Label>
					<asp:TextBox ID="CustomerBlurb" runat="server" Rows="5" TextMode="MultiLine" CssClass="textEntry" Width="434" MaxLength="300" />
					<asp:RequiredFieldValidator ID="TestimonialTextRequired" runat="server" ControlToValidate="CustomerBlurb"
						CssClass="failureNotification" ErrorMessage="Customer Testimonial is a required field!" ToolTip="Customer Testimonial is required."
						ValidationGroup="Testimonials_ValidationGroup">*</asp:RequiredFieldValidator>
				</div>


				<div class="p">
					<asp:Button ID="submitBtn" runat="server" Text="Submit" ValidationGroup="Testimonials_ValidationGroup" />
				</div>

		</fieldset>

	</asp:Panel>

</asp:Content>
