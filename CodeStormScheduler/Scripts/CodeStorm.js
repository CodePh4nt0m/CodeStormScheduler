function showmessagealert(msg, sender) {
    $.notify({
        // options
        icon: 'glyphicon glyphicon-warning-sign',
        title: sender,
        message: msg,
        url: 'https://github.com/mouse0270/bootstrap-notify',
        target: '_blank'
    }, {
        // settings
        element: 'body',
        position: null,
        type: "info",
        allow_dismiss: true,
        newest_on_top: false,
        placement: {
            from: "bottom",
            align: "right"
        },
        offset: 20,
        spacing: 10,
        z_index: 1031,
        delay: 3000,
        timer: 1000,
        url_target: '_blank',
        mouse_over: null,
        animate: {
            enter: 'animated fadeInDown',
            exit: 'animated fadeOutUp'
        },
        onShow: null,
        onShown: null,
        onClose: null,
        onClosed: null,
        icon_type: 'class',
        template: '<div data-notify="container" class="col-xs-10 col-sm-3 col-lg-3 alert dmsg" role="alert">' +
            '<div class="row dmsg-not-container">' +
            '<div class="col-xs-2 dmsg-img"><img src="assets/images/mail-icon.png" class="img img-responsive img-msg"/></div>' +
            '<div class="col-xs-9 dmsg-msg">' +
            '<div class="row"><div class="col-xs-12"><span data-notify="title" class="dmsg-title">{1}</span></div></div>' +
            '<div class="row"><div class="col-xs-12"><span data-notify="message" class="dmsg-msg">{2}</span></div></div>' +
            '</div>' +
            '<div class="col-xs-1 dmsg-close"><button type="button" class="close btn-dmsg-close" data-notify="dismiss" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>' +
            '</div>' +
        '</div>'
    });
}

function shownotifyalert(msg) {
    $.notify({
        // options
        icon: 'glyphicon glyphicon-warning-sign',
        title: "Shared Event",
        message: msg,
        url: 'https://github.com/mouse0270/bootstrap-notify',
        target: '_blank'
    }, {
        // settings
        element: 'body',
        position: null,
        type: "info",
        allow_dismiss: true,
        newest_on_top: false,
        placement: {
            from: "bottom",
            align: "right"
        },
        offset: 20,
        spacing: 10,
        z_index: 1031,
        delay: 3000,
        timer: 1000,
        url_target: '_blank',
        mouse_over: null,
        animate: {
            enter: 'animated fadeInDown',
            exit: 'animated fadeOutUp'
        },
        onShow: null,
        onShown: null,
        onClose: null,
        onClosed: null,
        icon_type: 'class',
        template: '<div data-notify="container" class="col-xs-10 col-sm-3 col-lg-3 alert dnot" role="alert">' +
            '<div class="row dnot-not-container">' +
            '<div class="col-xs-2 dnot-img"><img src="assets/images/notification5.png" class="img img-responsive img-msg"/></div>' +
            '<div class="col-xs-9 dnot-msg">' +
            '<div class="row"><div class="col-xs-12"><span data-notify="title" class="dnot-title">{1}</span></div></div>' +
            '<div class="row"><div class="col-xs-12"><span data-notify="message" class="dnot-msg">{2}</span></div></div>' +
            '</div>' +
            '<div class="col-xs-1 dnot-close"><button type="button" class="close btn-dnot-close" data-notify="dismiss" aria-label="Close"><span aria-hidden="true">&times;</span></button></div>' +
            '</div>' +
        '</div>'
    });
}


var updatemessagecount = function() {
    var dataHelper = commonHelper();
    dataHelper.getData('/MessageData/GetUserUnreadMessageCount', null,
        function (result) {
            homescope.$apply(function() {
                homescope.message_count = result;
            });
        });
}

var updatenotificationcount = function () {
    var dataHelper = commonHelper();
    dataHelper.getData('/EventsData/GetPendingSharedEventCount', null,
        function (result) {
            homescope.$apply(function () {
                homescope.notification_count = result;
            });
        });
}


var mswitch = true;

$(function () {
    if (typeof chat_page == 'undefined')
        mswitch = true;

    var messagehub = $.connection.messageHub;

    messagehub.client.showMessageNotification = function (msg, sender) {
        if (mswitch) {
            updatemessagecount();
            showmessagealert(msg, sender);
            loadUserNavMessages();
        }
            
    }

    messagehub.client.showAlertNotification = function (msg, sender) {
        updatenotificationcount();
        shownotifyalert(sender + ' has shared the "' + msg + '" with you');
        loadUserNavNotifications();
    }

    $.connection.hub.start().done(function () {
        //alert('connected');
        loadUserNavNotifications();
        updatemessagecount();
        updatenotificationcount();
    });
});

$(document).ready(function() {
    $('#txt_navbar_search').on("change", function(e) {
        var id = $('#txt_navbar_search').val();
        if (id != "") {
            $("#form_publicprofile").attr("action", "user/public?id=" + id);
            $('#form_publicprofile').submit();
            //alert();
        }
    });
});

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
    });

};

function addNavNotification(notifications) {
    $('#main-navbar-notifications').empty();
    $.each(notifications, function(i, n) {
        var element = '<div class="notification">' +
            '<div class="notification-title text-warning">' + n.text + '</div>' +
            '<div class="notification-description"><strong>' + n.owner + '</strong></div>' +
            '<div class="notification-ago">' + n.date + '</div>' +
            '<div class="notification-icon fa fa-calendar bg-warning"></div>' +
            '</div>';

        $('#main-navbar-notifications').append(element);
    });
}

var loadUserNavMessages = function () {
    var dataHelper = commonHelper();
    dataHelper.getData('/MessageData/GetConversationList', null,
                function (result) {
                    addNavMessage(result);
                });
}

var loadUserNavNotifications = function () {
    var dataHelper = commonHelper();
    dataHelper.getData('/EventsData/GetUserNotificationList', null,
                function (result) {
                    //alert();
                    addNavNotification(result);
                });
}