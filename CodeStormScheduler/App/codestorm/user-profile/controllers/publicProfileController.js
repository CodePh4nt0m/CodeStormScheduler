userPublicProfileModule.controller('publicProfileController', function ($scope, $cookies, angularHelper, $location) {

    var initialize = function () {
        $scope.getProfileData();
    }

    $scope.getProfileData = function () {
        var id = $location.search().id;
        angularHelper.getData('/ProfileData/GetUserPublicProfileDetails', { params: { id: id } },
            function (result) {
                var user = result.data;
                $scope.full_name = user.fullname;
                $scope.userid = user.userid;
                $scope.fname = user.fname;
                $scope.photo = user.photo;
                $scope.gender = user.gender;
                $scope.dob = user.dob;
                $scope.location = user.location;
                $scope.mobile = user.mobile;
                $scope.profession = user.profession;
                $scope.about_me = user.aboutme;
                $scope.twitter = user.twitter;
                $scope.email = user.email;
                var array = user.interests.split(',');
                $scope.interests = [];
                $.each(array, function (i, val) {
                    $scope.interests.push({ "interest": val });
                });

            });
    }

    initialize();
});