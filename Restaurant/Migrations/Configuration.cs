namespace Restaurant.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Restaurant.Models.Food>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Restaurant.Models.Food context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                 new ClassRestaurant { Name = "Barisba", City = "Roome", Country = "Italy",
                     Reviews = new List<Review> {
                    new Review {
                        Rating =4.6f,
                        Body = "The restaurant",
                        ReviewerName = "Ben Aflen"
                    },
                    new Review {
                        Rating =4.3f,
                        Body = "Good for now",
                        ReviewerName = "Donny Brown"
                    }
                 }
                 },
                 new ClassRestaurant { Name = "Miamiam", City = "Belgrade", Country = "Serbia",
                     Reviews = new List<Review> {
                    new Review {
                        Rating =4.2f,
                        Body = " very nice !",
                        ReviewerName = "Sam Johns"
                    }
                 }
                 },
                 new ClassRestaurant
                 {
                     Name = "Roki's",
                     City = "Plisko Polje",
                     Country = "Croatia ",
                     Reviews = new List<Review> {
                    new Review {
                        Rating =4.8f,
                        Body = "The best restaurant on the island; very nice welcoming, showed us kitchen and explained their cooking; on the table rakija was waiting for us already, followed by a short wine tasting; excellent food, very nice people - a must visit when you are here!",
                        ReviewerName = "Bernhardino Wodler"
                    }
                 }
                 },
                 new ClassRestaurant
                 {
                     Name = "Sensatione",
                     City = "Lviv",
                     Country = "Ukraine ",
                     Reviews = new List<Review> {
                    new Review {
                        Rating =4.9f,
                        Body = "showed us kitchen",
                        ReviewerName = "Michael Long"
                    },
                    new Review {
                        Rating =4.6f,
                        Body = "good reseption",
                        ReviewerName = "Small Kitten"
                    }
                 }
                 },
                  new ClassRestaurant
                  {
                      Name = "Last Chance",
                      City = "New York",
                      Country = "USA",
                      Reviews = new List<Review> {
                    new Review {
                        Rating =4.2f,
                        Body = "funking awesome",
                        ReviewerName = "Robert Nairo"
                    },
                    new Review {
                        Rating =4.7f,
                        Body = "it's just sick",
                        ReviewerName = "Brian Dont"
                    }
                 }
                  },
                 new ClassRestaurant
                 {
                     Name = "Kickdown",
                     City = "Sydney",
                     Country = "Australia",
                     Reviews = new List<Review> {
                    new Review {
                        Rating =4.0f,
                        Body = "Will nevwr come back here",
                        ReviewerName = "Suzen Luck"
                    },
                    new Review {
                        Rating =5.0f,
                        Body = "Briliant",
                        ReviewerName = "Latrel Dowel"
                    }
                 }
                 }
                 );

            //adding mock data to work with ajax
        //    for (int i = 0; i < 997; i++)
        //    {
        //        context.Restaurants.AddOrUpdate(r => r.Name,
        //         new ClassRestaurant { Name = i.ToString(), City = "Lviv", Country = "Ukraine" }
        //);
        //    }
        }
    }
}
