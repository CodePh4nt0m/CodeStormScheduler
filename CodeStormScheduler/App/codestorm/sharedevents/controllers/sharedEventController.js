sharedEventsModule.controller('sharedEventController', function ($scope, angularHelper) {

    var initialize = function () {
        $scope.getEvents();
    }

    $scope.getEvents = function () {
        angularHelper.getData('/EventsData/GetPendingSharedEvents', null,
            function (result) {
                $scope.eventlist = result.data;
                $scope.apply();
            });
    }

    $scope.acceptEvent = function (id,index) {
        angularHelper.postData('/EventsData/AcceptEvent', { eventid: id },
            function (result) {
                if (result == 1) {
                    location.reload();
                }
            });
    }

    $scope.rejectEvent = function (id) {
        angularHelper.postData('/EventsData/RejectEvent', { eventid: id },
            function (result) {
                if (result == 1) {
                    location.reload();
                }
            });
    }

    initialize();
});