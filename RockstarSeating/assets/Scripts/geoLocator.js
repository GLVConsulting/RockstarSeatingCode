var geoCoder, userLatLng = '';

/*	DEBUG VARS	*/
var debugMode = false;
var doOnce = true;



(function() {	
	if (navigator.geolocation) {//get LatLng
		//consoleLog("we have geolocation");
		navigator.geolocation.getCurrentPosition(successCallback, errorCallback, { timeout: 10000 });
	}
	else {	//do nothing here.  screw IE...should default to Seattle. 
	}
})();
function successCallback(position) {

	

//	var geoCodeScripts = [];
//	geoCodeScripts.push('http://maps.google.com/maps/api/js?sensor=true&amp;region=US');
//	geoCodeScripts.push('http://www.google.com/jsapi');
//	geoCodeScripts.push('../assets/Scripts/gears_init.js');

//	for (xx = 0; xx < geoCodeScripts.length; xx++) {
//		var script = document.createElement('script');
//		script.type = 'text/javascript';
//		script.src = geoCodeScripts[xx];
//		consoleLog(script);

//		var headElem = document.getElementsByTagName("head")[0];
//		headElem.appendChild(script);
//	}

		


	var lat = position.coords.latitude;
	var lng = position.coords.longitude;
	var latLng = new google.maps.LatLng(lat, lng);

	//consoleLog("latLng: " + latLng);

	if (reverseGeoCode(latLng)) {
		//HERE IS WHERE WE WANT TO SHOW THE ZIP CODE SELECTOR/ENTRY
		//this not working for right some reason, but cookie is being set....
	}
	
}
function errorCallback() {
	//consoleLog("LatLng not found");
}




/*	****************************************	BEGIN: GEOCODING FUNCTIONS W/ REVERSE */
function reverseGeoCode(theCoords) {	
	geoCoder = new google.maps.Geocoder();
	if (geoCoder) {

		geoCoder.geocode({ 'latLng': theCoords
		},
		function (results, status) {
			if (status == google.maps.GeocoderStatus.OK) {
				var userLocale = (results[0].formatted_address).split(",");
				var userCity = trim(userLocale[1]);
				var userZip = trim(userLocale[2]);
				userZip = trim(userZip.substring(3));
				Set_Cookie("userZip", userZip, 365);
				if($('#inputZip').length > 0){
					$("#inputZip").val(userZip);					
				}
				//consoleLog("userZip set: " + userZip);
				geoCoder = null;
				return true;

			} else {
				var errMsg = "Geocode was not successful for the following reason: " + status;
				alert(errMsg);
			}
		});
	} else {
		alert('GeoCoder service not available at this time. \n Please. refresh your browser and try again.');
	}
	geoCoder = null;
	return false;
}
function geoCodeAddress(theZip) {
	geoCoder = new google.maps.Geocoder();
	if (geoCoder) {
			geoCoder.geocode({ 'address': theZip
		},
		function (results, status) {
			if (status == google.maps.GeocoderStatus.OK) {
				userLatLng = results[0].geometry.location;
				geoCoder = null;
				return true;
			} else {
				var errMsg = "Geocode was not successful for the following reason: " + status;
				alert(errMsg);
			}
		});
	}
	else {
		alert('GeoCoder service not available at this time. \n Please. refresh your browser and try again.');
	}
	geoCoder = null;
	return false;
}
/*	END: GEOCODING FUNCTIONS W/ REVERSE	**************************************** */




