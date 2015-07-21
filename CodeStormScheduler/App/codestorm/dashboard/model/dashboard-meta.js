if (mainModule.meta === undefined) {
    mainModule.meta = {};
}

var dashboardModule = angular.module('dashboardModule', ['ngCookies', 'common']);

dashboardModule.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});
