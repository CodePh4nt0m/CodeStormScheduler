using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeStormScheduler.ViewModels
{
    public class FileUploadViewModel
    {
        public HttpPostedFileBase Attachment { get; set; }
    }
}