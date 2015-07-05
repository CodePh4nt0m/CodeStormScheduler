using DotLiquid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CodeStormScheduler.Services
{
    public class MailBuilder
    {

        //Generate email confirmation mail body
        public static string GenerateEmailConfirmation(string confirmlnk)
        {
            string html = "";
            using (var reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Templates/emailconfirm.html")))
            {
                var contents = reader.ReadToEnd();
                Template bodyTemplate = Template.Parse(contents);
                var bodyDto = new
                {
                    confirmlink = confirmlnk
                };
                html = bodyTemplate.Render(Hash.FromAnonymousObject(bodyDto));
            }
            return html;
        }

        public static string GeneratePaswordReset(string resetlink)
        {
            string html = "";
            using (var reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Templates/resetpassword.html")))
            {
                var contents = reader.ReadToEnd();
                Template bodyTemplate = Template.Parse(contents);
                var bodyDto = new
                {
                    resetlink = resetlink
                };
                html = bodyTemplate.Render(Hash.FromAnonymousObject(bodyDto));
            }
            return html;
        }
    }
}