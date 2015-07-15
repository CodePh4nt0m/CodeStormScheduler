
var eventoutScope;

eventsModule.controller('eventsController', function ($scope, $location, angularHelper) {
    eventoutScope = $scope;
    $scope.message = 'Look! I am the Events page.';
    $scope.id = 0;
    $scope.map_lat = "6.872753";
    $scope.map_lng = "79.88367";

    var initialize = function () {
        //var id = $location.search().id;
        //$scope.getEvent(id);
        $scope.outerFunction();
    }

    $scope.outerFunction = function() {
        var id = $location.search().id;
        $scope.getEvent(id);
    }

    $scope.getEvent = function (id) {
        angularHelper.getData('/EventsData/GetEventDetails', { params: { id: id } },
            function (result) {
                $scope.id = id;
                var event = result.data;
                $scope.text = event.text;
                $scope.description = event.description;
                $scope.location = event.location;
                $scope.shared = event.shared;
                var userlist = [];
                if (event.sharedlist != null) {
                    $.each(event.sharedlist, function (i, user) {
                        userlist.push(user.userid);
                    });
                }
                if (!$scope.shared) {
                    $('#input_shared_users').val(null).trigger("change");
                    $("#input_shared_users").prop("disabled", true);
                } else {
                    $("#input_shared_users").prop("disabled", false);
                    $("#input_shared_users").val(userlist).trigger("change");
                }
                $('select[name="colorpicker"]').simplecolorpicker('selectColor', event.color);
                setMapLocation(parseFloat(event.latitude), parseFloat(event.longitude));
                $('#txt_map_lat').val(event.latitude);
                $('#txt_map_lng').val(event.longitude);
            });
    }

    $scope.Cancel = function () {
        window.location.href = "/calender";
    }

    $scope.SaveDetails = function () {
        var shareduserlist = [];
        if ($('#input_shared_users').val() != null) {
            var array = $('#input_shared_users').val().toString().split(",");
        
            $.each(array, function (i, userid) {
                shareduserlist.push({ "userid": userid });
            });
        }
        
        var model = {
            id: $scope.id,
            start_date: "",
            end_date: "",
            text: $scope.text,
            rec_type: null,
            event_length: 0,
            event_pid: 0,
            color: $('#colorpicker').val(),
            description: $scope.description,
            location: $scope.location,
            longitude: $('#txt_map_lng').val(),
            latitude: $('#txt_map_lat').val(),
            shared: $('#cb_Shared').is(":checked"),
            sharedlist: shareduserlist
        };
        angularHelper.postData('/EventsData/SaveEventDetails', model,
            function (result) {
                if (result.status == 200) {
                }
            });
        window.location.href = "/calender";
    }

    initialize();
});