userProfileModule.controller('userProfileController', function ($scope, $cookies, angularHelper) {
    $scope.message = 'Yo! Look at my profile.';
    $scope.user_name = $cookies.fname;
    $scope.user_pic = $cookies.imgurl;
});