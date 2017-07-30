using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    //when we want to store users info we put it in a table with name UserProfile
    [Table("UserProfile")]
    public class UserProfile
    {
       //we tell entity framework that this is a primary key
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FavoriteRestaurant { get; set; }
    }
}