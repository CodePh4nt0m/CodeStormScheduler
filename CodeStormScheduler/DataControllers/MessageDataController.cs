﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeStormData;
using CodeStormData.Data;
using CodeStormData.ViewModels;
using Microsoft.AspNet.Identity;

namespace CodeStormScheduler.DataControllers
{
    public class MessageDataController : Controller
    {

        [HttpGet]
        public JsonResult GetConversationList()
        {
            string userid = User.Identity.GetUserId();
            MessageData msgData = new MessageData();
            var result = msgData.GetConversationList(userid);
            var conversationlist = result.Select(c => new ConversationListViewModel()
            {
                convid = c.Id,
                fullname = c.Sender,
                imgurl = c.ImageUrl,
                message = SplitMesage(c.Message),
                time = c.CDate.ToString("G")
            }).ToList();
            return Json(conversationlist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetConversation(string conversation)
        {
            string userid = User.Identity.GetUserId();
            MessageData msgData = new MessageData();
            var result = msgData.GetConversation(userid,conversation);
            var conversationlist = result.Select(c => new ConversationViewModel()
            {
                messageid = c.MessageId,
                fullname = c.FullName,
                imgurl = c.ImageUrl,
                message = c.Message,
                time = c.CDate.ToString(""),
                self = c.Self
            }).ToList();
            return Json(conversationlist, JsonRequestBehavior.AllowGet);
        }

        public string SplitMesage(string message)
        {
            int length = message.Length;
            if (length >= 30)
                return message.Substring(0, 30);
            else
                return message;
        }

        [HttpPost]
        public int AddNewMessage(MessageViewModel model)
        {
            string userid = User.Identity.GetUserId();
            var msg = new UserMessage()
            {
                Message = model.message,
                SenderId = model.sender,
                ReceiverId = model.receiver,
                Status = "Unread"
            };
            MessageData msgData = new MessageData();
            return msgData.AddMessage(msg);
        }
    }


}