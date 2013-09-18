<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="RockstarSeating.Inventory._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

	<style type="text/css">

		/*  INVENTORY */
		#col1, #col2
		{
			float: left;
		}
		.uploadForm
		{
			padding:0 0 10px 10px;
		}
		.uploadForm #col1
		{
			width: 450px;
		}
		.uploadForm #col2
		{
			margin-left: 15px;
			padding-left: 42px;
		}
		.uploadForm .fLeftMarg
		{
			margin-left: 50px;
			display: inline-block;
		}
		#consignmentRegForm .floatingErrs
		{
			position: relative;
		}
		#consignmentRegForm .floatingErrs span
		{
			left: 5px;
			position: absolute;
			top: 0px;
			width: 260px;
		}
		#runTimeErrMsgs
		{
			color:Red;
			font-weight:bold;	
		}

	</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Upload your inventory via our convenient form</h1>

    <div>
        <form id="uploadForm" method="post" action="Default.aspx">
		<div id="runTimeErrMsgs">
			<asp:Literal ID="ErrorMessage" runat="server" Visible="false"></asp:Literal>
		</div>
		        
        <div class="failureNotification errorBox" ID="validationBox" runat="server" visible="false">
            <asp:ValidationSummary ID="UploadInventoryValidationSummary" runat="server" CssClass="failureNotification" ValidationGroup="UploadInventoryValidationGroup" />
        </div>
        
        <div>
			<p>After a successful Ticket Consignment Upload, the processing can take up to 24 hours before your tickets will be listed on our site.</p>
			<p><i>*If you submit your Tickets in the afternoon, or late in the evening, you will be contacted by an Account Representative on the next business day.</i></p>

            <fieldset class="uploadForm">
                <legend>Fill out this form as completely as possible</legend>
                <div id="col1">
                    <div class="p">
                        <asp:Label ID="lblEvent" runat="server" AssociatedControlID="Event">Event Title:</asp:Label>
                        <%--<asp:TextBox ID="Event" runat="server" CssClass="textEntry" MaxLength="200" Width="438px">Test Event</asp:TextBox>--%>
                        <asp:TextBox ID="Event" runat="server" CssClass="textEntry" MaxLength="200" Width="438px"/>
                        <asp:RequiredFieldValidator ID="EventRequired" runat="server" ControlToValidate="Event"
                            CssClass="failureNotification" ErrorMessage="Event is field." ToolTip="Event is required."
                            ValidationGroup="UploadInventoryValidationGroup">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="p">
                        <asp:Label ID="lblVenue" runat="server" AssociatedControlID="Venue">Venue:</asp:Label>
                        <%--<asp:TextBox ID="Venue" runat="server" CssClass="textEntry" Width="438px">Test Venue</asp:TextBox>--%>
                        <asp:TextBox ID="Venue" runat="server" CssClass="textEntry" Width="438px"/>
                        <asp:RequiredFieldValidator ID="VenueRequired" runat="server" ControlToValidate="Venue"
                            CssClass="failureNotification" ErrorMessage="Venue is required." ToolTip="Venue is required."
                            ValidationGroup="UploadInventoryValidationGroup">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="p">
                        <div class="fLeft">
                            <asp:Label ID="lblRow" runat="server" AssociatedControlID="Row">Row:</asp:Label>
                            <%--<asp:TextBox ID="Row" runat="server" CssClass="textEntry" Width="200">1</asp:TextBox>--%>
                            <asp:TextBox ID="Row" runat="server" CssClass="textEntry" Width="200"/>
                            <asp:RequiredFieldValidator ID="RowRequired" runat="server" ControlToValidate="Row"
                                CssClass="failureNotification" ErrorMessage="Row is required." ToolTip="Row is required."
                                ValidationGroup="UploadInventoryValidationGroup">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="fLeftMarg">
                            <div class="fLeft" style="width: 100px;">
                                <div>
                                    Seat From:</div>
                                <%--<asp:TextBox ID="SeatFrom" runat="server" MaxLength="40" Width="60">2</asp:TextBox>--%>
                                <asp:TextBox ID="SeatFrom" runat="server" MaxLength="40" Width="60"/>
                            </div>
                            <div class="fLeft">
                                <div>
                                    Seat Thru:</div>
                              <%--  <asp:TextBox ID="SeatThru" runat="server" MaxLength="40" Width="60">3</asp:TextBox>--%>
                                <asp:TextBox ID="SeatThru" runat="server" MaxLength="40" Width="60"/>
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="p">
                        <div class="fLeft">
                            <asp:Label ID="lblSection" runat="server" AssociatedControlID="Section">Section:</asp:Label>
                            <%--<asp:TextBox ID="Section" runat="server" CssClass="textEntry" Width="200">4</asp:TextBox>--%>
                            <asp:TextBox ID="Section" runat="server" CssClass="textEntry" Width="200"/>
                            <asp:RequiredFieldValidator ID="SectionRequired" runat="server" ControlToValidate="Section"
                                CssClass="failureNotification" ErrorMessage="Section is required." ToolTip="Section is required."
                                ValidationGroup="UploadInventoryValidationGroup">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="fLeftMarg">
                            <div class="fLeft" style="width: 100px;">
                                <div>Quantity:</div>
                               <%-- <asp:TextBox ID="Quantity" runat="server" MaxLength="10" Width="60">2</asp:TextBox>--%>
                                <asp:TextBox ID="Quantity" runat="server" MaxLength="10" Width="60"/>
                                <asp:CustomValidator ID="QuantityInt" ControlToValidate="Quantity" CSSClass="txtFldMsg" runat="server" ErrorMessage="Please enter a whole number only." ToolTip="Please enter a whole number only." OnServerValidate="QuantityInt_Validator"></asp:CustomValidator>
                            </div>
                            <div class="fLeft">
                                <div>Cost ($$):</div>
                                <%--<asp:TextBox ID="Cost" runat="server" Width="60">1600</asp:TextBox>--%>
                                <asp:TextBox ID="Cost" runat="server" Width="60"/>
                                <asp:RequiredFieldValidator ID="CostRequired" runat="server" ControlToValidate="Cost" CssClass="failureNotification" ErrorMessage="Cost is required." ToolTip="Cost is required." ValidationGroup="UploadInventoryValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="p">
                        <asp:Label ID="lblNotes" runat="server" AssociatedControlID="Notes">Notes:</asp:Label>
                        <asp:TextBox Rows="6" Columns="52" ID="Notes" runat="server" TextMode="MultiLine"
                            CssClass="textEntry" />
                    </div>
                </div>
                <div id="col2">
                    <div class="p" style="margin-top:25px;">
                        <div class="label">
                            Event Time:</div>
                        <div>
                            <asp:DropDownList ID="ddlHours" runat="server" />
                            <asp:DropDownList ID="ddlMins" runat="server" />
                            <asp:DropDownList ID="ddlMeridian" runat="server">
                                <asp:ListItem>AM</asp:ListItem>
                                <asp:ListItem>PM</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="p">
                        <asp:Label ID="lblEventDate" runat="server" AssociatedControlID="Venue">Event Date:</asp:Label>
						<div id="calendarBox">
							<asp:TextBox ID="DatePicker" runat="server" />
						</div>
                    </div>
                </div>
                <div class="clear">
                </div>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="btnSubmit" runat="server" CommandName="UploadInv" Text="Submit" ValidationGroup="UploadInventoryValidationGroup" />
            </p>
        </div>
        </form>
    </div>

	<script type="text/javascript">

		$('#<%: DatePicker.ClientID %>').datepicker({
			showOn: "button",
			buttonImage: '<%: ResolveClientUrl("~/assets/Styles/ui-lightness") %>/images/calendar.png',
			buttonImageOnly: true,
			dateFormat: 'mm-dd-yy',
			onSelect: function (dateText, inst) {
				document.getElementById("MainContent_btnSubmit").disabled = false;
			}
		});
	
	</script>

</asp:Content>
