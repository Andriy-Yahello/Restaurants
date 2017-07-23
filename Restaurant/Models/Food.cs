using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Food : DbContext
    {
        //we can configure db context
        public Food() : base("name=DefaultConnection") { }

        public DbSet <ClassRestaurant> Restaurants { get; set; }
        public DbSet <Review> Reviews { get; set; }

        //protected override void OnModelCreating(DbModelBuilder mb)
        //{
        //    mb.Entity<ClassRestaurant>().HasMany(m => m.Reviews).WithMany();
        //}

        //protected override void OnModelCreating(DbModelBuilder mb)
        //{
        //    mb.Entity<ClassRestaurant>().ToTable("RestaurantId");
        //}
    }
}