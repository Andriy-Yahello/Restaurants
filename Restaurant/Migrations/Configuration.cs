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
            ContextKey = "Restaurant.Models.Food";
        }

        //to Enable-Migrations -ContexttypeName Food in package manager
        //update-database -Verbose

        protected override void Seed(Restaurant.Models.Food context)
        {
            //here we can specify what data will be added to database


            context.Restaurants.AddOrUpdate(r => r.Name,
                new ClassRestaurant { Name = "Barisba", City = "Roome", Country = "Italy" },
                new ClassRestaurant { Name = "Miamiam", City = "Belgrade", Country = "Serbia" },
                new ClassRestaurant
                { Name = "Roki's",
                    City = "Plisko Polje",
                    Country = "Croatia ",
                Reviews = new List<Review> {
                    new Review {
                        Rating =4.8f,
                        Body = "The best restaurant on the island; very nice welcoming, showed us kitchen and explained their cooking; on the table rakija was waiting for us already, followed by a short wine tasting; excellent food, very nice people - a must visit when you are here!",
                        ReviewerName = "Bernhardino Wodler"
                    }
                } }
                );
        }
    }
}
