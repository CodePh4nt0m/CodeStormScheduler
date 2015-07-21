if (mainModule.meta === undefined) {
    mainModule.meta = {};
}

var userProfileModule = angular.module('userProfileModule', ['ngCookies', 'ngRoute', 'akFileUploader', 'common']);

userProfileModule.config(function ($locationProvider) {
    //$locationProvider.html5Mode(true);
});

userProfileModule.factory("entityService", function (akFileUploaderService) {
    var savePicture = function (picture,success) {
        return akFileUploaderService.saveModel(picture, '/ProfileData/ChangeAvatar',success);
    };
    return {
        savePicture: savePicture
    };
});