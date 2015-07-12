if (mainModule.meta === undefined) {
    mainModule.meta = {};
}

var messagesModule = angular.module('messagesModule', ['ngCookies', 'ui.slimscroll', 'yaru22.angular-timeago', 'angularMoment', 'common']);
