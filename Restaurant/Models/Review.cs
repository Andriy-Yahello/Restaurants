using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Review
    {
       
        public int Id { get; set; }
        //public string Name { get; set; }
        //public string City { get; set; }
        //public string Country { get; set; }
        //rating gange from 1 to 5
        [Range(1,5)]
        [Required]
        public float Rating { get; set; }

        [Required]
        //leng of body is less then 900 characters
        [StringLength(900)]
        //and update db  update-database -Verbose -force
        public string Body { get; set; }

        [Display(Name = "User Name")]
        //if a user forfot to specipy a name
        [DisplayFormat(NullDisplayText = "anonymous")]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }
    }
}