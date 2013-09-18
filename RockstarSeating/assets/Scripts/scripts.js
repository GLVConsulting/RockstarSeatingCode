/* global vars */
var debugMode = false;
var dUrl = document.location.href.toLowerCase();

$(document).ready(function () {

	var leftNavMainBG = 'url(' + baseURL + '/assets/img/leftNavMainBG.jpg) top left repeat-y';
	var rtNavMainBG = 'url(' + baseURL + '/assets/img/rtNavMainBG.jpg) top left repeat-y';
	//remove leftNav if in adminSection or uploading inventory
	if (verifyUrl("/admin/") || verifyUrl("resultsticket")) {
		//if on ticketRequestForm
		if ($('.tn_results_notfound', '#content').length > 0) {
			document.getElementById('main').style.background = rtNavMainBG;
			$('#rtSideBar').show();
		}
		else {
			document.getElementById('content').style.width = '940px';
			document.getElementById('main').style.background = 'none';
			document.getElementById('content').style.height = '1000px';
		}
	}
	else {
		if (verifyUrl("register.aspx")) {
			document.getElementById('main').style.background = rtNavMainBG;
			$('#rtSideBar').show();
		}
		else if (verifyUrl("myaccount.aspx") || verifyUrl("/inventory")) {
			document.getElementById('leftNavMenu').style.display = 'inline-block';
			document.getElementById('main').style.background = leftNavMainBG;
		}
		else {
			document.getElementById('content').style.width = '542px';
			$('#rtSideBar').show();
			document.getElementById('leftNavMenu').style.display = 'inline-block';
		}
	}

	$("a.bookmark", "#rtSideBar").click(function (e) {
		e.preventDefault(); // this will prevent the anchor tag from going the user off to the link
		var bookmarkUrl = "http://www.rockstarseating.com";
		var bookmarkTitle = "Rockstar Seating, Experience it for yourself";
 
		if (window.sidebar) { // For Mozilla Firefox Bookmark
			window.sidebar.addPanel(bookmarkTitle, bookmarkUrl,"");
		} else if( window.external || document.all) { // For IE Favorite
			window.external.AddFavorite( bookmarkUrl, bookmarkTitle);
		} else { // for other browsers which does not support
			 alert('Your browser does not support this bookmark action');
			 return false;
		}
	});


});



function verifyUrl(strUrl){
	if(dUrl.indexOf(strUrl) > 0){ return true; }
	else{ return false; }
}

function debugAlert(strMsg) {
	if ((typeof(console) != "undefined") && debugMode){
        console.log(strMsg);
    }
}
function consoleLog(strMsg) {
	if (typeof (console) != "undefined") {
        console.log(strMsg);
    }
}


function buildNavigationMenus(strBaseUrl) {
    debugAlert('enter func buildNavigationMenus');
    baseURL = strBaseUrl;

    var url = strBaseUrl + "/assets/xml/navigationMenus.xml";

    $.ajax({
        type: "GET",
        url: url,
        dataType: "xml",
        success: function (xml) {
            buildTopNav(xml);
            buildLeftNav(xml);

        } //end sucess clause
    });
 }




 function getQueryString(ji) {
 	hu = window.location.search.substring(1);
 	gy = hu.split("&");
 	for (i = 0; i < gy.length; i++) {
 		ft = gy[i].split("=");
 		if (ft[0] == ji) {
 			return ft[1];
 		}
 	}
 }

 

function buildTopNav(xmlData) {
    debugAlert('enter func buildTopnav');

    var template = [], catId = '', linkURL = '', linkTxt = '', cssClass = '';
    var topNavXML = $(xmlData).find('topNav');
    var baseId = ["topnav_", "footer_"];
    var pcatid = '', ccatid = '';

    if (topNavXML < 1) {
        alert('no data');
        return;
    }

    for (var cnt = 0; cnt < 2; cnt++) {

    	$(topNavXML).find('menuItem').each(function (ix) {
															 
    		catId = (typeof($(this).attr("id")) != 'undefined') ? $(this).attr("id") : "";
    		pcatid = (catId.indexOf("_") > 0) ? catId.substring(0, catId.indexOf("_")) : catId;
    		ccatid = (catId.indexOf("_") > 0) ? catId.substring(catId.indexOf("_") + 1) : "";		    					
			linkURL = (typeof($(this).attr("url")) != 'undefined') ? linkURL : "/tickets/category.aspx?pcatid=" + pcatid + "&ccatid=" + ccatid;
			
    		linkTxt = $(this).text();
    		cssClass = $(this).attr("class");
			if (typeof (cssClass) != "undefined") {
				cssClass = ' class="' + cssClass + '"';
			}
			else { cssClass = ''; }
			
			if(catId == "" && typeof($(this).attr("url")) != 'undefined'){
				linkURL = $(this).attr("url");				
			}
			
			if (linkURL != "" && linkTxt != "") {
				template.push('<li id="' + baseId[cnt] + linkTxt.toLowerCase() + '"' + cssClass + '>');
				template.push('<a href="' + baseURL + linkURL + '">' + linkTxt + "</a>");
				template.push("</li>");
			}
			else {
/*    			debugAlert("\r\r-------------------------linkTxt: " + linkTxt);
				debugAlert("linkURL: " + linkURL);
				debugAlert("elemId: " + elemId);*/
			}	
    	});

        //add navigation elements
        if (cnt == 0) {
        	var topNavElem = $("#topNav .leftBar");
        	topNavElem.html(template.join(''));
        }
        else {
            document.getElementById('topRow').innerHTML = template.join('');
        }
        template = [];
    }


    //manual garbage collection
    template = null;


}



