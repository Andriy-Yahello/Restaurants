using System;
using Restaurant.Models;
using System.Linq;

namespace Restaurant.Tests.Features
{
    internal class RestaurantRater
    {
        private ClassRestaurant _restaurant;

        public RestaurantRater(ClassRestaurant restaurant)
        {
            this._restaurant = restaurant;
        }


        public RatingResult ComputeResult(IRatingAlgoritm algoritm, int numberOfReviewsToIUse)
        {

            var filterRevierws = _restaurant.Reviews.Take(numberOfReviewsToIUse);

            return algoritm.Compute(filterRevierws.ToList());
            //return algoritm.Compute(_restaurant.Reviews.ToList());
        }

        //internal RatingResult ComputeRating(int numberofReviews)
        //{
        //    var result = new RatingResult();
        //    result.Rating = (int)_restaurant.Reviews.Average(r => r.Rating) ;
        //    return result;
        //}

        //public RatingResult ComputeWeightedRate(float numberOfReviews)
        //{
        //    var reviews = _restaurant.Reviews.ToArray();
        //    var result = new RatingResult();
        //    var counter = 0;
        //    float total = 0;

        //    for (int i = 0; i < reviews.Count(); i++)
        //    {
        //        if (i < reviews.Count() / 2)
        //        {
        //            counter += 2;
        //            total += reviews[i].Rating * 2;

        //        }
        //        else
        //        {
        //            counter += 1;
        //            total += reviews[i].Rating;
        //        }
        //    }

        //    var n = total / counter;

        //    result.Rating = (int)n;
        //    return result;
        //}
    }
}