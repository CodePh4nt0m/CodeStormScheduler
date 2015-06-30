using System.Collections.Generic;
using DotLiquid;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using CodeStormData;
using CodeStormScheduler.Services;


namespace CodeStormScheduler.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void ReadFile()
        {
            
        }

        [HttpPost]
        public ActionResult SendEmail()
        {
            //MailMessage msg = new MailMessage();
            //msg.From = new MailAddress("strider7766@gmail.com");
            //msg.To.Add("dilnuwan77@gmail.com");
            //msg.Subject = "test";
            //msg.Body = "Test Content";

            //using (SmtpClient client = new SmtpClient())
            //{
            //    client.EnableSsl = true;
            //    client.UseDefaultCredentials = false;
            //    client.Credentials = new NetworkCredential("strider7766@gmail.com", "dualcore");
            //    client.Host = "smtp.gmail.com";
            //    client.Port = 587;
            //    client.DeliveryMethod = SmtpDeliveryMethod.Network;

            //    client.Send(msg);
            //}

            var fromAddress = new MailAddress("ucdcodestorm@gmail.com", "CodeStorm");
            var toAddress = new MailAddress("dilnuwan77@gmail.com", "");
            const string fromPassword = "CodeStorm$77";
            const string subject = "Email Confirmation";
            string body = "";

            using (var reader = new StreamReader(Server.MapPath("~/Templates/emailconfirm.html")))
            {
                var contents = reader.ReadToEnd();
                Template bodyTemplate = Template.Parse(contents);
                var bodyDto = new
                {
                    confirmlink = "www.dilnuwanonline.com"
                };
                body = bodyTemplate.Render(Hash.FromAnonymousObject(bodyDto));
            }

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

            return RedirectToAction("Index");
        }

        public ActionResult Autocomplete()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetNames()
        {
            using (CodeStormData.CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var names = db.UserProfiles.ToList();
                return Json(names, JsonRequestBehavior.AllowGet);
            }
            
        }
    }

    class Vmodel
    {
        public string id { get; set; }
        public string text { get; set; }
    }
}