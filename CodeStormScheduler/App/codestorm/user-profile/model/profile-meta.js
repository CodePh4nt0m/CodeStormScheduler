if (mainModule.meta === undefined) {
    mainModule.meta = {};
}

var userProfileModule = angular.module('userProfileModule', ['ngCookies', 'ngRoute', 'akFileUploader', 'common']);

userProfileModule.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/profile/edit', {
            templateUrl: '/App/codestorm/user-profile/views/profilepicture.html',
            controller: 'profilePictureController'
        })
        .when('/profile/edit/general', {
            templateUrl: '/App/codestorm/user-profile/views/generaldetails.html',
            controller: 'generalController'
        })
        .when('/profile/edit/social', {
            templateUrl: '/App/codestorm/user-profile/views/social.html',
            controller: 'otherController'
        });
    $locationProvider.html5Mode(true);
});

userProfileModule.factory("entityService", function (akFileUploaderService) {
    var savePicture = function (picture,success) {
        return akFileUploaderService.saveModel(picture, '/ProfileData/ChangeAvatar',success);
    };
    return {
        savePicture: savePicture
    };
});