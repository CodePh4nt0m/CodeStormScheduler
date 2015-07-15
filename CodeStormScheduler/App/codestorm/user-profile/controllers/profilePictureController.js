userProfileModule.controller('profilePictureController', function ($scope, $location, $cookies, $http, $q, entityService, angularHelper) {
    $scope.user_pic = $cookies.imgurl;

    $scope.savePicture = function (picture) {
        $('.pic-upload-progress').show();
        entityService.savePicture(picture,function(result) {
            $cookies.imgurl = result;
            homescope.user_pic = result;
            $('.pic-upload-progress').hide();
            $('.pic-upload-success').show();
            setTimeout(function () { $('.pic-upload-success').hide(); }, 2000);
        });

        $scope.clearFileUpload($('#styled-finputs-example'));
        
    };

    $scope.updateProfileCookies = function() {
        angularHelper.getData('/UserData/GetCurrentUserProfileData', null,
            function (result) {
                var user = result.data;
                $cookies.imgurl = user.imgurl;
            });
    };

    $scope.go = function (path) {
        $location.path(path);
    };

    $scope.$on('$viewContentLoaded', function () {
        $('#styled-finputs-example').pixelFileInput({ placeholder: 'No file selected...' });
        $('#styled-finputs-example').on('change', function () {
            if (this.files && this.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#profile_photo').show();
                    $('#profile_photo').attr('src', e.target.result);
                    $('#profile_blank_photo').hide();
                }

                reader.readAsDataURL(this.files[0]);
            } else {
                $('#profile_photo').hide();
                $('#profile_blank_photo').show();
            }
        });
        $('.pfi-actions .pfi-clear').click(function() {
            $('#profile_photo').hide();
            $('#profile_blank_photo').show();
        });
        $('#txt_dob').datepicker();
        $("#js-example-tags").select2({
            tags: true
        });
    });
});