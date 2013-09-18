<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="RockstarSeating.content.contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		#contactUs a:link, #contactUs a:visited, #contactUs a:active, #contactUs a:hover
		{
			color:#6387a7;
			text-decoration:underline;	
		}
	
	</style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="contactUs">

	<h1>Rockstar Seating</h1>

	<p>
		Rockstar Star Seating is not affiliated with any Venue, Box Office or Promoter. We are a third party ticket resell market place for fans to buy and sell tickets to the most popular events worldwide. Tickets price are set by individual sellers and may be above or below face value.
	</p>

	<p>Got Questions?  Need help?  Feel free to give us a call or <a href="mailto:tickets@rockstarseating.com">email</a> us and we'll be glad to help.</p>
    <ul style="font-size:14px;">
        <li>PO BOX 78577</li>
        <li>Seattle, WA 98178</li>
        <li><b>Toll Free</b>: (800) 719-8291</li>
        <li><b>Phone</b>: (206) 268-0450</li>
        <li><b>Fax</b>: (206) 577-5399</li>
        <li><b>Email</b>: <a href="mailto:tickets@rockstarseating.com">tickets@rockstarseating.com</a></li>
    </ul>


	<div id="mainAdSlot" class="promoSpot">
		<a href="#"><img alt="" src="#" /></a>
	</div>
</div>	


<script type="text/javascript">

	$(document).ready(function () {

		$(function(){

			//code for mainAdSlot
			var arrAdImgs = new Array("accuTint.jpg", "allCityBailBonds.png", "commAuto.png", "benz_seattle.png");
			var arrAdImgLinks = [];
			arrAdImgLinks.push("http://accutint1.reachlocal.com/");
			arrAdImgLinks.push("http://www.allcitybailbonds.com/");
			arrAdImgLinks.push("http://www.communityautomotiveservice.com");
			arrAdImgLinks.push("http://www.philsmart.com/");

			var randNum = Math.floor(Math.random() * 4);
			$('img', '#mainAdSlot').attr('src', '../assets/img/adImgs/' + arrAdImgs[randNum]);
			$('a', '#mainAdSlot').attr('href', arrAdImgLinks[randNum]);

		}());
	});

</script>






</asp:Content>
