if (mainModule.meta === undefined) {
    mainModule.meta = {};
}

var userPublicProfileModule = angular.module('userPublicProfileModule', ['ngCookies', 'ngRoute', 'akFileUploader', 'common']);

userPublicProfileModule.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});

userPublicProfileModule.factory("entityService", function (akFileUploaderService) {
    var savePicture = function (picture, success) {
        return akFileUploaderService.saveModel(picture, '/ProfileData/ChangeAvatar', success);
    };
    return {
        savePicture: savePicture
    };
});