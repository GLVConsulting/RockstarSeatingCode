<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="advancedSearch.aspx.cs" Inherits="RockstarSeating.tickets.advancedSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<div style="width:530px;">
			<table border="0" cellspacing="0" cellpadding="6" class="mainpage_boxed">
				<tbody>
					<tr valign="middle">
						<td class="mainpage_header">
							Advanced Search
						</td>
					</tr>
					<tr valign="middle">
						<td class="mainpage_horiz_divider">
						</td>
					</tr>
					<tr valign="middle">
						<td class="mainpage_normal">
							Fill in any combination of the controls below.
						</td>
					</tr>
				</tbody>
			</table>

			<table cellpadding="5" cellspacing="3" border="0" width="100%" align="center" style="color: #38505a; white-space: nowrap;">
				<tbody>
					<tr>
						<td colspan="2" style="border-bottom:1px solid #ccc;padding-bottom:15px;height:1px;line-height:1px;">&nbsp;</td>
					</tr>
					<tr>
						<td colspan="2" align="left"" style="padding-top:15px;">
							<b>Keywords:</b>&nbsp;&nbsp;<input type="text" id="txtKeywords" style="width: 70%;" />
						</td>
					</tr>
					<tr>
						<td width="50%" align="left">
							<b>City: </b>&nbsp;
							<select name="City" id="City">
								<option value="">-Any-</option>
								<option value="36">Akron, OH</option>
								<option value="33">Albuquerque, NM</option>
								<option value="5">Anaheim, CA</option>
								<option value="1">Anchorage, AK</option>
								<option value="44">Arlington, TX</option>
								<option value="11">Atlanta, GA</option>
								<option value="6">Aurora, CO</option>
								<option value="44">Austin, TX</option>
								<option value="5">Bakersfield, CA</option>
								<option value="21">Baltimore, MD</option>
								<option value="19">Baton Rouge, LA</option>
								<option value="2">Birmingham, AL</option>
								<option value="20">Boston, MA</option>
								<option value="35">Buffalo, NY</option>
								<option value="4">Chandler, AZ</option>
								<option value="28">Charlotte, NC</option>
								<option value="46">Chesapeake, VA</option>
								<option value="15">Chicago, IL</option>
								<option value="5">Chula Vista, CA</option>
								<option value="36">Cincinnati, OH</option>
								<option value="36">Cleveland, OH</option>
								<option value="6">Colorado Springs, CO</option>
								<option value="36">Columbus, OH</option>
								<option value="44">Corpus Christi, TX</option>
								<option value="44">Dallas, TX</option>
								<option value="6">Denver, CO</option>
								<option value="23">Detroit, MI</option>
								<option value="28">Durham, NC</option>
								<option value="44">El Paso, TX</option>
								<option value="16">Fort Wayne, IN</option>
								<option value="44">Fort Worth, TX</option>
								<option value="5">Fremont, CA</option>
								<option value="5">Fresno, CA</option>
								<option value="44">Garland, TX</option>
								<option value="4">Glendale, AZ</option>
								<option value="5">Glendale, CA</option>
								<option value="28">Greensboro, NC</option>
								<option value="7">Hartford, CT</option>
								<option value="34">Henderson, NV</option>
								<option value="10">Hialeah, FL</option>
								<option value="12">Honolulu, HI</option>
								<option value="44">Houston, TX</option>
								<option value="16">Indianapolis, IN</option>
								<option value="10">Jacksonville, FL</option>
								<option value="32">Jersey City, NJ</option>
								<option value="25">Kansas City, MO</option>
								<option value="44">Laredo, TX</option>
								<option value="34">Las Vegas, NV</option>
								<option value="18">Lexington, KY</option>
								<option value="30">Lincoln, NE</option>
								<option value="56">London, EN</option>
								<option value="5">Long Beach, CA</option>
								<option value="5">Los Angeles, CA</option>
								<option value="18">Louisville, KY</option>
								<option value="44">Lubbock, TX</option>
								<option value="49">Madison, WI</option>
								<option value="43">Memphis, TN</option>
								<option value="4">Mesa, AZ</option>
								<option value="10">Miami, FL</option>
								<option value="49">Milwaukee, WI</option>
								<option value="24">Minneapolis, MN</option>
								<option value="5">Modesto, CA</option>
								<option value="2">Montgomery, AL</option>
								<option value="54">Montreal, QC</option>
								<option value="43">Nashville, TN</option>
								<option value="19">New Orleans, LA</option>
								<option value="35">New York, NY</option>
								<option value="32">Newark, NJ</option>
								<option value="46">Norfolk, VA</option>
								<option value="5">Oakland, CA</option>
								<option value="37">Oklahoma City, OK</option>
								<option value="30">Omaha, NE</option>
								<option value="10">Orlando, FL</option>
								<option value="61">Paris, FR</option>
								<option value="39">Philadelphia, PA</option>
								<option value="4">Phoenix, AZ</option>
								<option value="39">Pittsburgh, PA</option>
								<option value="44">Plano, TX</option>
								<option value="38">Portland, OR</option>
								<option value="28">Raleigh, NC</option>
								<option value="5">Riverside, CA</option>
								<option value="35">Rochester, NY</option>
								<option value="5">Sacramento, CA</option>
								<option value="25">Saint Louis, MO</option>
								<option value="24">Saint Paul, MN</option>
								<option value="10">Saint Petersburg, FL</option>
								<option value="44">San Antonio, TX</option>
								<option value="5">San Diego, CA</option>
								<option value="5">San Francisco, CA</option>
								<option value="5">San Jose, CA</option>
								<option value="57">San Juan, PR</option>
								<option value="5">Santa Ana, CA</option>
								<option value="4">Scottsdale, AZ</option>
								<option value="48">Seattle, WA</option>
								<option value="19">Shreveport, LA</option>
								<option value="5">Stockton, CA</option>
								<option value="10">Tampa, FL</option>
								<option value="36">Toledo, OH</option>
								<option value="53">Toronto, ON</option>
								<option value="4">Tucson, AZ</option>
								<option value="37">Tulsa, OK</option>
								<option value="46">Virginia Beach, VA</option>
								<option value="8">Washington, DC</option>
								<option value="17">Wichita, KS</option>
							</select>
						</td>
						<td>
							<b>Zip Code: </b>&nbsp;
							<input type="text" id="zip" maxlength="5" style="width: 45px;" />
						</td>
					</tr>
					<tr>
						<td>
							<div>
								<b>Category:</b>&nbsp;
								<select id="category" onchange="CatCheck();">
									<option value="">-Any-</option>
									<option value="1">Sports</option>
									<option value="2">Concerts</option>
									<option value="3">Theater</option>
								</select>
								<select id="childcategory" disabled="disabled" style="width: 130px; display: inline;">
									<option value="">-All-</option>
								</select>
								<select id="childcategory1" style="width: 130px; display: none;">
									<option value="">-All-</option>
									<option value="63">Baseball</option>
									<option value="66">Basketball</option>
									<option value="50">Boxing</option>
									<option value="90">Cricket</option>
									<option value="65">Football</option>
									<option value="67">Golf</option>
									<option value="84">Gymnastics</option>
									<option value="68">Hockey</option>
									<option value="76">Lacrosse</option>
									<option value="78">Olympics</option>
									<option value="53">Rodeo</option>
									<option value="69">Racing</option>
									<option value="77">Rugby</option>
									<option value="52">Skating</option>
									<option value="71">Soccer</option>
									<option value="27">Tennis</option>
									<option value="47">Volleyball</option>
									<option value="39">Wrestling</option>
								</select>
								<select id="childcategory2" style="width: 130px; display: none;">
									<option value="">-All-</option>
									<option value="87">50s/60s Era</option>
									<option value="22">Alternative</option>
									<option value="46">Bluegrass</option>
									<option value="55">Family Shows</option>
									<option value="49">Classical</option>
									<option value="24">Comedy</option>
									<option value="23">Country / Folk</option>
									<option value="100">Festival / Tour</option>
									<option value="61">Hard Rock / Metal</option>
									<option value="86">Holiday</option>
									<option value="21">Jazz / Blues</option>
									<option value="34">Las Vegas Shows</option>
									<option value="73">Latin</option>
									<option value="48">New Age</option>
									<option value="62">Pop / Rock</option>
									<option value="45">R&amp;B / Soul</option>
									<option value="36">Rap / Hip Hop</option>
									<option value="83">Reggae</option>
									<option value="43">Religious</option>
									<option value="98">Techno</option>
									<option value="57">World</option>
								</select>
								<select id="childcategory3" style="width: 130px; display: none;">
									<option value="">-All-</option>
									<option value="60">Ballet</option>
									<option value="70">Broadway</option>
									<option value="97">Family Shows</option>
									<option value="82">Dance</option>
									<option value="35">Las Vegas</option>
									<option value="38">Musical / Play</option>
									<option value="32">Off-Broadway</option>
									<option value="75">Opera</option>
								</select>
							</div>
						</td>
						<td>
							&nbsp;
						</td>
					</tr>
					<tr>

					<!-- TODO: convert calender images to jquery datepicker code -->

						<td valign="middle" colspan="2">
							<b>Start Date: </b>&nbsp;
							<input type="text" id="txtEventDateStart" class="dateTextBox" style="width: 100px;"/>&nbsp;
							<a href="#" onclick="cal.select(document.getElementById('txtEventDateStart'),'anchor18','M/d/yyyy', ''); return false;"
								title="Choose the Start Date" name="anchor18" id="anchor18">
								<img src="images/btn_calendar.gif" alt="Show Calendar" style="vertical-align: middle;
									border: 0;"/>
							</a>
							<div id="calDiv" style="position: absolute; background-color: white; visibility: hidden;">
							</div>
						</td>
					</tr>
					<tr>
						<td valign="middle" colspan="2" style="padding-bottom:15px;">
							<b>End Date: </b>&nbsp;
							<input type="text" id="txtEventDateEnd" class="dateTextBox" style="width: 100px;"/>&nbsp;
							<a href="#" onclick="cal.select(document.getElementById('txtEventDateEnd'),'anchor19','M/d/yyyy', document.getElementById('txtEventDateEnd').value); return false;"
								title="Choose the End Date" name="anchor19" id="anchor19">
								<img src="images/btn_calendar.gif" alt="Show Calendar" style="vertical-align: middle;
									border: 0;"/>
							</a>
							<div id="calDiv2" style="position: absolute; visibility: hidden; background-color: white;">
							</div>
						</td>
					</tr>
					<tr>
						<td colspan="2" align="center" style="border-top: 1px solid #ccc;padding-top:15px;">
							<input name="TNSearchButton" id="TNSearchButton" onclick="SubmitSearch()" style="font-weight: bold;"
								value=" Search " type="button" class="SearchSubmitButton"/>
						</td>
						<script type="text/javascript">

							// Create dates for input text(s)
							var mydate = new Date();
							var theyear = mydate.getFullYear();
							var themonth = mydate.getMonth() + 1;
							var thetoday = mydate.getDate();
							document.getElementById('txtEventDateStart').value = themonth + "/" + thetoday + "/" + theyear;
							var cal = new CalendarPopup("calDiv");
							cal.setCssPrefix("TEST");
							var yesterday = new Date();
							yesterday.setDate(yesterday.getDate() - 1);
							cal.addDisabledDates(null, value = yesterday.getMonth() + 1 + "/" + yesterday.getDate() + "/" + yesterday.getFullYear());

							var oneYear = new Date();
							oneYear.setMonth(oneYear.getMonth() + 1);
							document.getElementById('txtEventDateEnd').value = oneYear.getMonth() + 1 + "/" + oneYear.getDate() + "/" + oneYear.getFullYear();

							// Check category drop downs
							function CatCheck() {

								document.getElementById('childcategory').style.display = "none";
								document.getElementById('childcategory1').style.display = "none";
								document.getElementById('childcategory2').style.display = "none";
								document.getElementById('childcategory3').style.display = "none";
								var parent = document.getElementById('category');
								document.getElementById('childcategory' + parent[parent.selectedIndex].value).style.display = "inline";

							}
							CatCheck();
							document.getElementById('txtKeywords').onkeypress = KeyPressedSearch;
							function KeyPressedSearch(e) {
								if (e == null) e = window.event;
								if (e.keyCode == 13)
									SubmitSearch();
							}

							String.prototype.trim = function () {
								return this.replace(/^\s+|\s+$/g, "");
							}

							// Submit Search
							function SubmitSearch() {
								var kwds = document.getElementById('txtKeywords').value.trim();
								var pcatid = document.getElementById('category')[document.getElementById('category').selectedIndex].value;
								var ccatid = "";
								ccatid = document.getElementById('childcategory' + pcatid)[document.getElementById('childcategory' + pcatid).selectedIndex].value;
								var sdate = document.getElementById('txtEventDateStart').value.trim();
								var edate = document.getElementById('txtEventDateEnd').value.trim()
								var zipcode = document.getElementById('zip').value.trim();
								var citySelect = document.getElementById('City');
								var number = citySelect.selectedIndex;
								var stateProvince = citySelect.options[number].value;
								var city = "";
								if (stateProvince != "")
									city = citySelect.options[number].text.split(",")[0]

								var Qstring = "?kwds=" + kwds + "&city=" + city + "&pcatid=" + pcatid + "&ccatid=" + ccatid + "&sdate=" + sdate + "&edate=" + edate + "&zip=" + zipcode + "&stprvid=" + stateProvince + "&location=" + citySelect.options[number].text;

								if (kwds != "")
									window.location = "ResultsGeneral.aspx" + Qstring;
								else if (stateProvince != "")
									window.location = "ResultsCity.aspx" + Qstring;
								else if (zipcode != "")
									window.location = "ResultsZip.aspx" + Qstring;
								else if (pcatid != "")
									window.location = "ResultsCategory.aspx" + Qstring;
								else if (sdate != "" || edate != "")
									window.location = "ResultsDate.aspx" + Qstring;
								else
									return false;


							}

							//-->
						</script>
					</tr>
				</tbody>
			</table>
		</div>
</asp:Content>
