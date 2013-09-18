<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="RockstarSeating.content.widgets.header" %>


<div id="header">
	<a href="<%: ResolveClientUrl("~/Default.aspx") %>">
		<img src="<%: ResolveClientUrl("~/assets/img/hdrLogo.png") %>" alt="Rockstar Seating, Experience it for yourself!" border="0" /></a>
	<div id="tagline">"EXPERIENCE IT FOR YOURSELF!"</div>

    <asp:Panel ID="userLinksWrapper" runat="server" Visible="false" CssClass="userLinks">
        <asp:Panel ID="uploadInventoryLnk" runat="server" Visible="false" CssClass="memberLinks">
			<a href="<%: ResolveClientUrl("~/Inventory") %>">Upload Inventory</a>
		</asp:Panel>
		<asp:Panel ID="adminLnk" runat="server" Visible="false" CssClass="memberLinks">
			<a href="<%: ResolveClientUrl("~/Admin") %>">Inventory Admin</a>
		</asp:Panel>
    </asp:Panel>

	<div id="searchBoxWrapper">
		<div id="eventSearch">
			<div style="position:relative;">
				<input type="text" id="hdrSrchTxt" value="enter event, venue, or team" onclick="txtFld_Init(this)" onblur="txtFld_DeInit(this)"  onkeydown="trap_EnterKey(event);" />
				<div id="hdrSrchBtn">&nbsp;</div>
			</div>
		</div>
	</div>


	<div id="gotQuestions">
		<ul>
			<li>Have Questions? Need Help?</li>
			<li><img src="<%: ResolveClientUrl("~/assets/img/phone.png") %>" alt="" /></li>
			<li>Call Us: (800) 719-8291</li>
		</ul>	
	</div>


	<div id="hdrInfoBox">
		Have a special request? Give us a call at (800)719-8291 with any inquiries regarding particular events or with any other questions - email us at <a href="mailto:tickets@rockstarseating.com" title="tickets@rockstarseating.com">tickets@rockstarseating.com</a>, our inbox is checked 24/7.	
	</div>


	<div id="topNav">
		<ul class="leftBar">
		</ul>
	</div>
	<div class="clear"></div>
</div>