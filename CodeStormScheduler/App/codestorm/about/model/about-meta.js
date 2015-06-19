if (scotchApp.meta === undefined) {
	scotchApp.meta = {};
}

var aboutModule = angular.module('aboutModule', []);

scotchApp.meta.aboutModule = {};
scotchApp.meta.aboutModule.rootRoute = '/about';
scotchApp.meta.aboutModule.controller = 'aboutController';
scotchApp.meta.aboutModule.templateUrl = 'codestorm/about/views/about.html';