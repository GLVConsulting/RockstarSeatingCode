<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rightSidebar.ascx.cs" Inherits="RockstarSeating.content.widgets.rightSidebar" %>


	<div id="rtSideBar" class="sidebar">
		<div id="sellTickets">
			<div class="navHdr">Sell your Tickets Online!</div>
			<div class="padding">
				<p class="p3">3 easy steps:</p>
				<ol>
					<li>Create an account.</li>
					<li>Get Verified.</li>
					<li>Upload your tickets at will, any time, for access to millions of fans and ticket buyers!</li>
				</ol>
				<div style="line-height:10px;"><small><i>*You must have a valid credit card in order to create a ticket seller account.</i></small></div>
				<a id="consignmentLnk_rtSidebar" href="<%: ResolveClientUrl("~/Account/Register.aspx") %>">learn more...</a>
			</div>
		</div>				

		<div id="socialBtns" class="sidebarPlug">
			<div class="row">
				<div class="rtMarg20px">
					<a class="rowImgLnk facebookLnk" href="http://www.facebook.com/pages/Rockstar-Seating/135205936548200" target="_blank" title="Become our Facebook Fan">
						<img src="<%: ResolveClientUrl("~/assets/img/icons.png") %>" alt="" />
					</a>
					<a href="http://www.facebook.com/pages/Rockstar-Seating/135205936548200" target="_blank" title="Become our Facebook Fan">
						<span>Facebook</span>
					</a>
				</div>
				<div>
					<a class="rowImgLnk twitterLnk" href="http://twitter.com/rockstarseating" target="_blank" title="Join us on Twitter">
						<img src="<%: ResolveClientUrl("~/assets/img/icons.png") %>" alt="" />
						<span>Twitter</span>
					</a>	
					<a href="http://twitter.com/rockstarseating" target="_blank" title="Join us on Twitter">
						<span>Twitter</span>
					</a>
				</div>
			</div>
			<div class="row">
				<div class="rtMarg20px">
					<a class="rowImgLnk emailUsLnk" href="mailto:tickets@rockstarseating.com" title="Email Us">
						<img src="<%: ResolveClientUrl("~/assets/img/icons.png") %>" alt="" />
						<span>Email</span>
					</a>	
					<a href="mailto:tickets@rockstarseating.com" target="_blank" title="Email Us">
						<span>Email</span>
					</a>				
				</div>
				<div>
					<a class="rowImgLnk bookmarkLnk bookmark" href="#" title="Bookmark this page">
						<img src="<%: ResolveClientUrl("~/assets/img/icons.png") %>" alt="" />
						<span>Bookmark</span>
					</a>	
					<a href="#" title="Bookmark this page" class="bookmark">
						<span>Bookmark</span>
					</a>				
				</div>
			</div>		
		</div>				


		<a href="http://myworld.ebay.com/rockstarseating" style="display:block;border:1px solid #ddd;"><img src="<%: ResolveClientUrl("~/assets/img/ebay.png") %>" alt="Visit our eBay Store" /></a>

		<div class="bSpacer">&nbsp;</div>


		<div>
			<a href="http://www.positiveplace.org">
				<img src="<%: ResolveClientUrl("~/assets/img/boysNgirlsClubs.png") %>" alt="Boys and Girls Club of King County Washington" />
			</a>
		</div>
				
		<div class="bSpacer">&nbsp;</div>

		<div class="promoSpot">
			<a href="http://www.rmhc.org/">
				<img src="<%: ResolveClientUrl("~/assets/img/rmhc.jpg") %>" alt="Ronald McDonald House Charities" />
			</a>
		</div>

	</div>

		
		
