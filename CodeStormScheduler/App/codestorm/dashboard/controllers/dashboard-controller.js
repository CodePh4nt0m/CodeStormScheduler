dashboardModule.controller('dashboardController', function ($scope, $cookies, angularHelper) {
    $scope.message = 'Dashboard controller.';
    $scope.userName = $cookies.fname;

    $scope.map_lat = 6.872753;
    $scope.map_lng = 79.88367;

    function eventFormatResult(event) {
        var $state = $(
          '<span><img src="/assets/images/new-event.png?w=30&h=30&mode=max" class="img-flag" style="width:15px"/> ' + event.text + '</span>'
        );
        return $state;
    }

    angularHelper.getData('/EventsData/GetAutoCompleteEventSearchList', null,
            function (result) {
                $("#txt_home_eventsearch").select2({
                    data: result.data,
                    formatResult: eventFormatResult,
                    placeholder: "Search Event",
                    allowClear: true
                });
                $('#txt_home_eventsearch').on("select2:select", function (e) {
                });
            });
});