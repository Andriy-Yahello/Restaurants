using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    //will represent all operation against real database
    public interface IFoodDb : IDisposable
    {
        //able to query different objects like restaurants and reviews
        IQueryable<T> Query<T>() where T : class;

        //for test we add edditional features
        void Add<T> (T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void SaveChanges();
    }

    //implements IFoodDb query method explicitly
    public class Food : DbContext, IFoodDb
    {
       
        
        
        //we can configure db context
        public Food() : base("name=DefaultConnection") { }
        //update-database -Verbose
        public DbSet <UserProfile> UserProfiles { get; set; }
        public DbSet <ClassRestaurant> Restaurants { get; set; }
        public DbSet <Review> Reviews { get; set; }

        //implements IFoodDb query method explicitly
        //meaning we only can get to thid query method 
        //through IFoodDb reference
        //all this method needs to do
        //is to turn around and call into db context
        //that it derives from
        IQueryable<T> IFoodDb.Query<T>()
        {

            //will ask for queriable set of entities
            //if someone want a query of restaurant 
            //we just need to turn around  a return a set of restaurants
            //we nake change in homecontroller
            return Set<T>(); 
        }

        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void Remove<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }

        void IFoodDb.SaveChanges()
        {
            SaveChanges();
        }
    }
}