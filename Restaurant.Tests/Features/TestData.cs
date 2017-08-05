using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Tests.Features
{
    class TestData
    {
        public static IQueryable<ClassRestaurant> Restaurants
        {
            get
            {
                var restaurants = new List<ClassRestaurant>();
                for  (int i = 0; i < 100; i++)
                    {
                    var restaurant = new ClassRestaurant();
                    restaurant.Reviews = new List<Review>()
                    {
                        new Review { Rating = 4 }
                    };
                    restaurants.Add(restaurant);
                    }
                return restaurants.AsQueryable();
            }
        }
    }
}
