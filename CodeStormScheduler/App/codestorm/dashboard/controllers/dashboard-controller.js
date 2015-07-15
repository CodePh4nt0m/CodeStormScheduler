dashboardModule.controller('dashboardController', function ($scope, $cookies) {
    $scope.message = 'Dashboard controller.';
    $scope.userName = $cookies.fname;

    $scope.map_lat = 6.872753;
    $scope.map_lng = 79.88367;

});