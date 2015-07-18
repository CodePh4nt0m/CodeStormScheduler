userProfileModule.controller('generalController', function ($scope, angularHelper) {

    var initialize = function () {
        $scope.getGeneralDetails();
    }

    $scope.getGeneralDetails = function () {
        angularHelper.getData('/ProfileData/GetGeneralDetails', null,
            function (result) {
                var u = result.data;
                $scope.fname = u.fname;
                $scope.lname = u.lname;
                $scope.gender = u.gender;
                $scope.dob = u.dob;
                $scope.location = u.location;
                $scope.mobile = u.mobile;
                $scope.profession = u.profession;
            });
    };

    $scope.saveGeneralDetails = function () {
        var model = {
            fname: $scope.fname,
            lname: $scope.lname,
            gender: $scope.gender,
            dob: $scope.dob,
            location: $scope.location,
            mobile: $scope.mobile,
            profession: $scope.profession
        }
        angularHelper.postData('/ProfileData/SavGeneralDetails', model,
            function (result) {
                if (result == 1) {
                    $('#alert-general-success').show();
                    setTimeout(function () { $('#alert-general-success').fadeOut(1000); }, 3000);
                }
            });
    }

    $scope.$on('$viewContentLoaded', function () {
    });

    initialize();
});