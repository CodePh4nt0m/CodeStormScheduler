if (mainModule.meta === undefined) {
    mainModule.meta = {};
}

var eventsModule = angular.module('eventsModule', ['common']);

eventsModule.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});