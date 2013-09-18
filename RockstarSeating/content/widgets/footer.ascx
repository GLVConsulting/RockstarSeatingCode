<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer.ascx.cs" Inherits="RockstarSeating.content.widgets.footer" %>


<!--	###	BEGIN: FOOTER -->
<div id="footer">
	<ul id="topRow">
	</ul>
	<div class="clear">
	</div>
	<ul id="midRow">
		<li><a href="<%: ResolveClientUrl("~/Account/Login.aspx") %>">Sell your Tickets</a></li>
		<li><a href="<%: ResolveClientUrl("~/content/policies.aspx") %>">Policies</a></li>
		<li><a href="<%: ResolveClientUrl("~/content/contactus.aspx") %>">Contact Us</a></li>
	</ul>
	<div class="clear">
	</div>
	<ul id="bottomRow">
		<li>&copy;2011 Rockstar Seating</li>
		<li>All Rights Reserved</li>
	</ul>
	<div id="footer_bckgnd">
		&nbsp;</div>
</div>
<script type="text/javascript">

  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-4418250-2']);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();

</script>
<!--	END: FOOTER ###	-->