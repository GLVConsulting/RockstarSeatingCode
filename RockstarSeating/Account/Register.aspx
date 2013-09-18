<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="RockstarSeating.Account.Register" EnableViewState="true" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

	<script src="<%: ResolveClientUrl("~/assets/fancybox/jquery.fancybox-1.3.4.pack.js") %>" type="text/javascript"></script>
	<link href="<%: ResolveClientUrl("~/assets/fancybox/jquery.fancybox-1.3.4.css") %>" rel="stylesheet" type="text/css" />
	
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <form id="consignmentRegistrationForm" method="post" action="Register.aspx">
    <h2>Create a Ticket Seller Account with Rockstar Seating</h2>
	    
    <p style="width:600px;">Use the form below to create a new account. Please fill out the form as completely as possible in order to avoid any delays in communicating with you.<br />
        All fields are required.
    </p>

	<p>After a successful form submission, application processing can take up to 24 hours before you will be contacted for your Ticket Seller Account Application Verification.</p>
	<p><i>*If you submit the form in the afternoon or late in the evening you will be contacted by an Account Representative on the next business day.</i></p>
    
    <div class="failureNotification errorBox" ID="backEndErrors" runat="server" visible="false">
        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
    </div>
    
     <div id="formErrors" runat="server" visible="false">
        <div style="border:1px solid red;border-width:1px 1px 0;width:600px;padding:10px">
            <h1 style="padding:0;margin:0;color:red;">Form Errors:</h1>
        </div>
            <asp:ValidationSummary CssClass="failureNotification errorBox" ID="RegisterUserValidationSummary" runat="server" ValidationGroup="RegisterUserValidationGroup" />
     </div>


    <div class="accountInfo">
        <fieldset class="register" id="consignmentRegForm">
            <legend>Account Information</legend>
            <div class="column">
                <p>
                    <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName">First Name:</asp:Label>
                    <asp:TextBox ID="FirstName" runat="server" CssClass="textEntry" EnableViewState="true" />
                    <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="FirstName"
                        CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName">Last Name:</asp:Label>
                    <asp:TextBox ID="LastName" runat="server" CssClass="textEntry" EnableViewState="true" />
                    <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="LastName"
                        CssClass="failureNotification" ErrorMessage="Last Name is required." ToolTip="Last Name is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                    <asp:TextBox ID="Email" runat="server" CssClass="textEntry" EnableViewState="true"/>
                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                        CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <div style="margin:35px 0 0 10px;">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password <small>(<i>6-15 characters</i>)</small>:</asp:Label>
                    <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" EnableViewState="true" />
                    <asp:RequiredFieldValidator ControlToValidate="Password" CssClass="failureNotification"
                        Display="Dynamic" ErrorMessage="Password is required." ID="PasswordRequired"
                        runat="server" ToolTip="Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="PasswordLengthValidator" ValidationGroup="RegisterUserValidationGroup" runat="server" ControlToValidate="Password" ErrorMessage="Password length is 6-15 characters." CssClass="txtFldMsg" OnServerValidate="PasswordLength_Validator"></asp:CustomValidator>
                </div>

                <div class="p" style="margin-left:10px;">
                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password" EnableViewState="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification"
                        Display="Dynamic" ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired"
                        runat="server" ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="RegisterUserValidationGroup" EnableTheming="true" CssClass="txtFldMsg" style="display:block;" />
                </div>
            </div>
            <div class="column" style="width: 48%">
                <p>
                    <asp:Label ID="Address1Label" runat="server" AssociatedControlID="Address1">Address:</asp:Label>
                    <asp:TextBox ID="Address1" runat="server" CssClass="textEntry" EnableViewState="true" />
                    <asp:RequiredFieldValidator ID="Address1Required" runat="server" ControlToValidate="Address1"
                        CssClass="failureNotification" ErrorMessage="Address is required." ToolTip="Address is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="Address2Label" runat="server" AssociatedControlID="Address2">Address 2 <small><i>(not required)</i></small>:</asp:Label>
                    <asp:TextBox ID="Address2" runat="server" CssClass="textEntry" EnableViewState="true" />
                </p>
                <p>
                    <span class="column">
                        <asp:Label ID="CityLabel" runat="server" AssociatedControlID="City">City:</asp:Label>
                        <asp:TextBox ID="City" runat="server" CssClass="textEntry" Width="120" EnableViewState="true" />
                        <asp:RequiredFieldValidator runat="server" ID="CityRequired" ControlToValidate="City" ErrorMessage="City is required" CssClass="failureNotification" ToolTip="City is required" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

                    </span>
                    <span class="column">
                        <asp:Label ID="StateLabel" runat="server" AssociatedControlID="State">State:</asp:Label>
                        <asp:DropDownList ID="State" runat="server" EnableViewState="true">
                            <%--<asp:ListItem Value="">select one</asp:ListItem>--%>
                            <asp:ListItem Value="AL">Alabama</asp:ListItem>
                            <asp:ListItem Value="AK">Alaska</asp:ListItem>
                            <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                            <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                            <asp:ListItem Value="CA">California</asp:ListItem>
                            <asp:ListItem Value="CO">Colorado</asp:ListItem>
                            <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                            <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                            <asp:ListItem Value="DE">Delaware</asp:ListItem>
                            <asp:ListItem Value="FL">Florida</asp:ListItem>
                            <asp:ListItem Value="GA">Georgia</asp:ListItem>
                            <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                            <asp:ListItem Value="ID">Idaho</asp:ListItem>
                            <asp:ListItem Value="IL">Illinois</asp:ListItem>
                            <asp:ListItem Value="IN">Indiana</asp:ListItem>
                            <asp:ListItem Value="IA">Iowa</asp:ListItem>
                            <asp:ListItem Value="KS">Kansas</asp:ListItem>
                            <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                            <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                            <asp:ListItem Value="ME">Maine</asp:ListItem>
                            <asp:ListItem Value="MD">Maryland</asp:ListItem>
                            <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                            <asp:ListItem Value="MI">Michigan</asp:ListItem>
                            <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                            <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                            <asp:ListItem Value="MO">Missouri</asp:ListItem>
                            <asp:ListItem Value="MT">Montana</asp:ListItem>
                            <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                            <asp:ListItem Value="NV">Nevada</asp:ListItem>
                            <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                            <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                            <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                            <asp:ListItem Value="NY">New York</asp:ListItem>
                            <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                            <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                            <asp:ListItem Value="OH">Ohio</asp:ListItem>
                            <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                            <asp:ListItem Value="OR">Oregon</asp:ListItem>
                            <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                            <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                            <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                            <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                            <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                            <asp:ListItem Value="TX">Texas</asp:ListItem>
                            <asp:ListItem Value="UT">Utah</asp:ListItem>
                            <asp:ListItem Value="VT">Vermont</asp:ListItem>
                            <asp:ListItem Value="VA">Virginia</asp:ListItem>
                            <asp:ListItem Value="WA">Washington</asp:ListItem>
                            <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                            <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                            <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                        </asp:DropDownList>          
                        <asp:RequiredFieldValidator runat="server" ID="StateRequired" ControlToValidate="State" ErrorMessage="State is required." CssClass="failureNotification" ToolTip="State is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    </span>
                </p>
                <p class="clear"></p>                
                <p style="margin-top:20px;">
                    <asp:Label ID="PhoneNumberLabel" runat="server" AssociatedControlID="PhoneNumber">Phone Number:</asp:Label>
                    <asp:TextBox ID="PhoneNumber" runat="server" CssClass="textEntry" EnableViewState="true" />
                    <asp:RequiredFieldValidator ID="PhoneNumberRequired" runat="server" ControlToValidate="PhoneNumber"
                        CssClass="failureNotification" ErrorMessage="Phone Number is required." ToolTip="Phone Number is required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="ZipLabel" runat="server" AssociatedControlID="State">Zip <small>(five digits minimum required)</small>:</asp:Label>
                    <span class="fLeft">
                        <asp:TextBox ID="Zip" runat="server" CssClass="textEntry" MaxLength="5" width="42" EnableViewState="true" />
                    </span>
                    <span style="float:left;text-align:center;">&nbsp;-&nbsp;</span>
                    <span class="fLeft">
                        <asp:TextBox ID="Zip2" runat="server" CssClass="textEntry" MaxLength="4" Width="42" EnableViewState="true" />&nbsp;
                    </span>
                    <span class="fLeft relative floatingErrs">
                        <asp:RequiredFieldValidator runat="server" ID="ZipRequired" ControlToValidate="Zip" ErrorMessage="Zip is required" CssClass="failureNotification" ToolTip="Zip is required" ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="ZipCodeLength" ControlToValidate="Zip" ErrorMessage="Zip Code length is incorrect." Text="Zip Code length is incorrect." OnServerValidate="ZipCodeLength_Validator" CssClass="txtFldMsg" ValidationGroup="RegisterUserValidationGroup" runat="server">Zip Code length is incorrect.</asp:CustomValidator>
                        <asp:CustomValidator ID="ZipCodeFormat" ControlToValidate="Zip" ErrorMessage="Incorrect format for Zip Code." Text="Incorrect format for Zip Code." OnServerValidate="ZipCodeInt_Validator" ValidationGroup="RegisterUserValidationGroup" CssClass="txtFldMsg" runat="server">Incorrect format for Zip Code.</asp:CustomValidator>
                    </span>
                </p>
                <p class="clear">&nbsp;</p>
                <p class="fLeftChildren">
                    <asp:checkBox ID="OptIn" runat="server" />&nbsp;<asp:Label ID="OptInLabel" runat="server" AssociatedControlID="OptIn" EnableViewState="true">Join our mailing list <small><i>(recommended, but not required)</i></small></asp:Label>
                </p>
            </div>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="CreateUserButton" Enabled="false" runat="server" CommandName="MoveNext" Text="Create User" ValidationGroup="RegisterUserValidationGroup" />
        </p>
        <p>
            <a style="color:red;text-decoration:underline;" href="<%: ResolveClientUrl("~/content/consignmentAgreement.html") %>" id="agreementLnk">Read our Consignment Agreement</a>
        </p>
    </div>
    <asp:HiddenField ID="hidAcceptedAgreement" runat="server" value="false" />
    </form>


    <script type="text/javascript">
        var submitBtn = '#<%: CreateUserButton.ClientID %>';
        var hidAcceptedAgreement = '#<%: hidAcceptedAgreement.ClientID %>';

        $(document).ready(function () {

        	$('#agreementLnk', '.accountInfo').fancybox({
				'autoDimensions' : false,
				'width' : 720,
				'height' : 450
        	});



        	submitBtn = $(submitBtn);

        	//enable buttton now
        	submitBtn.removeAttr("disabled");
        	submitBtn.attr("enabled", "enabled");

        	//assign click handler for our agreement and set hidden field value to true
        	submitBtn.click(function () {
        		if (confirm('By Continuing You Are Stating That You Have Read And Accepted Our Consignment Agreement.')) {
        			$(hidAcceptedAgreement).val("true");
        			return true;
        		}
        		else {
        			return false;
        		}
        	});
        });
    
    
    </script>


</asp:Content>
