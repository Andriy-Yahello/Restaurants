using System;
using System.Linq;
using Restaurant.Models;
using System.Collections.Generic;

namespace Restaurant.Tests.Controllers
{
    internal class FakeFoodDb : IFoodDb
    {
        

        public IQueryable<T> Query<T>() where T : class
        {
            //we pull out some restaurants out of db
            return Sets[typeof(T)] as IQueryable<T>;
        }

        public void Dispose()
                {
            
                }

        //allows you to program restaurants that you want 
        //inside this fake db
        public void AddSet<T>(IQueryable<T> objects)
        {
            Sets.Add(typeof(T), objects); 
        }

        public void Add<T>(T entity) where T : class
        {
            Added.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Updated.Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            Removed.Add(entity);
        }

        public void SaveChanges()
        {
            Saved = true;
        }

        //when we want to query Restaurants
        public Dictionary<Type, object> Sets = new Dictionary<Type, object>();

        public List<object> Added = new List<object>();
        public List<object> Updated = new List<object>();
        public List<object> Removed = new List<object>();
        public bool Saved = false;
    }
}