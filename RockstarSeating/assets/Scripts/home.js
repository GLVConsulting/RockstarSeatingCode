
$(document).ready(function () {

	//debugAlert("baseURL: " + baseURL);

	adRotator();

	var lastImg = 1, theDelay = 1000, timeoutDelay = 8, loopCnt = 0, clickTimeout = 0, len = 0;
	var url = (baseURL != '/') ? baseURL + "/assets/xml/promoBox.xml" : "/assets/xml/promoBox.xml";
	var arrSlides = [], endSlideShow = false, navClick = false;

	$.ajax({
		type: "GET",
		url: url,
		dataType: "xml",
		success: function (xml) {

			var slide;
			var expirationDate = '';
			var todaysDate = new Date();
			var today = parseInt(todaysDate.getDate());
			var thisMonth = parseInt(todaysDate.getMonth()) + 1;
			var thisYear = parseInt(todaysDate.getFullYear());
			var expDay = '', expMonth = '', expYear = '', cond1 = true, cond2 = true, cond3 = true, conditionsMet = false;

			var eventTitle = '', venue = '', img = '', url = '', desc = '';


			$(xml).find("slide").each(function (ix) {
				expDay = ''; expMonth = ''; expYear = ''; cond1 = true; cond2 = true; cond3 = true;

				expirationDate = $(this).find("expires").text();
				conditionsMet = true;

				//if (expirationDate != '') {
					//					debugAlert("\n\nday?: " + today);
					//					debugAlert("month?: " + thisMonth);
					//					debugAlert("year?: " + thisYear);

					expirationDate = expirationDate.split("/");

					//compare dates here
					expMonth = parseInt(expirationDate[0]);
					expDay = parseInt(expirationDate[1]);
					expYear = expirationDate[2];


					if (expYear.length == 2) {
						//						debugAlert("expYear??: " + expYear);
						expYear = parseInt("20" + expYear);
					}
					else {
						//						debugAlert("expYear(len): " + expYear.length + "\t\texpYear: " + expYear);
					}

					//					debugAlert("expMonth: " + expMonth);
					//					debugAlert("expDay: " + expDay);
					//					debugAlert("expYear: " + expYear);

					//					debugAlert("thisMonth: " + thisMonth + "\t\texpMonth: " + expMonth);
					//					debugAlert(cond1 + "\t\t" + cond2 + "\t\t" + cond3);


//					if (thisYear < expYear) {
//						conditionsMet = true;
//					}
//					else if (thisYear == expYear) {
//						if (thisMonth < expMonth) {
//							conditionsMet = true;
//						}
//						else if (thisMonth == expMonth) {
//							if (today <= expDay) {
//								conditionsMet = true;
//							}
//						}
//					}

				//}

				eventTitle = $(this).find("title").text();
				if (conditionsMet) {

					/*
					slide(title, venue, eventdate, img, url, desc)
					0,		1,		2,		3,	4,	5		
					*/
					eventTitle = $(this).find("title").text();
					desc = $(this).find("description").text();
					venue = $(this).find("venue").text();
					eventDate = $(this).find("eventDate").text();
					img = $(this).find("img").text();
					url = $(this).find("url").text();


					//slide needs to have a title, img, and url at the least
					if (eventTitle != '' && img != '' && url != '') {
						slide = new Array(5);

						if (venue != '' && venue.toLowerCase() != "nationwide") {
							var venueHtml = [];
							venueHtml.push(eventTitle);
							venueHtml.push(" @ " + venue);
							slide[0] = venueHtml.join('');
						}
						else { slide[0] = eventTitle; }

						slide[1] = (eventDate != '') ? eventDate : false;
						slide[2] = img;
						slide[3] = url;
						slide[4] = (desc != '') ? desc : false;
						arrSlides.push(slide);
						//						debugAlert("slide was pushed: " + eventTitle + "\r\r");
					}
				}


			}); //end xml parse loop

			len = arrSlides.length;
			//			debugAlert("len: " + len);
			if (len > 2) {
				setupSlides();
			}
		} //end sucess clause
	});


	//for the home page
	function adRotator(){

		//code for mainAdSlot
		var arrAdImgs = new Array("accuTint.jpg", "allCityBailBonds.png", "commAuto.png", "benz_seattle.png");
		var arrAdImgLinks = [];
		arrAdImgLinks.push("http://accutint1.reachlocal.com/");
		arrAdImgLinks.push("http://www.allcitybailbonds.com/");
		arrAdImgLinks.push("http://www.communityautomotiveservice.com");
		arrAdImgLinks.push("http://www.philsmart.com/");

		var randNum = Math.floor(Math.random() * 4);
		$('img', '#mainAdSlot').attr('src', 'assets/img/adImgs/' + arrAdImgs[randNum]);
		$('a', '#mainAdSlot').attr('href', arrAdImgLinks[randNum]);

	}



	/*
	slide(title @ venue, eventdate, img, url, desc)
	0,				1,		2,		3,	4
	*/
	function setupSlides() {
		var slide, img, template = [];
		var promoBoxImgs = baseURL + '/assets/img/promobox/';

		len = (len > 4) ? 4 : len;

		for (var ix = 0; ix < len; ix++) {
			slide = arrSlides[ix];
			img = slide[2];

			// set slide one on front end
			if (ix == 0) {

				//title @ venue
				$('h1', '#promoTxt').html(slide[0]);

				//eventDate
				if (slide[1] != false) {
					$('div', '#promoTxt').html(slide[1]);
				}

				//desc
				if (slide[4] != false) {
					$('span', '#promoTxt').html(slide[4]);
				}

				$('#img1', '#promoImgs').attr('src', promoBoxImgs + img).css('z-index', (len + 1)).show();

				$('#promoBoxBtn', '#promoBox').attr('href', slide[3]);
			}
			else {
				img = '<img src="' + promoBoxImgs + img + '" alt="" id="img' + (ix + 1) + '" />';
				template.push(img);
			}
		}

		//now add the images to the DOM
		$("#promoImgs", "#promoBox").append(template.join(''));

		//reStack the images for the fadeIn
		for (var cnt = len; cnt > 0; cnt--) {
			imgId = cnt;
			zIndex = cnt + 1;

			$('#img' + imgId, '#promoImgs').css('z-index', zIndex);
		}


		buildNavBtns();

		timeoutDelay = theDelay * timeoutDelay;

		//initial call to change slide
		setTimeout(function () { callSlide(2) }, timeoutDelay);



	} //end setupSlides()




	//----------------------------------------------------------------------
	function callSlide(dSlide) {

		var slideDelay = theDelay + 200;

		//fade out last image
		$('#img' + lastImg).fadeOut(theDelay).css('z-index', 1);

		//fade in new img
		dSlide = (dSlide > len) ? 1 : dSlide;
		$('#img' + dSlide).fadeIn().show(slideDelay);

		if (!endSlideShow) {
			setTimeout(transitionSlide, slideDelay);
			loopCnt += 1;
			lastImg = parseInt(dSlide);
		}
		else {

		}
	}
	function pBoxNav_Click(dSlide) {
		navClick = true;

		var slideDelay = theDelay + 200;

		//fade out last image
		$('#img' + lastImg).fadeOut(theDelay).css('z-index', 1);

		//fade in new img
		$('#img' + dSlide).fadeIn().show(slideDelay);
		setTimeout(transitionSlide, slideDelay);

		lastImg = parseInt(dSlide);

	}
	//----------------------------------------------------------------------



	function transitionSlide() {
		clickTimeout = 0;
		if (loopCnt == len) {
			endSlideShow = true;
		}


		var slideInfo = arrSlides[lastImg - 1];

		$('.pBox', '#promoBox').hide();
		$('#promoBoxNav', '#promoBox').css("visibility", "hidden");

		//hide bckgrnd, change slideInfo, re-show
		$('#promoTxtBckgrnd', '#promoBox').slideToggle(theDelay, function () {

			//eventTitle - xml must have
			$('#promoTxt h1', '#promoBox').html(slideInfo[0]);

			//eventDate
			if (slideInfo[1] != false) {
				$('div', '#promoTxt').html(slideInfo[1]).show();
			}
			else {
				$('div', '#promoTxt').hide();
			}

			//desc
			if (slideInfo[4] != false) {
				$('span', '#promoTxt').html(slideInfo[4]).show();
			}
			else {
				$('span', '#promoTxt').hide();
			}

			//slide url
			$('#promoBoxBtn', '#promoBox').attr('href', baseURL + slideInfo[3]);

			//now show new slideInfo
			$('#promoTxtBckgrnd', '#promoBox').slideToggle(theDelay, showText);
		});



		if (!endSlideShow) {
			setTimeout(function () { callSlide(parseInt(lastImg) + 1); }, timeoutDelay);
		}
	}





	function buildNavBtns() {
		var navBtn_tmpl = [];
		for (var navBtnCnt = 1; navBtnCnt <= len; navBtnCnt++) {
			navBtn_tmpl.push('<li id="' + (navBtnCnt) + '">' + navBtnCnt + '</li>');
		}

		$('#promoBoxNav', '#promoBox').append(navBtn_tmpl.join(''));

		//assign event handler to navbutton
		$('li', '#promoBoxNav').click(function () {
			//change slide w/ clickyUser blocker
			if (clickTimeout == 0) {

				var theSlide = $(this).html();

				//reset all btns
				$('li', '#promoBoxNav').removeClass("active");

				//now set active state
				$(this).addClass("active");

				clickTimeout = setTimeout(function () {
					if (parseInt(theSlide) == parseInt(lastImg)) { return false; }
					pBoxNav_Click(theSlide);
				}, theDelay + 200);

			}
		});
	}



	function showText() {
		$('.pBox', '#promoBox').show().css("visibility", "visible");

		if (endSlideShow && !navClick) {
			$('li#1', '#promoBoxNav').addClass("active");
			$('#promoBoxNav', '#promoBox').css("visibility", "visible");
		}
		else if (navClick) {
			$('#promoBoxNav', '#promoBox').css("visibility", "visible");
		}
	}


});                                                                              //end docReady