function buildLeftNav(xmlData) {
    debugAlert('enter func buildTopnav');

    var template = [], elemId = '', linkUrl = '', linkTxt = '', menuHdr, cssClass = '';
    var navXML = $(xmlData).find('leftNav');

    if (navXML < 1) {
        alert('no data');
        return;
    }


    $(navXML).find('navItem').each(function (ix) {
    	menuHdr = $(this).find('menuHdr');

    	if (menuHdr != "") {
    		//add navHeader
    		template.push('<ul><li class="navHdr">');

    		var menuHdrLnk = menuHdr.attr("url");
    		if (typeof (menuHdrLnk) != "undefined") {
    			template.push('<a href="' + baseURL + '/tickets/search.aspx?kwds=' + menuHdrLnk + '">' + menuHdr.text() + '</a></li>');
    		}
    		else {
    			template.push('<a href="' + menuHdr.text() + '">' + menuHdr.text() + '</a></li>');
    		}

    		template.push('<li><ul style="margin:5px 0;">');
    		//add navMenuItems
    		$(this).find('menuItem').each(function () {

    			elemId = $(this).attr('id');
    			linkTxt = $(this).text();


    			if (linkTxt != "") {
    				var strURL = "";
    				template.push('<li ' + cssClass + '>');

    				if (linkTxt.toLowerCase().indexOf("tickets") > -1) {
    					strURL = baseURL + "/tickets/search.aspx?kwds=" + linkTxt.substring(0, linkTxt.toLowerCase().indexOf("tickets"));
    				}
    				else {
    					strURL = baseURL + "/tickets/search.aspx?kwds=" + linkTxt;

    				}
					
					linkURL = strURL;

    				template.push('<a href="' + linkURL + '">' + linkTxt + "</a>");
    				template.push("</li>");
    			}
    		});
    		template.push("</ul></li></ul>");
    	}
    });

    //add navigation elements
    $('#leftNavLinks').append(template.join(''));

    //manual garbage collection
    template = null;

} //end buildLeftNav()





/**    BEGIN: leftNav SearchBar   **/


/* ####################################	TODO:

		specific search by tab title
 ##########################################	*/

function searchFrmSubmit(dJQueryElem) {	
	searchTerm = $('#hdrSrchTxt', '#searchBoxWrapper').val();

	if (searchTerm != "") {
		document.location.href = baseURL + '/tickets/search.aspx?kwds=' + searchTerm;
	}
	else {
		return false;
	}
	
}
function trap_EnterKey(e){
    e = e || window.event || {};
    var charCode = e.charCode || e.keyCode || e.which;
    if (charCode == 13) {
        searchFrmSubmit();
    }
}


/**    END: leftNav SearchBar   **/




/***************	BEGIN: Mailing List Submission	*****************************/

$('#btn_emailList', '#mailingList').click(function () {
	addToMailingList();
});


function validateEmail(elementValue) {
	var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
	return emailPattern.test(elementValue);
}




function addToMailingList() {
	var emailAddress = $('#emailAddress_mailingList').val();

	var validEmailAddress = validateEmail(emailAddress);

	if (emailAddress != '' && validEmailAddress) {

		var url = baseURL + "/dataFiles/joinMailingList.aspx?a=1&e=" + emailAddress;
		$.ajax({
			type: "GET",
			url: url,
			dataType: "text",
			success: function (result) {

				var dElem = $('#mailingListWrapper');
				var userMsg = '';

				if (result == "true") {
					userMsg = '<b>Thanks!</b>';
				}
				else if (result == "err") {
					userMsg = '<span style="color:red;">Error!</span>&nbsp;<small>please refresh and try again</small>';
				}
				else {
					userMsg = '<small style="color:red;">' + result + '</small>';
				}

				dElem.html(userMsg);
			}
		});
	}
	else {
		alert("invalid email address: " + emailAddress);
	}
}//end addToMailingList()

