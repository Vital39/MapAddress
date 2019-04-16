var source, destination;
var directionsDisplay;
var directionsService = new google.maps.DirectionsService();
var selectedMode = "DRIVING";

// initialise the location of the map on Chichester in England (ref lat and lng)
var map = new google.maps.Map(document.getElementById('dvMap'), {
    center: { lat: 50.834697, lng: -0.773792 },
    zoom: 13,
    mapTypeId: 'roadmap'
});

//подсказки в поиске
google.maps.event.addDomListener(window, 'load', function () {
    new google.maps.places.SearchBox(document.getElementById('travelfrom'));
    //new google.maps.places.SearchBox(document.getElementById('travelto'));
    directionsDisplay = new google.maps.DirectionsRenderer({ 'draggable': true });
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

    source = document.getElementById("travelfrom").value;
    destination = document.getElementById("travelto").value;

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