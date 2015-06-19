if (app.meta === undefined) {
	app.meta = {};
}

var calendarModule = angular.module('calendarModule', ['ui.calendar']);

app.meta.calendarModule = {};
app.meta.calendarModule.rootRoute = '/';
app.meta.calendarModule.controller = 'calendarController';
app.meta.calendarModule.templateUrl = 'codestorm/calendar/views/calendar.html';