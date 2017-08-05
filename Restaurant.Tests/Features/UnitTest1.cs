using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Compute_Result1()
        {
            //var data = new ClassRestaurant();
            //data.Reviews = new List<Review>();
            //data.Reviews.Add(new Review() { Rating = 3 });

            var data = BuildRestaurantAndReviews(ratings: 3);
            var rater = new RestaurantRater(data);
            //var result = rater.ComputeRating(4);
            var result = rater.ComputeResult(new SimpleRatingAlgoritm(), 10);

            Assert.AreEqual(3, result.Rating);
        }



        [TestMethod]
        public void Computes_Result2() {
            //var data = new ClassRestaurant();

            //data.Reviews = new List<Review>();
            //data.Reviews.Add(new Review() { Rating = 4 });
            //data.Reviews.Add(new Review() { Rating = 2 });


            var data = BuildRestaurantAndReviews(ratings: new[] { 4,2 });
            var rater = new RestaurantRater(data);
            // var result = rater.ComputeRating(2);
            var result = rater.ComputeResult(new WeigtedRatingAlgoritm(), 10);

            Assert.AreEqual(3, result.Rating);
        }

        //[TestMethod]
        //public void Weighted_Averaging_For_Two_Reviews()
        //{
        //    var data = BuildRestaurantAndReviews(3, 9);

        //    var rater = new RestaurantRater(data);
        //    //var result = rater.ComputeRating(10);
        //    var result = rater.ComputeWeightedRate(10);

        //    Assert.AreEqual(5, result.Rating);
        //}

        [TestMethod]
        public void Rating_Jnclude_Only_First_N_Reviews()
        {
            var data = BuildRestaurantAndReviews(1, 1, 2, 3, 3, 4);
            var rater = new RestaurantRater(data);
            var result = rater.ComputeResult(new SimpleRatingAlgoritm(), 3);

            Assert.AreEqual(1, result.Rating);
        }

        private ClassRestaurant BuildRestaurantAndReviews(params int[] ratings)
        {
            var restaurant = new ClassRestaurant();

            restaurant.Reviews =
                ratings.Select(r => new Review { Rating = r }).ToList();

            return restaurant;
        }
    }
}
