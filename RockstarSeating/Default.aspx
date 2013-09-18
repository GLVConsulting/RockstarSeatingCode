<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="RockstarSeating._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
	<link rel="Stylesheet" type="text/css" href="<%: ResolveClientUrl("~/assets/Styles/home.css") %>" />
<%--	<link rel="stylesheet" type="text/css" href="<%: ResolveClientUrl("~/assets/fancybox/jquery.fancybox-1.3.4.css") %>" />
	<script type="text/javascript" src="<%: ResolveClientUrl("~/assets/fancybox/jquery.fancybox-1.3.4.pack.js") %>"></script>--%>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<div id="homePage">


	<div id="promoBox">	
		<a id="promoBoxBtn" href="#" class="pBox"><img src="<%: ResolveClientUrl("~/assets/img/buyNowBtn.png") %>" alt="Get Your Tickets Now!" /></a>
			
		<div id="promoImgs">
			<img id="img1" src="" alt="" />
		</div>

		<ul id="promoBoxNav" style="visibility:hidden;"></ul>
		
		<div id="promoTxt" class="pBox">
			<h1>&nbsp;</h1>
			<span>&nbsp;</span>
			<div>&nbsp;</div>
		</div>
		<div id="promoTxtBckgrnd">&nbsp;</div>		
	</div>


	
	<div class="bSpacer2">&nbsp;</div>

	<div id="localEvents">
		<h1><asp:Literal id="lblPluginCategory" runat="server"></asp:Literal></h1>
	    <asp:Literal ID="ticketDetail" runat="server"></asp:Literal>
	</div>


<%--
	<div id="usCity_events">
		<div class="navHdr">Find Events By City</div>
		<table cellpadding="0" style="width:530px;border:1px solid #ccc;border-width:0 1px 1px;">
			<tr>
				<td style="vertical-align:top;">
					<ul>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=atlanta&stprvid=11") %>">Atlanta</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=atlantic%20city&stprvid=32") %>">Atlantic City</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=austin&stprvid=44") %>">Austin</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=baltimore&stprvid=21") %>">Baltimore</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=boston&stprvid=20") %>">Boston</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=charlotte&stprvid=28") %>">Charlotte</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=chicago&stprvid=15") %>">Chicago</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=cincinnati&stprvid=36") %>">Cincinnati</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=cleveland&stprvid=36") %>">Cleveland</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=columbus&stprvid=36") %>">Columbus</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=dallas&stprvid=44") %>">Dallas</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=denver&stprvid=6") %>">Denver</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=detroit&stprvid=23") %>">Detroit</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=houston&stprvid=44") %>">Houston</a></li>
					</ul>
				</td>
				<td style="vertical-align:top;">
					<ul>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=indianapolis&stprvid=16") %>">Indianapolis</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=kansas%20city&stprvid=17") %>">Kansas City</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=las%20vegas&stprvid=34") %>">Las Vegas</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=los%20angeles&stprvid=5") %>">Los Angeles</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=Louisville&stprvid=18") %>">Louisville</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=memphis&stprvid=43") %>">Memphis</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=miami&stprvid=10") %>">Miami</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=minneapolis&stprvid=24") %>">Minneapolis</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=nashville&stprvid=43") %>">Nashville</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=new%20orleans&stprvid=19") %>">New Orleans</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=new%20york&stprvid=35") %>">New York</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=oakland&stprvid=5") %>">Oakland</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=orlando&stprvid=10") %>">Orlando</a></li>
					</ul>
				</td>
				<td style="vertical-align:top;">
					<ul>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=philadelphia&stprvid=39") %>">Philadelphia</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=phoenix&stprvid=4") %>">Phoenix</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=pittsburgh&stprvid=39") %>">Pittsburgh</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=portland&stprvid=38") %>">Portland</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=raleigh&stprvid=28") %>">Raleigh</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=sacramento&stprvid=5") %>">Sacramento</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=san%20antonio&stprvid=44") %>">San Antonio</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=san%20diego&stprvid=5") %>">San Diego</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=san%20francisco&stprvid=5") %>">San Francisco</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=seattle&stprvid=48") %>">Seattle</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=saint%20louis&stprvid=25") %>">St. Louis</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=tampa&stprvid=10") %>">Tampa</a></li>
						<li><a href="<%: ResolveClientUrl("~/tickets/city.aspx?city=washington%20dc&stprvid=8") %>">Washington D.C.</a></li>
					</ul>
				</td>
			</tr>		
		</table>
	
	
	
	</div>

--%>


	<div class="bSpacer2">&nbsp;</div>


	<div style="background-color:#eee;border:1px solid #ccc;color:#777;padding:10px;width:510px;">
		Rockstar Star Seating is not affiliated with any Venue, Box Office or Promoter.
		We are a third party ticket resell market place for fans to buy and sell tickets
		to the most popular events worldwide. Tickets price are set by individual sellers
		and may be above or below face value.
	</div>


	<div class="bSpacer2">&nbsp;</div>





	<div id="mainAdSlot" class="promoSpot">
		<a href="#">
			<img src="#" alt="" />
		</a>
	</div>
	

	<script type="text/javascript" src="<%: ResolveClientUrl("~/assets/scripts/home.js") %>"></script>

</div>

</asp:Content>
