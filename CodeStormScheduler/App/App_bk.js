var mainModule = angular.module('main', ['ngRoute']);

mainModule.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/codestorm', {
            templateUrl: 'App/codestorm/calendar/views/calendar.html',
            controller: 'MainController'
        })
        .when('/codestorm/calender', {
            templateUrl: 'App/codestorm/events/views/events.html',
            controller: 'MainController'
        });
    $locationProvider.html5Mode(true);
});

mainModule.controller('MainController', function ($scope) {
    $scope.go = function (path) {
        $location.path(path);
    };
});
