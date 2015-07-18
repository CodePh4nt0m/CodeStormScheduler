var sharedEventsModule = angular.module('sharedEventsModule', ['common']);

sharedEventsModule.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});