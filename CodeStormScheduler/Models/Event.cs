using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeStormScheduler.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public Int64 Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(200)]
        public string Text { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string RecType { get; set; }

        [Column(TypeName = "BIGINT")]
        public int EventLength { get; set; }

        public int EventPid { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(7)]
        public string Color { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string UserId { get; set; }
    }
}