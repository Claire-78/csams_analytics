using CSAMS.APIModels;
using CSAMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Framework.Methods
{
    /// <summary>
    /// Class containing functions for checking if 
    /// </summary>
    public static class EqualClassChecker
    {
        /// <summary>
        /// Check if two IAPIModel arrays are of the same class and with the same values
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="result"></param>
        /// <returns>True if they are equal, false if not</returns>
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

        /// <summary>
        /// Check if two UserReviews arrays are of the same class and with the same values
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="result"></param>
        /// <returns>True if they are equal, false if not</returns>
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
