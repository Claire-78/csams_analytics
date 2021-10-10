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
    public class MinMaxController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MinMaxController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("userReviews")]
        public async Task<ActionResult<UserReviews[]>> GetUserReviews()
        {
            return await _context.UserReviews.Where(ur => ur.Type != "radio").ToArrayAsync();
        }


        [HttpGet("userReviewsMinMax")]
        public async Task<ActionResult<UserReviews[]>> GetMinMaxUserReviews()
        {
            UserReviews[] all = await _context.UserReviews.Include(ur => ur.Review).Include(ur => ur.Review.Form).Include(ur => ur.Target).Include(ur => ur.Target.UserRole).Include(ur => ur.Reviewer).Include(ur => ur.Reviewer.UserRole).ToArrayAsync();
            UserReviews[] array = new UserReviews[] { GetMin(all, "prog2005_assignment_01_review"), GetMax(all, "prog2005_assignment_01_review") };
            return array;
        }

        public UserReviews GetMin(UserReviews[] list, string formPrefix)
        {
            UserReviews minUR = new UserReviews();
            int minScore = 1000;
            foreach (UserReviews UR in list)
            {
                if (UR.Type == "radio" && UR.Review.Form.Prefix == formPrefix && UR.Answer != null)
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

        public UserReviews GetMax(UserReviews[] list, string formPrefix)
        {
            Console.Out.WriteLine("Coucou");
            UserReviews minUR = new UserReviews();
            int minScore = -1000;
            foreach (UserReviews UR in list)
            {
                if (UR.Type == "radio" && UR.Review.Form.Prefix == formPrefix && UR.Answer != null)
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
