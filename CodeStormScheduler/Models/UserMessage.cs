using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeStormScheduler.Models
{
    public class UserMessage
    {
        [Key]
        public int MessageId { get; set; }
        public string Message { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string ReceiverId { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string SenderId { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(10)]
        public string Status { get; set; }

    }
}