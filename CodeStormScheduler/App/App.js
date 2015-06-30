// create the module and name it scotchApp
var commonModule = angular.module('common', []);
var mainModule = angular.module('main', ['common', 'ngRoute', 'ngCookies']);

commonModule.factory('angularHelper', function ($http) { return CodeStorm.angularHelper($http); });
 // configure our routes
 //app.config(function ($routeProvider, $locationProvider) {
 //    $routeProvider

 //    // route for the calendar page
 //    //    .when(app.meta.calendarModule.rootRoute, {
 //    //    templateUrl: app.meta.calendarModule.templateUrl,
 //    //    controller: app.meta.calendarModule.controller
 //    //})

 //    // route for the settings page
 //    .when(app.meta.settingsModule.rootRoute, {
 //        templateUrl: app.meta.settingsModule.templateUrl,
 //        controller: app.meta.settingsModule.controller
 //    })

 //    // route for the events page
 //    .when(app.meta.eventsModule.rootRoute, {
 //        templateUrl: app.meta.eventsModule.templateUrl,
 //        controller: app.meta.eventsModule.controller
 //    })

 //    //route for the recommendations page
 //    .when(app.meta.recommendationsModule.rootRoute, {
 //        templateUrl: app.meta.recommendationsModule.templateUrl,
 //        controller: app.meta.recommendationsModule.controller
 //    })

 //    //route for the user profile page
 //    .when(app.meta.userProfileModule.rootRoute, {
 //        templateUrl: app.meta.userProfileModule.templateUrl,
 //        controller: app.meta.userProfileModule.controller
 //    });

 //    $locationProvider.html5Mode(true);
//});

var commonHelper = function () { return CodeStorm.dataHelper() };


(function (codestorm) {
    var dataHelper = function () {
        var self = this;

        self.getData = function (url, data, success, failure) {
            $.ajax({
                url: url,
                type: 'GET',
                data: data,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    success(result);
                },
                error: function () {
                    
                }
            });
        }

        self.showMe = function() {
            alert('I am working');
        }

        self.postData = function (url, data, success, failure) {
            $.ajax({
                type: "POST",
                url: url,
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    success(result);
                },
                error : function() {
                    
                }
            });
        }

        self.findIndexByKey = function (array, property, value) {
            for (var i = 0; i < array.length; i++) {
                if (array[i][property] == value) {
                    return i;
                }
            }
            return null;
        }

        self.replaceValue = function (array, id, idvalue, property, newvalue) {
            for (var i = 0; i < array.length; i++) {
                if (array[i][id] == idvalue) {
                    array[i][property] = newvalue;
                    return;
                }
            }
        }

        self.insertObj = function (array, index, item) {
            array.splice(index, 0, item);
        }

        return this;
    }

    var angularHelper = function ($http) {
        var self = this;

        self.getData = function (url, data, success, failure) {
            $http.get(url, data)
                .then(function (result) {
                    success(result);
                });
        }


        self.postData = function (url, data, success) {
            $http.post(url, data)
                .then(function (result) {
                    success(result);
                });
        }

        self.findIndexByKey = function (array, property, value) {
            for (var i = 0; i < array.length; i++) {
                if (array[i][property] == value) {
                    return i;
                }
            }
            return null;
        }

        self.replaceValue = function (array, id, idvalue, property, newvalue) {
            for (var i = 0; i < array.length; i++) {
                if (array[i][id] == idvalue) {
                    array[i][property] = newvalue;
                    return;
                }
            }
        }

        self.insertObj = function (array, index, item) {
            array.splice(index, 0, item);
        }

        return this;
    }

    codestorm.dataHelper = dataHelper;
    codestorm.angularHelper = angularHelper;
}(window.CodeStorm));

mainModule.controller('MainController', function ($scope, $cookies, angularHelper) {
    $scope.user_name = $cookies.fname;
    var initialize = function () {
        var usr = $cookies.userid;
        if (usr == null) {
            angularHelper.getData('/UserData/GetCurrentUserProfileData', null,
            function (result) {
                var user = result.data;
                $cookies.userid = user.userid;
                $cookies.fname = user.fname;
                $cookies.lname = user.lname;
                $cookies.imgurl = user.imgurl;
                $scope.user_name = user.fname;
            });
        }
    }

    initialize();
 });