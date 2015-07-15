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

        [Column(TypeName = "NVARCHAR")]
        [StringLength(10)]
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(200)]
        public string Location { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(15)]
        public string Mobile { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(150)]
        public string Profession { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string AboutMe { get; set; }
        public string Interests { get; set; }

    }
}