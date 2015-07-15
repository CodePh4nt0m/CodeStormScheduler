using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeStormScheduler.Models
{
    public class SharedEvent
    {
        [Key]
        public int ShraredEventId { get; set; }
        public Int64 EventId { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string UserId { get; set; }
    }
}