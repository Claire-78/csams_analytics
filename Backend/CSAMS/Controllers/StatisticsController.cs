﻿using CSAMS.Models;
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
            UserReviews[] userReviews = await _context.UserReviews.Include(ur => ur.Assignment).Where(ur => ur.Type == "radio").Where(ur => ur.Answer != null).ToArrayAsync();

            if (filter.assignment != "")
            {
                userReviews = ApplyFilterAssignment(userReviews, filter.assignment);
            }

            if (filter.reviewerID != "")
            {
                try
                {
                    userReviews = ApplyFilterReviewerID(userReviews, Convert.ToInt32(filter.reviewerID));
                }
                catch (FormatException)
                {
                    return BadRequest($"'{filter.reviewerID}' is not a valid userID!");
                }
            }

            if (filter.targetID != "")
            {
                try
                {
                    userReviews = ApplyFilterTargetID(userReviews, Convert.ToInt32(filter.targetID));
                }
                catch (FormatException)
                {
                    return BadRequest($"'{filter.targetID}' is not a valid userID!");
                }
            }

            if (userReviews is null || userReviews.Length == 0)
            {
                return BadRequest($"There are no user reviews corresponding to these values!");
            }

            return userReviews;
        }

        public static UserReviews[] ApplyFilterAssignment(UserReviews[] userReviews, String assignmentName)
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


        [HttpGet("userReviewsStatistics")]
        public async Task<ActionResult<String[]>> GetUserReviewsStatistics()
        {
            UserReviews[] all = await _context.UserReviews.Where(ur => ur.Type == "radio").Where(ur => ur.Answer != null).ToArrayAsync();
            if (all.Length == 0)
            {
                return BadRequest($"There are no user reviews corresponding to these values!");
            }
            String[] array = new String[] { "Min: " + GetMin(all).Answer, "Max: "+GetMax(all).Answer,"Mean: " + GetMean(all), "Median: " + GetMedian(all), "Q1: " + GetQ1(all), "Q3: " + GetQ3(all), "Standard Deviation: " + GetStandardDeviation(all) };
            return array;
        }


        [HttpPost("userReviewsFilteredStatistics")]
        public async Task<ActionResult<String[]>> PostStatistics(Filter filter)
        {
            //Get all UserReviews
            UserReviews[] userReviews = await _context.UserReviews.Include(ur => ur.Assignment).Where(ur => ur.Type == "radio").Where(ur => ur.Answer != null).ToArrayAsync();

            //Filter them
            if (filter.assignment != "")
            {
                userReviews = ApplyFilterAssignment(userReviews, filter.assignment);
            }

            if (filter.reviewerID != "")
            {
                try
                {
                    userReviews = ApplyFilterReviewerID(userReviews, Convert.ToInt32(filter.reviewerID));
                }
                catch (FormatException)
                {
                    return BadRequest($"'{filter.reviewerID}' is not a valid userID!");
                }
            }

            if (filter.targetID != "")
            {
                try
                {
                    userReviews = ApplyFilterTargetID(userReviews, Convert.ToInt32(filter.targetID));
                }
                catch (FormatException)
                {
                    return BadRequest($"'{filter.targetID}' is not a valid userID!");
                }
            }

            //In case the filters doesn't correspond to any userReview
            if (userReviews is null || userReviews.Length == 0)
            {
                return BadRequest($"There are no user reviews corresponding to these values!");
            }

            //Return corresponding Statistics
            String[] statistics = new String[] { };
            try
            {
                statistics = new String[] { "Min: " + GetMin(userReviews).Answer, "Max: " + GetMax(userReviews).Answer, "Mean: " + GetMean(userReviews), "Median: " + GetMedian(userReviews), "Q1: " + GetQ1(userReviews), "Q3: " + GetQ3(userReviews), "Standard Deviation: " + GetStandardDeviation(userReviews) };
            }
            catch (FormatException)
            {
                return BadRequest($"One of the Answer values is not a number!");
            }
            return statistics;
        }

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
