if (app.meta === undefined) {
	app.meta = {};
}

var settingsModule = angular.module('settingsModule', []);

app.meta.settingsModule = {};
app.meta.settingsModule.rootRoute = '/settings';
app.meta.settingsModule.controller = 'settingsController';
app.meta.settingsModule.templateUrl = 'codestorm/settings/views/settings.html';