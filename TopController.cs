using CSAMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CSAMS.APIModels;
using System;

namespace CSAMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TopController : ControllerBase
    {
        private readonly AppDbContext _context;

        public int N { get; set; }
        public TopController(AppDbContext context)
        {
            _context = context;
        }

        public int HttpGetAttribute(int N)
        {
            return N;
        }







        /*
        [HttpGet("Bottom")]
        public async Task<ActionResult<TopModel[][]>> GetBottomReviews()
        {
            var test = await _context.Assignments.ToArrayAsync();
            var fields = await _context.Fields.ToArrayAsync();
            TopModel[][] child = new TopModel[test.ToList().Count][];

            var t = _context.UserReviews.Include(r => r.Review).AsEnumerable().GroupBy(r => r.AssignmentID).Select(r => BottomProjects(r.ToArray(), fields)).ToArray();
            return t;
        }

        public static TopModel[] BottomProjects(UserReviews[] userReviews, Fields[] fields)
        {
            var child =
                    userReviews
                    .Select(r => (r, fields.Where(f => f.FormID == r.Review.FormID).Where(f => f.Name == r.Name).FirstOrDefault().Weight)).Where(ur => ur.r.Answer != null).Where(ur => ur.r.Type == "radio")

                   .OrderBy(ur => ur.r.UserTarget).OrderBy(ur => int.Parse(ur.r.Answer) * ur.Item2)
                    .Take(5)
                   .Select(ur => new TopModel
                   {
                       Grade = int.Parse(ur.r.Answer) * ur.Item2,
                       AssingmentID = ur.r.AssignmentID,
                       AssingmentName = ur.r.Assignment.Name,
                       User = ur.r.UserTarget,
                       Reviewer = ur.r.UserReviewer,
                       type = "Bottom"

                   })

                    .ToArray();
            return child;
        }
        */

        [HttpGet("Top/{N}/{Type}")]
        public async Task<ActionResult<TopModel[]>> GetTopReviews(int N, string Type, Boolean IsProject)
        {

            var test = await _context.Assignments.ToArrayAsync();
            var fields = await _context.Fields.ToArrayAsync();
            TopModel[][] child = new TopModel[test.ToList().Count][];

            Console.WriteLine($"N is {N} and Type is {Type}");

            var t = _context.UserReviews.Include(r => r.Review)
                  .AsEnumerable()
                  .GroupBy(r => r.AssignmentID)
                  .Select(r => TopProjects(r.ToArray(), fields, IsProject))
                  .Where(p => p != null)

                  .ToArray();
          //  if (IsProject == true)
            {
                if (Type == "Top")
                {
                    return t
                         .OrderByDescending(p => p.Grade)
                         .Take(N)
                         .ToArray();
                    ;
                }
                else if (Type == "Bottom")
                {
                    Console.WriteLine("Test");
                    return t
                       .OrderBy(p => p.Grade)
                       .Take(N)
                       .ToArray();

                }
                else
                {
                    return t
                         .Take(2)
                         .ToArray();
                    ;
                }
            }
        }
        public static TopModel TopProjects(UserReviews[] userReviews, Fields[] fields,Boolean IsProject)
        {
            var child =
                    userReviews
                    .Select(r => (r, fields.Where(f => f.FormID == r.Review.FormID).Where(f => f.Name == r.Name).FirstOrDefault().Weight)).Where(ur => ur.r.Answer != null).Where(ur => ur.r.Type == "radio")

                    .OrderBy(ur => ur.r.UserTarget).OrderByDescending(ur => int.Parse(ur.r.Answer) * ur.Item2)
                   .Select(ur => new TopModel
                   {
                       Grade = int.Parse(ur.r.Answer) * ur.Item2,
                       AssingmentID = ur.r.AssignmentID,
                       AssingmentName = ur.r.Assignment.Name,
                       type = "Top"

                   })
                    .ToArray();

            if (child.Length == 0)
                return null;
            var ret = child.Average(r => r.Grade);
            TopModel model = new TopModel { Grade = MathF.Round(ret, 2), AssingmentID = child[0].AssingmentID, AssingmentName = child[0].AssingmentName, type = "top" };
            return model;
        }

        // await _context.UserReviews.Include(i => i.Assignment).Include(i => i.Reviewer).Include(i => i.Target).Include(i => i.Review).Where(ur => ur.Comment != null) .Take(5).ToArrayAsync();











    }



}



