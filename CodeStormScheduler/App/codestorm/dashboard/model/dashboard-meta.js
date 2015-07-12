if (mainModule.meta === undefined) {
    mainModule.meta = {};
}

var dashboardModule = angular.module('dashboardModule', []);

dashboardModule.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});
