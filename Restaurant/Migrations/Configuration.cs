namespace Restaurant.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<Restaurant.Models.Food>
    {
        public Configuration()
        {
            //we dont get explicite migration scripts or migration files in migrations folder
            //insted when we go to package manager to update database
            //it just make whatever changes it sees fit to do
            //AutomaticMigrationsEnabled = true;

            //for first deployment we willturn to state when we will be not using migrations anymore
            //after we deploy we will get live data in database
            //and delete databasw in sql server
            ///we connect to (LocalDb)\MSSQLLocalDB
            //close any exicting connections
            //in Package manager console Add -Migrations InitialCreate
            AutomaticMigrationsEnabled = false;
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

            SeedMembership();
        }

        private void SeedMembership()
        {

            //WE ansure that web security does not get initialized more then once
            //because if it get called more then once
            //this line of code will throw an exception
            //if WebSecurity is not initialized we will initialize the database
            //now we run migrations when app runs
            //this initialize connection can run web app is running
            //we also have a call intialize connection in global.asax.cs
            if (!WebSecurity.Initialized)
            { 
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", 
                "UserProfile", "UserId","UserName", autoCreateTables: true);
            }

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("lofongi@at.ua", false)==null)
            {
                membership.CreateUserAndAccount("lofongi@at.ua", "@As120120");
            }
            if (!roles.GetRolesForUser("lofongi@at.ua").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "lofongi@at.ua" }, new[] { "admin" });
            }

            //update-database -Verbose
        }
    }
}
