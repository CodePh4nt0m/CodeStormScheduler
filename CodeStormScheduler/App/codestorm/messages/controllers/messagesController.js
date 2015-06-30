messagesModule.controller('messagesController', function ($scope, angularHelper, chat, $cookies) {
    $scope.convheading = 'conversations';

    var initialize = function () {
        $scope.getConversationlist();
    }

    $scope.currentconv = "";

    $scope.getConversationlist = function() {
        angularHelper.getData('/MessageData/GetConversationList', null,
            function (result) {
                $scope.conversations = result.data;
            });
    }

    $scope.loadConversation = function (convid) {
        angularHelper.getData('/MessageData/GetConversation', { params: { conversation : convid } },
            function (result) {
                $scope.$apply(function () {
                    $scope.conversation = result.data;
                });
            });
    };

    $scope.viewConversation = function (convid) {
        $scope.currentconv = convid;
        $scope.loadConversation(convid);
        var chatheight = $('.chat-activity-list').prop('scrollHeight') + 'px';
        $('.chat-activity-list').slimScroll({ height: 300, scrollTo: chatheight });
    }

    $scope.sendMessage = function () {
        chat.server.send($scope.currentconv, $scope.chat_message);
        chat.server.send($cookies.userid, $scope.chat_message);
        //$scope.addOwnMessage($scope.chat_message);
        $scope.chat_message = "";
        var chatheight = $('.chat-activity-list').prop('scrollHeight') + 'px';
        $('.chat-activity-list').slimScroll({ height: 300, scrollTo: chatheight });
    };

    chat.client.addChatMessage = function onNewMessage(name, message, imgurl,self) {
        $scope.conversation.push({messageid:'0',fullname:name,message:message,imgurl:imgurl,time:new Date(),self:self});
        $scope.$apply();
        var chatheight = $('.chat-activity-list').prop('scrollHeight') + 'px';
        $('.chat-activity-list').slimScroll({ height: 300, scrollTo: chatheight });
    };

    $scope.addOwnMessage = function(message) {
        $scope.conversation.push({ messageid: '0', fullname: $cookies.fname + ' ' + $cookies.lname, message: message, imgurl: $cookies.imgurl, time: new Date(), self: true });
        $scope.$apply();
        var chatheight = $('.chat-activity-list').prop('scrollHeight') + 'px';
        $('.chat-activity-list').slimScroll({ height: 300, scrollTo: chatheight });
    }

    

    initialize();
});