if (scotchApp.meta === undefined) {
	scotchApp.meta = {};
}

var contactModule = angular.module('contactModule', []);

scotchApp.meta.contactModule = {};
scotchApp.meta.contactModule.rootRoute = '/contact';
scotchApp.meta.contactModule.controller = 'contactController';
scotchApp.meta.contactModule.templateUrl = 'codestorm/contact/views/contact.html';