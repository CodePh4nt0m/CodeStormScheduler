if (app.meta === undefined) {
	app.meta = {};
}

var recommendationsModule = angular.module('recommendationsModule', []);

app.meta.recommendationsModule = {};
app.meta.recommendationsModule.rootRoute = '/recommendations';
app.meta.recommendationsModule.controller = 'recommendationsController';
app.meta.recommendationsModule.templateUrl = 'codestorm/recommendations/views/recommendations.html';