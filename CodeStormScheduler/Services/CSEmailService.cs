using DotLiquid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using SendGrid;

namespace CodeStormScheduler.Services
{
    public class CSEmailService
    {
        public void CSEMailService()
        {
            
        }

        public void SendEmail(string body,string receiver,string subject)
        {
            var fromAddress = new MailAddress("ucdcodestorm@gmail.com", "CodeStorm");
            var toAddress = new MailAddress(receiver, "");
            const string fromPassword = "CodeStorm$77";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.IsBodyHtml = true;
            message.Subject = subject;
            message.Body = body;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.Priority = MailPriority.High;
            smtp.Send(message);
            
        }

        public void SendGridEmail(string body, string receiver, string subject)
        {
            var mail = new SendGridMessage();
            mail.From = new MailAddress("ucdcodestorm@gmail.com");
            mail.AddTo(receiver);
            mail.Subject = subject;
            mail.Text = body;
            mail.Html = body;

            var credentials = new NetworkCredential("strider7766", "Optimus77");
            var transportWeb = new Web(credentials);
            transportWeb.DeliverAsync(mail);
        }
    }
}