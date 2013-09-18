<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResultsTicket.aspx.cs" Inherits="RockstarSeating.tickets.ResultsTicket" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	
	<asp:Literal ID="metaTags" runat="server" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<!--	#########################	FACEBOOK SOCIAL PLUGIN	################################# -->

	<asp:Literal ID="likeBtn" runat="server" />

<!--	#########################	FACEBOOK SOCIAL PLUGIN	################################# -->


	<div class="failureNotification errorBox" ID="validationBox" runat="server" visible="false">
        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
    </div>

<div id="ticketRequestForm">

    <asp:Literal ID="ticketDetail" runat="server"></asp:Literal>

	<script type="text/javascript">

			$(":submit").click(function () {
				$('#mainForm').attr('name', 'mainForm');

				var fldNames = [], fldVals = [], formElemName = '';
				for (i = 0; i < document.mainForm.elements.length; i++) {
					formElemName = document.mainForm.elements[i].name;
					fldNames.push(formElemName);

					if (formElemName != "btnSubmit" && formElemName.toLowerCase() != "txtstreet2" && formElemName.toLowerCase() != "txtdescription") {
						$('#' + formElemName).css('border', 'none');
					}
					document.mainForm.elements[i].setAttribute("id", formElemName);

					fldVals.push(document.mainForm.elements[i].value);
				}


				var dElem, formIsValid = true;
				for (var ix = 0; ix < fldNames.length; ix++) {
					if (fldVals[ix] == "" && (fldNames[ix].toLowerCase()!= "btnsubmit" && fldNames[ix].toLowerCase() != "txtstreet2" && fldNames[ix].toLowerCase() != "txtdescription")) {
						dElem = fldNames[ix];
						$('#page #content #' + fldNames[ix]).css('border', '1px solid red');
						formIsValid = false;
					}
				}


				if (formIsValid) {
					if (validateEmail($("#txtEmail").val())) {
						return true;
					}
					$('#txtEmail').css('border', '1px solid red');
					alert("You must provide a valid Email Address!: " + $("#txtEmail").val());
					return false;
				}
				else {
					alert("All Highlighted Fields are Required.");
					return false;
				}

			});
	
	</script>
	
	<!-- Google Code for Ticket Results Page Conversion Page -->
	<script type="text/javascript">
		/* <![CDATA[ */
		var google_conversion_id = 1011442095;
		var google_conversion_language = "en";
		var google_conversion_format = "1";
		var google_conversion_color = "ffffff";
		var google_conversion_label = "86UuCOnuuwIQr8Ol4gM";
		var google_conversion_value = 0;
		/* ]]> */
	</script>
	<script type="text/javascript" src="http://www.googleadservices.com/pagead/conversion.js"></script>
	<noscript>
		<div style="display:inline;">
			<img height="1" width="1" style="border-style:none;" alt="" src="http://www.googleadservices.com/pagead/conversion/1011442095/?label=86UuCOnuuwIQr8Ol4gM&amp;guid=ON&amp;script=0"/>
		</div>
	</noscript>
	
	
</div>
</asp:Content>
