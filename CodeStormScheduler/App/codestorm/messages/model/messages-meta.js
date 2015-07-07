if (mainModule.meta === undefined) {
    mainModule.meta = {};
}

var messagesModule = angular.module('messagesModule', ['ngCookies', 'ui.slimscroll', 'yaru22.angular-timeago', 'angularMoment', 'common']);

(function() {
    $(function() {
        $.connection.hub.logging = true;
        $.connection.hub.start();
    });

    $.connection.hub.error(function(err) {
        console.log('An error occurred: ' + err);
    });

    angular.module('messagesModule').value('chat', $.connection.messageHub);
})();