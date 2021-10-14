using CSAMS.Models;
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

        [HttpGet("userReviewsStatistics")]
        public async Task<ActionResult<String[]>> GetUserReviewsStatistics()
        {
            UserReviews[] all = await _context.UserReviews.Include(ur => ur.Review).Include(ur => ur.Review.Form).Include(ur => ur.Target).Include(ur => ur.Target.UserRole).Include(ur => ur.Reviewer).Include(ur => ur.Reviewer.UserRole).ToArrayAsync();
            String[] array = new String[] { "Min: " + GetMin(all).Answer, "Max: "+GetMax(all).Answer,"Mean: " + GetMean(all), "Median: " + GetMedian(all), "Q1: " + GetQ1(all), "Q3: " + GetQ3(all), "Standard Deviation: " + GetStandardDeviation(all) };
            return array;
        }

        public float GetMean(UserReviews[] list)
        {
            float total = 0;
            float n = 0;
            foreach (UserReviews UR in list)
            {
                if (UR.Type == "radio" && UR.Answer != null)
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
                if (UR.Type == "radio" && UR.Answer != null)
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
                if (UR.Type == "radio" && UR.Answer != null)
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
                if (UR.Type == "radio" && UR.Answer != null)
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
                if (UR.Type == "radio" && UR.Answer != null)
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
                if (UR.Type == "radio" && UR.Answer != null)
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
                if (UR.Type == "radio" && UR.Answer != null)
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
