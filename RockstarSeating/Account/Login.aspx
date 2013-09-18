<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="RockstarSeating.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div id="loginPage">
    <h2>
        Log In
    </h2>
    <p>
        Please enter your username and password.
        <a href="Register.aspx" class="link">Register</a> if you don't have an account.
    </p>

    

        <form id="loginForm" method="post" action="Login.aspx">

		<!-- err messaging -->
			<asp:Label ID="responseText" Visible="false" runat="server" CssClass="errMsg" />
            
			<asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="errMsg" 
                 ValidationGroup="LoginUserValidationGroup"/>
		<!-- err messaging -->
		
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Account Information</legend>
                    <p>
                        <asp:Label ID="EmailAddressLabel" runat="server" AssociatedControlID="EmailAddress">Email Address:</asp:Label>
                        <asp:TextBox ID="EmailAddress" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="EmailAddressRequired" runat="server" ControlToValidate="EmailAddress" 
                             CssClass="failureNotification" ErrorMessage="Email Address is required." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"/>
                </p>
            </div>
        </form>
</div>
</asp:Content>
