using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeStormScheduler.Models
{
    public class UserProfile
    {
        [Key]
        public int ProfileId { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(150)]
        public string LastName { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string ImageUrl { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string Id { get; set; }
    }
}