if (app.meta === undefined) {
	app.meta = {};
}

var eventsModule = angular.module('eventsModule', []);

app.meta.eventsModule = {};
app.meta.eventsModule.rootRoute = '/events';
app.meta.eventsModule.controller = 'eventsController';
app.meta.eventsModule.templateUrl = 'codestorm/events/views/events.html';