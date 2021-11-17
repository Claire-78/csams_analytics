using CSAMS.DTOS;
using CSAMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.Controllers
{
    /// <summary>
    /// Class for getting statistics of the database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatisticsController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Userreviews based on filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Array of filtered UserReviews</returns>
        [HttpPost("userReviewsFiltered")]
        public async Task<ActionResult<UserReviews[]>> PostUserReviews(Filter filter)
        {
            UserReviews[] userReviews = await _context.UserReviews.Include(ur => ur.Assignment).Where(ur => ur.Type == "radio").Where(ur => ur.Answer != null).ToArrayAsync();

            if (filter.Assignment != "")
            {
                userReviews = ApplyFilterAssignment(userReviews, filter.Assignment);
            }

            if (filter.ReviewerID != "")
            {
                try
                {
                    userReviews = ApplyFilterReviewerID(userReviews, Convert.ToInt32(filter.ReviewerID));
                }
                catch (FormatException)
                {
                    return BadRequest($"'{filter.ReviewerID}' is not a valid userID!");
                }
            }

            if (filter.TargetID != "")
            {
                try
                {
                    userReviews = ApplyFilterTargetID(userReviews, Convert.ToInt32(filter.TargetID));
                }
                catch (FormatException)
                {
                    return BadRequest($"'{filter.TargetID}' is not a valid userID!");
                }
            }

            if (userReviews is null || userReviews.Length == 0)
            {
                return BadRequest($"There are no user reviews corresponding to these values!");
            }

            return userReviews;
        }

        public static UserReviews[] ApplyFilterAssignment(UserReviews[] userReviews, string assignmentName)
        {
            UserReviews[] result = userReviews.Where(ur => ur.Assignment.Name == assignmentName).ToArray();
            if (result.Length == 0)
            {
                return null;
            }
            return result;
        }
        public static UserReviews[] ApplyFilterReviewerID(UserReviews[] userReviews, int reviewerID)
        {
            UserReviews[] result = userReviews.Where(ur => ur.UserReviewer == reviewerID).ToArray();
            if (result.Length == 0)
            {
                return null;
            }
            return result;
        }
        public static UserReviews[] ApplyFilterTargetID(UserReviews[] userReviews, int targetID)
        {
            UserReviews[] result = userReviews.Where(ur => ur.UserTarget == targetID).ToArray();
            if (result.Length == 0)
            {
                return null;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Array of UserReviews</returns>
        [HttpGet("userReviews")]
        public async Task<ActionResult<UserReviews[]>> GetUserReviews()
        {
            UserReviews[] userReviews = await _context.UserReviews.Include(ur => ur.Assignment).Where(ur => ur.Type == "radio").Where(ur => ur.Answer != null).ToArrayAsync();
            if (userReviews.Length == 0)
            {
                return BadRequest($"There are no user reviews corresponding to these values!");
            }
            return userReviews;
        }

        /// <summary>
        /// Get statistics for all Reviews
        /// </summary>
        /// <returns>Array of strings</returns>
        [HttpGet("userReviewsStatistics")]
        public async Task<ActionResult<string[]>> GetUserReviewsStatistics()
        {
            UserReviews[] all = await _context.UserReviews.Where(ur => ur.Type == "radio").Where(ur => ur.Answer != null).ToArrayAsync();
            if (all.Length == 0)
            {
                return BadRequest($"There are no user reviews corresponding to these values!");
            }
            string[] array = new string[] { "Min: " + GetMin(all).Answer, "Max: " + GetMax(all).Answer, "Mean: " + GetMean(all), "Median: " + GetMedian(all), "Q1: " + GetQ1(all), "Q3: " + GetQ3(all), "Standard Deviation: " + GetStandardDeviation(all) };
            return array;
        }

        /// <summary>
        /// Get statististics for all Reviews based on filtering
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Filtered array of strings</returns>
        [HttpPost("userReviewsFilteredStatistics")]
        public async Task<ActionResult<string[]>> PostStatistics(Filter filter)
        {
            //Get all UserReviews
            UserReviews[] userReviews = await _context.UserReviews.Include(ur => ur.Assignment).Where(ur => ur.Type == "radio").Where(ur => ur.Answer != null).ToArrayAsync();

            //Filter them
            if (filter.Assignment != "")
            {
                userReviews = ApplyFilterAssignment(userReviews, filter.Assignment);
            }

            if (filter.ReviewerID != "")
            {
                try
                {
                    userReviews = ApplyFilterReviewerID(userReviews, Convert.ToInt32(filter.ReviewerID));
                }
                catch (FormatException)
                {
                    return BadRequest($"'{filter.ReviewerID}' is not a valid userID!");
                }
            }

            if (filter.TargetID != "")
            {
                try
                {
                    userReviews = ApplyFilterTargetID(userReviews, Convert.ToInt32(filter.TargetID));
                }
                catch (FormatException)
                {
                    return BadRequest($"'{filter.TargetID}' is not a valid userID!");
                }
            }

            //In case the filters doesn't correspond to any userReview
            if (userReviews is null || userReviews.Length == 0)
            {
                return BadRequest($"There are no user reviews corresponding to these values!");
            }

            //Return corresponding Statistics
            string[] statistics = new string[] { };
            try
            {
                statistics = new string[] { "Min: " + GetMin(userReviews).Answer, "Max: " + GetMax(userReviews).Answer, "Mean: " + GetMean(userReviews), "Median: " + GetMedian(userReviews), "Q1: " + GetQ1(userReviews), "Q3: " + GetQ3(userReviews), "Standard Deviation: " + GetStandardDeviation(userReviews) };
            }
            catch (FormatException)
            {
                return BadRequest($"One of the Answer values is not a number!");
            }
            return statistics;
        }

        /// <summary>
        /// Get Mean answer score of UserReviews
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Mean</returns>
        public float GetMean(UserReviews[] list)
        {
            float total = 0;
            float n = 0;
            foreach (UserReviews UR in list)
            {
                total += Convert.ToInt32(UR.Answer);
                n += 1;
            }
            return total / n;
        }

        /// <summary>
        /// Get Median answer score of UserReviews
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Median</returns>
        public float GetMedian(UserReviews[] list)
        {
            List<float> values = new List<float>();
            foreach (UserReviews UR in list)
            {
                values.Add((float)Convert.ToInt32(UR.Answer));
            }
            values.Sort();
            return values.ElementAt((values.Count - 1) / 2);
        }

        /// <summary>
        /// Get Q1 answer score of UserReviews
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Q1</returns>
        public float GetQ1(UserReviews[] list)
        {
            List<float> values = new List<float>();
            foreach (UserReviews UR in list)
            {

                values.Add((float)Convert.ToInt32(UR.Answer));
            }
            values.Sort();
            return values.ElementAt((values.Count - 1) / 4);
        }

        /// <summary>
        /// Get Q3 answer score of UserReviews
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Q3</returns>
        public float GetQ3(UserReviews[] list)
        {
            List<float> values = new List<float>();
            foreach (UserReviews UR in list)
            {
                values.Add((float)Convert.ToInt32(UR.Answer));
            }
            values.Sort();
            return values.ElementAt((3 * values.Count - 1) / 4);
        }

        /// <summary>
        /// Get Standard Deviation answer score of UserReviews
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Standard Deviation</returns>
        public float GetStandardDeviation(UserReviews[] list)
        {
            float mean = GetMean(list);
            float sd = 0;
            float n = 0;

            foreach (UserReviews UR in list)
            {
                n += 1;
                sd += ((float)Convert.ToInt32(UR.Answer) - mean) * ((float)Convert.ToInt32(UR.Answer) - mean);
            }
            return (float)Math.Sqrt(Convert.ToDouble(sd / n));
        }

        /// <summary>
        /// Get Minimum answer score of UserReviews
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Minimum</returns>
        public UserReviews GetMin(UserReviews[] list)
        {
            UserReviews minUR = new UserReviews();
            int minScore = 1000;
            foreach (UserReviews UR in list)
            {
                if (Convert.ToInt32(UR.Answer) < minScore)
                {
                    minScore = Convert.ToInt32(UR.Answer);
                    minUR = UR;
                }
            }
            return minUR;
        }

        /// <summary>
        /// Get Maximum answer score of UserReviews
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Maximum</returns>
        public UserReviews GetMax(UserReviews[] list)
        {
            UserReviews minUR = new UserReviews();
            int minScore = -1000;
            foreach (UserReviews UR in list)
            {
                if (Convert.ToInt32(UR.Answer) > minScore)
                {
                    minScore = Convert.ToInt32(UR.Answer);
                    minUR = UR;
                }
            }
            return minUR;
        }
    }
}
