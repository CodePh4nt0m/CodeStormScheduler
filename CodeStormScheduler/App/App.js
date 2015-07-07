
var commonModule = angular.module('common', []);
var mainModule = angular.module('main', ['ngCookies', 'common']);

commonModule.factory('angularHelper', function ($http) { return CodeStorm.angularHelper($http); });

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

        self.postAsyncData = function (url, data, success, failure) {
            $.ajax({
                type: "POST",
                url: url,
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (result) {
                    success(result);
                },
                error: function () {

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
        $scope.loadnames();
    }

    function nameFormatResult(name) {
        var $state = $(
          '<span><img src="/ImageBase/Users/' + name.imgurl + '" class="img-flag" /> ' + name.text + '</span>'
        );
        return $state;
    }

    $scope.loadnames = function() {
        $("#txt_navbar_search").select2("val", "");
        var userlist = null;
        angularHelper.getData('/UserData/GetAutoCompleteUserList', null,
            function (result) {
                userlist = result.data;
                $("#txt_navbar_search").select2({
                    data: userlist,
                    formatResult: nameFormatResult,
                    placeholder: "Search",
                    allowClear: true
                });
            });
    }

    initialize();
 });