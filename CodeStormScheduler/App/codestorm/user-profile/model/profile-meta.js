if (app.meta === undefined) {
	app.meta = {};
}

var userProfileModule = angular.module('userProfileModule', []);

app.meta.userProfileModule = {};
app.meta.userProfileModule.rootRoute = '/profile';
app.meta.userProfileModule.controller = 'userProfileController';
app.meta.userProfileModule.templateUrl = 'codestorm/user-profile/views/profile.html';