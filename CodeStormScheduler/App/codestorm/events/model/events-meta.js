if (mainModule.meta === undefined) {
    mainModule.meta = {};
}

var eventsModule = angular.module('eventsModule', ['common']);

eventsModule.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});

//app.meta.eventsModule = {};
//app.meta.eventsModule.rootRoute = '/events';
//app.meta.eventsModule.controller = 'eventsController';
//app.meta.eventsModule.templateUrl = 'codestorm/events/views/events.html';