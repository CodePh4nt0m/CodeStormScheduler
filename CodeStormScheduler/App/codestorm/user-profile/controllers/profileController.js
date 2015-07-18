userProfileModule.controller('userProfileController', function ($scope, $cookies, angularHelper) {
    $scope.message = 'Yo! Look at my profile.';
    $scope.user_name = $cookies.fname;
    $scope.user_pic = $cookies.imgurl;

    var initialize = function () {
        $scope.getProfileData();
    }

    $scope.getProfileData = function () {
        angularHelper.getData('/ProfileData/GetUserProfileDetails', null,
            function (result) {
                var user = result.data;
                $scope.full_name = user.fullname;
                $scope.gender = user.gender;
                $scope.dob = user.dob;
                $scope.location = user.location;
                $scope.mobile = user.mobile;
                $scope.profession = user.profession;
                $scope.about_me = user.aboutme;
                $scope.twitter = user.twitter;

                var array = user.interests.split(',');
                $scope.interests = [];
                $.each(array, function (i, val) {
                    $scope.interests.push({ "interest" : val });
                });

            });
    }

    initialize();
});