var dVal;
function txtFld_Init(dElem) {
	dVal = dElem.value;
	dElem.value = '';

}
function txtFld_DeInit(dElem) {
	if (dElem.value == '') {
		dElem.value = dVal;
	}
}
function emailAddr_EnterKey(e) {
    e = e || window.event || {};
    var charCode = e.charCode || e.keyCode || e.which;
    if (charCode == 13) {
    	addToMailingList();   
    }
}

/***************	END: Mailing List Submission	*****************************/


//TODO:  man, gotta refactor this code!!!





/***************	BEGIN: Sell Tickets Button	*****************************/


$(document).ready(function () {

	//add viewBtn img
	$('td.tn_results_tickets_text a', 'table.tn_results').html('<img src="' + baseURL + '/assets/img/viewBtn.png" title="View Tickets For This Event!" alt="" />');

	//add a sellBtn to each event row, no <a> tag to prevent crawling
	$('td.tn_results_tickets_text', 'table.tn_results').append('<img class="sellBtn" src="' + baseURL + '/assets/img/sellBtn.jpg" alt="" title="Sell Your Tickets To This Event!" />');


	//now add click handler
	$('.sellBtn', 'td.tn_results_tickets_text').click(function () {

		//first need to check for eventTime listed as TBD
		var parentElem = $(this).parent().parent();
		var eventTime = $('span.tn_results_time_text', parentElem).html();

		if (eventTime.toLowerCase() == "tbd") {
			alert("Sorry, you cannot list tickets to this event at this time.  Please check back later");
		}
		else {

			var qParams = [];
			qParams.push("?autofill=yes");

			var eventTxt = '';
			eventTxt = $('td.tn_results_event_text', parentElem).html();


			if (eventTxt.indexOf("href") != eventTxt.lastIndexOf("href")) {
				var dTxt = [];
				$('td.tn_results_event_text', parentElem).find("a").each(function () {
					dTxt.push($(this).html());
				});

				eventTxt = dTxt[0] + " Vs. " + dTxt[1];

				//$('td.tn_results_event_text', parentElem).css('background-color', 'red');
			}
			else {
				eventTxt = $('td.tn_results_event_text a', parentElem).html();
			}
			qParams.push("&event=" + eventTxt);

			var venueTxt = $('td.tn_results_venue_text a', parentElem).html();
			qParams.push("&venue=" + venueTxt);

			var eventDate = $('span.tn_results_date_text', parentElem).html();
			qParams.push("&eventDate=" + eventDate);

			var eventTime = $('span.tn_results_time_text', parentElem).html();
			qParams.push("&eventTime=" + eventTime);

			qParams = qParams.join('');
			document.location.href = baseURL + "/inventory/default.aspx" + qParams;
		}

	});

});
/***************	END: Sell Tickets Button	*****************************/




function Get_Cookie(check_name) {
	var a_all_cookies = document.cookie.split(";");
	var a_temp_cookie = "";
	var cookie_name = "";
	var cookie_value = null;
	var b_cookie_found = false;

	for (i = 0; i < a_all_cookies.length; i++) {
		a_temp_cookie = a_all_cookies[i].split("=");
		cookie_name = a_temp_cookie[0].replace(/^\s+|\s+$/g, "");

		if (cookie_name == check_name) {
			b_cookie_found = true;
			if (a_temp_cookie.length > 1) {
				cookie_value = unescape(a_temp_cookie[1].replace(/^\s+|\s+$/g, ""));
			}
			break;
		}

		a_temp_cookie = null;
		cookie_name = "";
	}
	return cookie_value;
}

function Set_Cookie(name, value, expires) {
	var today = new Date;
	today.setTime(today.getTime());

	/*
	if the expires variable is set, make the correct expires time, the current script below will set
	it for x number of days, to make it for hours, delete * 24, for minutes, delete * 60 * 24
	*/

	if (expires) {
		expires = parseInt(expires) * 1000 * 60 * 60 * 24;
	}

	var expires_date = new Date(today.getTime() + expires);
	document.cookie = name + "=" + escape(value) + ";path=/" + (expires ? ";expires=" + expires_date.toGMTString() : "");
}
function Delete_Cookie(name, path, domain) {
	if (Get_Cookie(name)) document.cookie = name + "=" +
((path) ? ";path=" + path : "") +
((domain) ? ";domain=" + domain : "") +
";expires=Thu, 01-Jan-1970 00:00:01 GMT";
}


function trim(str, chars) {
	return ltrim(rtrim(str, chars), chars);
}

function ltrim(str, chars) {
	chars = chars || "\\s";
	return str.replace(new RegExp("^[" + chars + "]+", "g"), "");
}

function rtrim(str, chars) {
	chars = chars || "\\s";
	return str.replace(new RegExp("[" + chars + "]+$", "g"), "");
}


