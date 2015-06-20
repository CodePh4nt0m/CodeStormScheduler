if (app.meta === undefined) {
	app.meta = {};
}

var calendarModule = angular.module('calendarModule', ['ui.calendar', 'multipleDatePicker']);

app.meta.calendarModule = {};
app.meta.calendarModule.rootRoute = '/codestorm/calender';
app.meta.calendarModule.controller = 'calendarController';
app.meta.calendarModule.templateUrl = '/App/codestorm/calendar/views/calendar.html';