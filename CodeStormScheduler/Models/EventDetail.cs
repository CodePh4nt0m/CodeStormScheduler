using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeStormScheduler.Models
{
    public class EventDetail
    {
        [Key]
        public int EventDetailId { get; set; }
        public Int64 Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Longitude { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Latitude { get; set; }

    }
}