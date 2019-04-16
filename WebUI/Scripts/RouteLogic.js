var source, destination;
var directionsDisplay;
var directionsService = new google.maps.DirectionsService();
var map;
var selectedMode = "DRIVING";
directionsDisplay = new google.maps.DirectionsRenderer({ 'draggable': true });

var tbPlaceFrom = 'travelFromDB';
var tbPlaceTo = 'travelToDB'

// initialise the location of the map on Chichester in England (ref lat and lng)

$(function initMap() {
    map = new google.maps.Map(document.getElementById('dvMap'), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 12
    });
    infoWindow = new google.maps.InfoWindow;
    var pos;


    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            marker = new google.maps.Marker({
                map: map,
                draggable: true,
                animation: google.maps.Animation.DROP,
                position: pos
            });
            map.setCenter(pos);
            map.setZoom(11);
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }

})

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
    infoWindow.open(map);
}

//подсказки в поиске

function setAutocompleteDB (textboxID) {
    //function log(message) {
    //    $("<div>").text(message).prependTo("#log");
    //    $("#log").scrollTop(0);
    //}

    $(textboxID).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Map/GetAddress",
                type: 'POST',
                dataType: "json",
                data: {
                    requestStr: request.term
                },
                success: function (data) {
                    response(data);
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            //log("Selected: " + ui.item.value + " aka " + ui.item.id);
        }
    });
};

$(function () {
    $('#togleFrom').change(function () {
        if ($(this).prop('checked')) {
            $('#travelFromGoogle').show();
            $('#travelFromDB').hide();
            tbPlaceFrom = 'travelFromGoogle';
        }
        else {
            $('#travelFromGoogle').hide();
            $('#travelFromDB').show();
            tbPlaceFrom = 'travelFromDB';
        }
    })
    $('#togleTo').change(function () {
        if ($(this).prop('checked')) {
            $('#travelToGoogle').show();
            $('#travelToDB').hide();
            tbPlaceTo = 'travelToGoogle';
        }
        else {
            $('#travelToGoogle').hide();
            $('#travelToDB').show();
            tbPlaceTo = 'travelToDB';
        }
    })
})
$('#travelToGoogle').hide();
$('#travelFromGoogle').hide();
setAutocompleteDB("#travelToDB");
setAutocompleteDB("#travelFromDB");
google.maps.event.addDomListener(window, 'load', function () {
    new google.maps.places.SearchBox(document.getElementById('travelToGoogle'));
    new google.maps.places.SearchBox(document.getElementById('travelFromGoogle'));
});

//новый маршрут при смене radiobutton
var rModeButtons = document.querySelector(".mode");
rModeButtons.addEventListener('change', function (e) {
    selectedMode = e.target.value;
    GetRoute();
});

//находит маршрут
function GetRoute() {

    directionsDisplay.setMap(map);

    source = document.getElementById(tbPlaceFrom).value;
    destination = document.getElementById(tbPlaceTo).value;

    var request = {
        origin: source,
        destination: destination,
        travelMode: google.maps.TravelMode[selectedMode]
    };

    directionsService.route(request, function (response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            directionsDisplay.setDirections(response);
        }
    });

    //*********DISTANCE AND DURATION**********************//
    var service = new google.maps.DistanceMatrixService();
    service.getDistanceMatrix({
        origins: [source],
        destinations: [destination],
        travelMode: google.maps.TravelMode.DRIVING,
        unitSystem: google.maps.UnitSystem.METRIC,
        avoidHighways: false,
        avoidTolls: false
    }, function (response, status) {

        if (status == google.maps.DistanceMatrixStatus.OK && response.rows[0].elements[0].status != "ZERO_RESULTS") {
            var distance = response.rows[0].elements[0].distance.text;
            var duration = response.rows[0].elements[0].duration.value;
            var dvDistance = document.getElementById("dvDistance");
            duration = parseFloat(duration / 60).toFixed(2);
            dvDistance.innerHTML = "";
            dvDistance.innerHTML += "Distance: " + distance + "<br />";
            dvDistance.innerHTML += "Time:" + duration + " min";

        } else {
            alert("Unable to find the distance via road.");
        }
    });
}