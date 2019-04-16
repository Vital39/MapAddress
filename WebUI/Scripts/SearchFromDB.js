//поиск по БД
$(function () {
    //function log(message) {
    //    $("<div>").text(message).prependTo("#log");
    //    $("#log").scrollTop(0);
    //}

    $("#travelto").autocomplete({
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
});