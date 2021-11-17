using CSAMS.APIModels;
using CSAMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.Controllers
{
    /// <summary>
    /// Top/Bottom N Projects based on mean average or Reviewers based on distance from mean average
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TopController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TopController(AppDbContext context)
        {
            _context = context;
        }

        public int HttpGetAttribute(int N)
        {
            return N;
        }

        /// <summary>
        /// Get the top/bottom Reviewers or Projects
        /// </summary>
        /// <param name="N">Amount of projects/reviewers wanted</param>
        /// <param name="Type">Top or Bottom</param>
        /// <param name="IsProject">Is it project or reviewers</param>
        /// <returns>Array of TopModel</returns>
        [HttpGet("Top/{N}/{Type}/{IsProject}")]
        public async Task<ActionResult<TopModel[]>> GetTopReviews(int N, string Type, bool IsProject)
        {
            var fields = await _context.Fields.ToArrayAsync();
            var userdata = _context.UserReviews
                .Include(r => r.Review)
                .Include(r => r.Assignment)
                .AsEnumerable()
                .ToArray();

            var toAverege = _context.UserReviews.Include(r => r.Review).ToArray();
            var ret = OuterTopProjects(N, Type, IsProject, userdata, fields);

            if (ret is null)
            {
                return BadRequest("Bad request");
            }

            if (ret.Length == 0)
            {
                return BadRequest("0 length");
            }

            return ret;
        }

        /// <summary>
        /// Get the Mean Average
        /// </summary>
        /// <param name="userReviews"></param>
        /// <param name="fields"></param>
        /// <param name="IsProject"></param>
        /// <param name="average">Mean average of all reviews</param>
        /// <returns></returns>
        public static TopModel TopProjects(UserReviews[] userReviews, Fields[] fields, bool IsProject, float average)
        {
            var child = userReviews
                .Select(r => (r, fields.Where(f => f.FormID == r.Review.FormID)
                .Where(f => f.Name == r.Name).FirstOrDefault().Weight))
                .Where(ur => ur.r.Answer != null)
                .Where(ur => ur.r.Assignment != null)
                .Where(ur => ur.r.Type == "radio")
                .Where(ur => ur.Item2 != 0)
                .ToArray();

            TopModel[] grades;

            if (IsProject)
            {
                grades = child
                      .Select(ur => new TopModel
                      {
                          Grade = float.Parse(ur.r.Answer) * ur.Item2,
                          AssingmentID = ur.r.AssignmentID,
                          AssingmentName = ur.r.Assignment.Name,
                          ReviewerID = ur.r.UserReviewer,
                          Type = "Top"
                      })
                     .ToArray();
            }
            else
            {
                grades = child
                      .Select(ur => new TopModel
                      {
                          Grade = MathF.Abs(float.Parse(ur.r.Answer) * ur.Item2 - average),
                          AssingmentID = ur.r.AssignmentID,
                          AssingmentName = ur.r.Assignment.Name,
                          ReviewerID = ur.r.UserReviewer,
                          Type = "Top"
                      })
                     .ToArray();
            }

            if (child.Length == 0)
            {
                return null;
            }

            var ret = grades.Sum(r => r.Grade) / child.Sum(ur => ur.Item2);

            TopModel model = new TopModel
            {
                Grade = MathF.Round(ret, 2),
                AssingmentID = grades[0].AssingmentID,
                AssingmentName = grades[0].AssingmentName,
                ReviewerID = grades[0].ReviewerID,
                Type = "top"
            };

            return model;
        }

        /// <summary>
        /// Get the mean average
        /// </summary>
        /// <param name="userReviews">Reviews with the answers</param>
        /// <param name="fields">Fields to know the weight of answers</param>
        /// <returns>Mean Average</returns>
        public static float GetMiddle(UserReviews[] userReviews, Fields[] fields)
        {
            var child = userReviews
                    .Select(r => (r, fields.Where(
                         f => f.FormID == r.Review.FormID)
                        .Where(f => f.Name == r.Name)
                        .FirstOrDefault().Weight))
                    .Where(ur => ur.r.Answer != null)
                    .Where(ur => ur.r.Type == "radio").Where(ur => ur.Item2 != 0);

            var child2 = child
                    .Select(ur => new TopModel
                    {
                        Grade = float.Parse(ur.r.Answer) * ur.Item2
                    })
                    .ToArray();

            if (child2.Length == 0)
            {
                return 0;
            }

            return child2.Sum(r => r.Grade) / child.Sum(ur => ur.Item2);
        }

        /// <summary>
        /// Get the top/bottom Reviewers or Projects
        /// </summary>
        /// <param name="N"></param>
        /// <param name="Type"></param>
        /// <param name="IsProject"></param>
        /// <param name="Userdata"></param>
        /// <param name="fields"></param>
        /// <returns>Array of TopModel</returns>
        public static TopModel[] OuterTopProjects(int N, string Type, bool IsProject, UserReviews[] Userdata, Fields[] fields)
        {
            if (IsProject)
            {
                var ret = Userdata
                        .GroupBy(r => r.AssignmentID)
                        .Select(r => TopProjects(r.ToArray(), fields, IsProject, 0))
                        .Where(r => r != null);

                if (Type == "Top")
                {
                    ret = ret.OrderByDescending(p => p.Grade);
                }
                else if (Type == "Bottom")
                {
                    ret = ret.OrderBy(p => p.Grade);
                }
                else
                {
                    return null;
                }
                return ret.Take(N).ToArray();
            }
            else
            {
                var average = GetMiddle(Userdata, fields);

                var ret = Userdata
                        .GroupBy(r => r.UserReviewer)
                        .Select(r => TopProjects(r.ToArray(), fields, IsProject, average))
                        .Where(r => r != null);

                if (Type == "Top")
                {
                    ret = ret.OrderBy(p => p.Grade);
                }
                else if (Type == "Bottom")
                {
                    ret = ret.OrderByDescending(p => p.Grade);
                }
                else
                {
                    return null;
                }

                return ret.Take(N).ToArray();
            }
        }
    }
}
