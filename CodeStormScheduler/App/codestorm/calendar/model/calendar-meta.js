if (mainModule.meta === undefined) {
    mainModule.meta = {};
}

var calendarModule = angular.module('calendarModule', ['main']);


//calendarModule.config(function ($routeProvider, $locationProvider) {
//    $routeProvider
//        .when('/codestorm/calender', {
//            templateUrl: 'App/codestorm/views/calender.html',
//            controller: 'calendarController'
//        }).
//    otherwise({ redirectTo: '/codestorm/calender' });;
//    $locationProvider.html5Mode(true);
//});


//app.meta.calendarModule = {};
//app.meta.calendarModule.rootRoute = '/codestorm/calender';
//app.meta.calendarModule.controller = 'calendarController';
//app.meta.calendarModule.templateUrl = '/App/codestorm/calendar/views/calendar.html';