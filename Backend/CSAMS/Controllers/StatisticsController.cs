using CSAMS.Models;
using CSAMS.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace CSAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatisticsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("userReviewsFiltered")]
        public async Task<ActionResult<UserReviews[]>> PostUserReviews(Filter filter)
        {
            UserReviews[] userReviews = await _context.UserReviews.Include(ur => ur.Assignment).Where(ur => ur.Type == "radio").ToArrayAsync();

            if (filter.assignment != "")
            {
                userReviews = userReviews.Where(ur => ur.Assignment.Name == filter.assignment).ToArray();
            }

            if (filter.reviewerID != "")//Check if it's a number
            {
                userReviews = userReviews.Where(ur => ur.UserReviewer == Convert.ToInt32(filter.reviewerID)).ToArray();
            }

            if (filter.targetID != "")//Check if it's a number
            {
                userReviews = userReviews.Where(ur => ur.UserTarget == Convert.ToInt32(filter.targetID)).ToArray();
            }
            return userReviews;
        }


        [HttpGet("userReviews")]
        public async Task<ActionResult<UserReviews[]>> GetUserReviews()
        {
             return await _context.UserReviews.Include(ur => ur.Assignment).Where(ur => ur.Type == "radio").ToArrayAsync();
        }


        [HttpGet("userReviewsStatistics")]
        public async Task<ActionResult<String[]>> GetUserReviewsStatistics()
        {
            UserReviews[] all = await _context.UserReviews.Where(ur => ur.Type == "radio").ToArrayAsync();
            String[] array = new String[] { "Min: " + GetMin(all).Answer, "Max: "+GetMax(all).Answer,"Mean: " + GetMean(all), "Median: " + GetMedian(all), "Q1: " + GetQ1(all), "Q3: " + GetQ3(all), "Standard Deviation: " + GetStandardDeviation(all) };
            return array;
        }


        [HttpPost("userReviewsFilteredStatistics")]
        public async Task<ActionResult<String[]>> PostStatistics(Filter filter)
        {
            //Get all UserReviews
            UserReviews[] userReviews = await _context.UserReviews.Include(ur => ur.Assignment).Where(ur => ur.Type == "radio").ToArrayAsync();

            //Filter them
            if (filter.assignment != "")
            {
                userReviews = userReviews.Where(ur => ur.Assignment.Name == filter.assignment).ToArray();
            }

            if (filter.reviewerID != "")//Check if it's a number
            {
                userReviews = userReviews.Where(ur => ur.UserReviewer == Convert.ToInt32(filter.reviewerID)).ToArray();
            }

            if (filter.targetID != "")//Check if it's a number
            {
                userReviews = userReviews.Where(ur => ur.UserTarget == Convert.ToInt32(filter.targetID)).ToArray();
            }

            //Return corresponding Statistics
            return new String[] { "Min: " + GetMin(userReviews).Answer, "Max: " + GetMax(userReviews).Answer, "Mean: " + GetMean(userReviews), "Median: " + GetMedian(userReviews), "Q1: " + GetQ1(userReviews), "Q3: " + GetQ3(userReviews), "Standard Deviation: " + GetStandardDeviation(userReviews) };
        }

        public float GetMean(UserReviews[] list)
        {
            float total = 0;
            float n = 0;
            foreach (UserReviews UR in list)
            {
                if ( UR.Answer != null)
                {
                    total += Convert.ToInt32(UR.Answer);
                    n += 1;
                }
            }
            return total / n;
        }

        public float GetMedian(UserReviews[] list)
        {
            List<float> values = new List<float>();
            foreach (UserReviews UR in list)
            {
                if ( UR.Answer != null)
                {
                    values.Add((float)Convert.ToInt32(UR.Answer));
                }
            }
            values.Sort();
            return values.ElementAt((values.Count - 1) / 2);
        }

        public float GetQ1(UserReviews[] list)
        {
            List<float> values = new List<float>();
            foreach (UserReviews UR in list)
            {
                if (UR.Answer != null)
                {
                    values.Add((float)Convert.ToInt32(UR.Answer));
                }
            }
            values.Sort();
            return values.ElementAt((values.Count - 1) / 4);
        }

        public float GetQ3(UserReviews[] list)
        {
            List<float> values = new List<float>();
            foreach (UserReviews UR in list)
            {
                if ( UR.Answer != null)
                {
                    values.Add((float)Convert.ToInt32(UR.Answer));
                }
            }
            values.Sort();
            return values.ElementAt((3 * values.Count - 1) / 4);
        }

        public float GetStandardDeviation(UserReviews[] list)
        {
            float mean = GetMean(list);
            float sd = 0;
            float n = 0;

            foreach (UserReviews UR in list)
            {
                if ( UR.Answer != null)
                {
                    n += 1;
                    sd += ((float)Convert.ToInt32(UR.Answer) - mean) * ((float)Convert.ToInt32(UR.Answer) - mean);
                }
            }
            return (float)Math.Sqrt(Convert.ToDouble(sd / n));
        }

        public UserReviews GetMin(UserReviews[] list)
        {
            UserReviews minUR = new UserReviews();
            int minScore = 1000;
            foreach (UserReviews UR in list)
            {
                if ( UR.Answer != null)
                {
                    if (Convert.ToInt32(UR.Answer) < minScore)
                    {
                        minScore = Convert.ToInt32(UR.Answer);
                        minUR = UR;
                    }
                }
            }
            return minUR;
        }

        public UserReviews GetMax(UserReviews[] list)
        {
            UserReviews minUR = new UserReviews();
            int minScore = -1000;
            foreach (UserReviews UR in list)
            {
                if ( UR.Answer != null)
                {
                    if (Convert.ToInt32(UR.Answer) > minScore)
                    {
                        minScore = Convert.ToInt32(UR.Answer);
                        minUR = UR;
                    }
                }
            }
            return minUR;
        }
    }
}
