userProfileModule.controller('generalController', function ($scope, $location, $cookies, $http, $q, entityService, angularHelper) {
    $scope.message = "hi all";

    //$scope.user.gender = true;
    //$scope.user.dob = null;
    //$scope.user.location = "";
    //$scope.user.mobile = "";
    //$scope.user.profession = "";

    $scope.getGeneralDetails = function () {
        angularHelper.getData('/ProfileData/GetGeneralDetails', null,
            function (result) {
                var u = result.data;
                $scope.fname = u.fname;
                //$scope.mk = u.fname;
                //$scope.user.gender = user.gender;
                //$scope.user.dob = user.dob;
                //$scope.user.location = user.dob;
                //$scope.user.mobile = user.mobile;
                //$scope.user.profession = user.profession;
            });
    };

    

    var initialize = function () {
        $scope.getGeneralDetails();
    }

    $scope.go = function (path) {
        $location.path(path);
    };

    initialize();
});