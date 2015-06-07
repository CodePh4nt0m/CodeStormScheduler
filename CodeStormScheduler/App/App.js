var commonModule = angular.module('common', []);
var mainModule = angular.module('main', ['ngRoute']);

mainModule.controller('MainController', function ($scope, $http, $q, $routeParams, $window, $location) {
    $scope.logout = function() {
        $.ajax({
            type: 'POST',
            url: '/Account/LogOff',
            success: function() {
                location.href = "/Account/Login";
            }
        });
    };

    $scope.go = function (path) {
        $location.path(path);
    };
});