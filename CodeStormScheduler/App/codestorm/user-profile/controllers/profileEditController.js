﻿userProfileModule.controller('userProfileEditController', function ($scope, $location) {
    $scope.messge = "hi all";

    $scope.go = function (path) {
        $location.path(path);
    };
});