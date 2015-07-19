
var commonModule = angular.module('common', []);
var mainModule = angular.module('main', ['ngCookies', 'common']);

commonModule.factory('angularHelper', function ($http) { return CodeStorm.angularHelper($http); });

var commonHelper = function () { return CodeStorm.dataHelper() };

var fileModule = angular.module("akFileUploader", []);

fileModule.factory("akFileUploaderService", ["$q", "$http", function ($q, $http) {

    var getModelAsFormData = function (data) {
        var dataAsFormData = new FormData();
        angular.forEach(data, function (value, key) {
            dataAsFormData.append(key, value);
        });
        return dataAsFormData;
    };

    var saveModel = function (data, url, success) {
        var deferred = $q.defer();
        $http({
            url: url,
            method: "POST",
            data: getModelAsFormData(data),
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).success(function (result) {
            success(result);
        }).error(function (result, status) {
            deferred.reject(status);
        });
        return deferred.promise;
    };

    return {
        saveModel: saveModel
    }
}])
         .directive("akFileModel", ["$parse",
                function ($parse) {
                    return {
                        restrict: "A",
                        link: function (scope, element, attrs) {
                            var model = $parse(attrs.akFileModel);
                            var modelSetter = model.assign;
                            element.bind("change", function () {
                                scope.$apply(function () {
                                    modelSetter(scope, element[0].files[0]);
                                });
                            });
                        }
                    };
                }]);

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

        self.showMe = function () {
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
                error: function () {

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


var homescope;

mainModule.controller('MainController', function ($scope, $cookies, angularHelper) {
    homescope = $scope;
    $scope.user_name = $cookies.fname;
    $scope.user_pic = $cookies.imgurl;
    $scope.message_count = 0;

    var initialize = function () {
        $scope.loadnames();
        $scope.getNavMessages();
    }

    function nameFormatResult(name) {
        var $state = $(
          '<span><img src="/ImageBase/Users/' + name.imgurl + '?w=30&h=30&mode=max" class="img-flag" /> ' + name.text + '</span>'
        );
        return $state;
    }

    function eventFormatResult(event) {
        var $state = $(
          '<span><img src="/assets/images/new-event.png?w=30&h=30&mode=max" class="img-flag" style="width:15px"/> ' + event.text + '</span>'
        );
        return $state;
    }

    $scope.loadnames = function () {
        $("#txt_navbar_search").select2("val", "");
        $('#txt_home_eventsearch').select2("val", "");
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
        angularHelper.getData('/EventsData/GetAutoCompleteEventSearchList', null,
            function (result) {
                userlist = result.data;
                $("#txt_home_eventsearch").select2({
                    data: result.data,
                    formatResult: eventFormatResult,
                    placeholder: "Search Event",
                    allowClear: true
                });
            });
        
    }

    function addNavMessage(msglist) {
        $('.widget-messages-alt .messages-list').empty();
        $.each(msglist, function (i, msg) {
            var element = '<div class="message">' +
                        '<img src="/ImageBase/Users/' + msg.imgurl + '" alt="" class="message-avatar">' +
                            '<a href="#" class="message-subject">' + msg.message + '</a>' +
                                '<div class="message-description">' +
                                    'from <a href="#">' + msg.fullname + '</a>' +
                                '</div>' +
                                '<div class="message-time">' +
                                    '<time class="timeago" datetime="' + msg.time + '">' + msg.time + '</time>' +
                                '</div>' +
                    '</div>';
            $('.widget-messages-alt .messages-list').append(element);
            $("time.timeago").timeago();
            //$('#main-navbar-messages').slimScroll({ height: 230 });
        });

    }

    $scope.getNavMessages = function () {
        angularHelper.getData('/MessageData/GetConversationList', null,
        function (result) {
            addNavMessage(result.data);
        });
    }

    initialize();
});

