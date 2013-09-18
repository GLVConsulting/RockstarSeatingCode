<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="leftNav.ascx.cs" Inherits="RockstarSeating.content.widgets.leftNav" %>


	<div id="leftNavMenu" class="sidebar">
		<ul id="byZip" class="sidebarBox">
			<li class="navHdr">VIEW LOCAL EVENTS</li>
			<li>
				<form name="localEventsForm" id="localEventsForm" action="#" onsubmit="return false;" method="post">
					<div class="padding iBlock" style="border:none;">
						<div style="padding:5px;">
							<input id="inputZip" class="fLeft" onblur="txtFld_DeInit(this)" onclick="txtFld_Init(this)" onkeydown="checkZipInput(this, event);" type="text" value="enter your zip" />
							<div id="byZipBtn" class="fLeft">Go</div>
							<div class="clear"></div>
						</div>

						<ul id="localEventCategories">
							<li>
								<label>
									<input type="radio" checked="checked" name="category" value="2" onclick="setEventCategory(this.value);" />Concerts
								</label>
							</li>
							<li>
								<label>
									<input type="radio"name="category" value="3" onclick="setEventCategory(this.value);" />Theatre
								</label>
							</li>

							<li>
								<label>
									<input type="radio" name="category" value="1" onclick="setEventCategory(this.value);" />Sports
								</label>
							</li>
						</ul>				

					</div>
				</form>
			</li>
		</ul>

		<div id="leftNavLinks"></div>




		<img style="margin:25px 0;position:relative;left:-3px;" src="<%: ResolveClientUrl("~/assets/img/rockstar_guarantee.jpg") %>" alt="100% Satisfaction Guaranteed" />


				
		<div style="margin:30px 0;">
			<div style="text-align: center;">
				<a id="amexFPG" href="http://www.americanexpress.com/cards/online_guarantee/" target="_blank">
					<img alt="" src="<%: ResolveClientUrl("~/assets/img/img_fraud_protec_logo.gif") %>" /></a>
			</div>

			<div class="bSpacer">&nbsp;</div>

			<img alt="We Accept Most Major Credit Cards" src="<%: ResolveClientUrl("~/assets/img/creditCards.png") %>"
				style="margin: 0 0 25px;" />
		</div>





		<script type="text/javascript">

			var localEventsCategory = "2";

			function checkZipInput(dElem, e) {
				e = e || window.event || {};
				var charCode = e.charCode || e.keyCode || e.which;
				if (charCode == 13) {
					validateZipInput(dElem.value);
					return false;
				}
			}


			function validateZipInput(inputZip) {
				if (inputZip.length > 4) {

					inputZip = inputZip.substring(0, 5);

					if (!isNaN(inputZip)) {
						searchByZip(inputZip)
					}
					else {
						showInvalidZipMsg(inputZip);
					}
				}
				else {
					showInvalidZipMsg(inputZip);
				}
			}

			function showInvalidZipMsg(badZip) {
				alert("Invalid Zip Code!: " + badZip);
			}

			function searchByZip(userZip) {
				var searchUrl = '<%= ResolveClientUrl("~/tickets/category.aspx") %>' + '?pcatid=' + getEventCategory() + '&zip=' + userZip;
				Set_Cookie("userZip", userZip, 365);
				document.location.href = searchUrl;
			}
			
			function setEventCategory(eventVal) {
				localEventsCategory = eventVal;
			}
			function getEventCategory() {
				return localEventsCategory;
			}


			//this should be fine since this comes after the actual elements html markup.
			$('#byZipBtn').click(function () {
				validateZipInput($('#inputZip').val());
			});


			//now check for userZip.  If not there, attempt geoLocation...
			if (Get_Cookie("userZip") == null) {
				//					var script = document.createElement('script');
				//					script.type = 'text/javascript';
				//					script.src = '<%= ResolveClientUrl("~/assets/Scripts/geoLocator.js") %>';
				//					var headElem = document.getElementsByTagName("head")[0];
				//					headElem.appendChild(script);
			}
			else {
				$('#inputZip').val(Get_Cookie("userZip"));


				$(document).ready(function () {
					var eventCats = document.localEventsForm.category;
					var eventCategorySelection = '3';
					eventCategorySelection = '<%: pcatid %>';
					for (xx = 0; xx < eventCats.length; xx++) {
						if (eventCats[xx].value == eventCategorySelection) {
							localEventsCategory = eventCategorySelection;
							eventCats[xx].checked = true;
						}
					}
				});
			}
		
		</script>
	</div>



