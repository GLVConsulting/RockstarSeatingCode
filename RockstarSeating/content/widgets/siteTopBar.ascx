<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="siteTopBar.ascx.cs" Inherits="RockstarSeating.content.widgets.siteTopBar" %>


	<div id="siteTopBar">
		<div class="innerWrap">
			<ul class="leftBar">
				<li><%: DateTime.Now.ToString("dddd  MMMM dd, yyyy") %></li>
			</ul>
			<ul class="rightBar">
				<li><a href="<%: ResolveClientUrl("~/content/contactus.aspx") %>">Help</a> </li>
				<li><a href="<%: ResolveClientUrl("~/Account/Login.aspx") %>" style="font-size:14px;">Sell Tickets</a> </li>
				<li class="loginDisplay">
					<div id="welcomeMsg" runat="server" visible="false">
						<span>Welcome <%: Session["firstName"] %></span> <span>&nbsp;|&nbsp;</span> <a href="~/Account/LogOut.aspx" id="logOutLnk" runat="server">Log Out</a>
					</div>
					<a href="~/Account/Login.aspx" id="logInLnk" runat="server">Log In</a>
                 </li>
                 <li class="myAccountDisplay">
                    <a id="myAccountLnk" runat="server" visible="false" href="~/Account/myAccount.aspx">My Account</a>
                 </li>
			</ul>
		</div>
		<div id="topBar_bckgrnd">&nbsp;</div>
		<!-- END: TOP SITEWIDE NAV BAR -->
	</div>