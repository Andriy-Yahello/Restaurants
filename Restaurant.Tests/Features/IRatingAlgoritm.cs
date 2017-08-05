using Restaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Tests.Features
{
     interface IRatingAlgoritm
    {
        RatingResult Compute(IList<Review> reviews);
    }

     class SimpleRatingAlgoritm : IRatingAlgoritm
    {
        public RatingResult Compute(IList<Review> reviews)
            {
                var result = new RatingResult();
                result.Rating = (int)reviews.Average(r => r.Rating);
                return result;
            }
    }

     class WeigtedRatingAlgoritm : IRatingAlgoritm
    {
        public RatingResult Compute(IList<Review> reviews)
        {
            var result = new RatingResult();
            var counter = 0;
            float total = 0;

            for (int i = 0; i < reviews.Count(); i++)
            {
                if (i < reviews.Count() / 2)
                {
                    counter += 2;
                    total += reviews[i].Rating * 2;

                }
                else
                {
                    counter += 1;
                    total += reviews[i].Rating;
                }
            }

            var n = total / counter;

            result.Rating = (int)n;
            return result;
        }
    }
}