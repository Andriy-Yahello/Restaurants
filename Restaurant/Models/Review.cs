using System;
using System.Collections.Generic;
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
        public float Rating { get; set; }
        public string Body { get; set; }
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }
    }
}