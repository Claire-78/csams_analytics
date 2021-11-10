using CSAMS.APIModels;
using CSAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Framework.Methods
{
    public static class EqualClassChecker
    {
        public static bool APIModelEqual(IAPIModel[] expected, IAPIModel[] result)
        {
            if (expected.Length != result.Length)
                return false;

            foreach (var proj in expected)
            {
                if (result.All(res => proj.AssertEqual(res) == false))
                    return false;
            }

            return true;
        }

        public static bool UserReviewsEqual(UserReviews[] expected, UserReviews[] result)
        {
            if (expected.Length != result.Length)
                return false;

            foreach (var review in expected)
            {
                if (result.All(res => review.AssertEqual(res) == false))
                    return false;
            }

            return true;
        }
    }
}
