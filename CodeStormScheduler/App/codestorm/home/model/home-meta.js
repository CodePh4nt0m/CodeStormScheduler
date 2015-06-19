if (scotchApp.meta === undefined) {
	scotchApp.meta = {};
}

var homeModule = angular.module('homeModule', []);

scotchApp.meta.homeModule = {};
scotchApp.meta.homeModule.rootRoute = '/';
scotchApp.meta.homeModule.controller = 'mainController';
scotchApp.meta.homeModule.templateUrl = 'codestorm/home/views/home.html';