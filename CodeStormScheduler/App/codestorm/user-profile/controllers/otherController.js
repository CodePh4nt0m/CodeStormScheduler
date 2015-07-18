userProfileModule.controller('otherController', function ($scope, angularHelper) {

    var initialize = function () {
        $scope.getSocialDetails();
    }

    $scope.getSocialDetails = function () {
        angularHelper.getData('/ProfileData/GetUserSocialDetails', null,
            function (result) {
                var u = result.data;
                $scope.about_me = u.aboutme;
                $scope.twitter = u.twitter;
                $scope.facebook = u.facebook;
                $('#js-example-tags').val(u.interests).trigger("change");
            });
    };

    $scope.saveSocialDetails = function () {
        var model = {
            aboutme: $scope.about_me,
            twitter: $scope.twitter,
            facebook: $scope.facebook,
            interests: $('#js-example-tags').val()
        };
        angularHelper.postData('/ProfileData/SaveSocialDetails', model,
            function (result) {
                if (result == 1) {
                    $('#alert-general-success').show();
                    setTimeout(function () { $('#alert-general-success').fadeOut(1000); }, 3000);
                }
            });
    };

    initialize();
});