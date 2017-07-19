using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class ClassRestaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //we add virtual to avoid error
        public virtual ICollection <Review> Reviews { get; set; }
    }
}