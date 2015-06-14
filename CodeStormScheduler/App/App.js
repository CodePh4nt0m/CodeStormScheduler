 // create the module and name it scotchApp
    var app = angular.module('app', [
		//external modules
		'ngRoute', 
		
		//code storm specific modules
		'calendarModule', 
		'eventsModule', 
		'settingsModule', 
		'recommendationsModule', 
		'userProfileModule'
		
		]);
	
	// configure our routes
    app.config(function($routeProvider) {
        $routeProvider

			// route for the calendar page
            .when(app.meta.calendarModule.rootRoute, {
                templateUrl : app.meta.calendarModule.templateUrl,
                controller  : app.meta.calendarModule.controller
            })
			
            // route for the settings page
            .when(app.meta.settingsModule.rootRoute, {
                templateUrl : app.meta.settingsModule.templateUrl,
                controller  : app.meta.settingsModule.controller
            })

            // route for the events page
            .when(app.meta.eventsModule.rootRoute, {
                templateUrl : app.meta.eventsModule.templateUrl,
                controller  : app.meta.eventsModule.controller
            })
			
			//route for the recommendations page
			.when(app.meta.recommendationsModule.rootRoute, {
                templateUrl : app.meta.recommendationsModule.templateUrl,
                controller  : app.meta.recommendationsModule.controller
            })
			
			//route for the user profile page
			.when(app.meta.userProfileModule.rootRoute, {
                templateUrl : app.meta.userProfileModule.templateUrl,
                controller  : app.meta.userProfileModule.controller
            });
    });