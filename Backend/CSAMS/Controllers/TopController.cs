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

        [HttpGet("Top/{N}/{Type}/{IsProject}")]
        public async Task<ActionResult<TopModel[]>> GetTopReviews(int N, string Type, Boolean IsProject)
        {

           // var test = await _context.Assignments.ToArrayAsync();
            var fields = await _context.Fields.ToArrayAsync();
           // TopModel[][] child = new TopModel[test.ToList().Count][];

            Console.WriteLine($"N is {N} and Type is {Type}");

            var t = _context.UserReviews.Include(r => r.Review).Include(r => r.Assignment)
                  .AsEnumerable()
                  // .GroupBy(r => r.AssignmentID)
                  // .Select(r => TopProjects(r.ToArray(), fields, IsProject))
                  .Where(p => p != null)

                  .ToArray();
            if (IsProject == true)
            {
                if (Type == "Top")
                {
                    return t
                           .GroupBy(r => r.AssignmentID)
                          .Select(r => TopProjects(r.ToArray(), fields, IsProject,0))
                       .Where(r => r != null)
                       
                         .OrderByDescending(p => p.Grade)
                         .Take(N)
                         .ToArray();
                    ;
                }
                else if (Type == "Bottom")
                {
                    Console.WriteLine(t.Length);
                    var x = t
                        .GroupBy(r => r.AssignmentID)
                       .Select(r => TopProjects(r.ToArray(), fields, IsProject, 0))
                       .Where(r => r != null)
                       .OrderBy(p => p.Grade)
                       .Take(N)

                       .ToArray();
                    return x;
                }
                else
                {
                    return t
                          .GroupBy(r => r.AssignmentID)
                          .Select(r => TopProjects(r.ToArray(), fields, IsProject, 0))
                       .Where(r => r != null)
                         .Take(2)
                         .ToArray();
                    ;
                }
            }
            else////////////////////////////
            {
                var average = GetMiddle(_context.UserReviews.Include(r => r.Review).ToArray(), fields);

                if (Type == "Top")
                {
                    return t
                        
                           .GroupBy(r => r.UserReviewer)
                          .Select(r => TopProjects(r.ToArray(), fields, IsProject, average))
                            
                       .Where(r => r != null)
                     
                         .OrderBy(p=>p.Grade)
                       
                         .Take(N)
                         
                         .ToArray();
                    ;
                }
                else if (Type == "Bottom")
                {
                    return t
                        .GroupBy(r => r.UserReviewer)
                       .Select(r => TopProjects(r.ToArray(), fields, IsProject, average))
                       .Where(r => r != null)
                       .OrderByDescending(p => p.Grade)
                       .Take(N)
                       .ToArray();

                }
                else
                {
                    return t
                          .GroupBy(r => r.ReviewID)
                          .Select(r => TopProjects(r.ToArray(), fields, IsProject, average))
                       .Where(r => r != null)
                         .Take(2)
                         .ToArray();
                    ;
                }
            }


        }

        */
        [HttpGet("Top/{N}/{Type}/{IsProject}")]
        public static TopModel TopProjects(UserReviews[] userReviews, Fields[] fields, Boolean IsProject,float average)
        {


            var child =
                userReviews
                .Select(r => (r, fields.Where(f => f.FormID == r.Review.FormID)
                .Where(f => f.Name == r.Name).FirstOrDefault().Weight))
                .Where(ur => ur.r.Answer != null)
                .Where(ur => ur.r.Assignment != null)
                .Where(ur => ur.r.Type == "radio")
                .Where(ur=>ur.Item2!=0)
                .ToArray();
                  
            if (IsProject == true)
            {
               var child2= child
                     .Select(ur => new TopModel
                     {
                         Grade = float.Parse(ur.r.Answer) * ur.Item2,
                         AssingmentID = ur.r.AssignmentID,
                         AssingmentName = ur.r.Assignment.Name,
                         ReviewerID = ur.r.UserReviewer,
                         type = "Top"

                     })
                    .ToArray();


                Console.WriteLine(child.Length);
             
                
                if (child.Length == 0)
                    return null;
                Console.WriteLine(child2[0].ReviewerID);
                var ret = child2.Sum(r => r.Grade) / child.Sum(ur => ur.Item2);
                TopModel model = new TopModel { Grade = MathF.Round(ret, 2), AssingmentID = child2[0].AssingmentID, AssingmentName = child2[0].AssingmentName,ReviewerID=child2[0].ReviewerID, type = "top" };
                return model;
            }
            else
            {
                {
                    var child2 = child
                          .Select(ur => new TopModel
                          {
                              Grade = MathF.Abs(float.Parse(ur.r.Answer) * ur.Item2 - average),
                              AssingmentID = ur.r.AssignmentID,
                              AssingmentName = ur.r.Assignment.Name,
                              ReviewerID = ur.r.UserReviewer,
                              type = "Top"

                          })
                         .ToArray();


                    Console.WriteLine(child.Length);
                    if (child.Length == 0)
                        return null;
                    var ret = child2.Sum(r => r.Grade)/child.Sum(ur => ur.Item2);
                    TopModel model = new TopModel { Grade = MathF.Round(ret, 2), AssingmentID = child2[0].AssingmentID, AssingmentName = child2[0].AssingmentName, ReviewerID = child2[0].ReviewerID, type = "top" };
                    return model;
                }
            }


        
        }

        // await _context.UserReviews.Include(i => i.Assignment).Include(i => i.Reviewer).Include(i => i.Target).Include(i => i.Review).Where(ur => ur.Comment != null) .Take(5).ToArrayAsync();





        public static float GetMiddle(UserReviews[] userReviews, Fields[] fields)
        {
            var child =
                    userReviews
                    .Select(r => (r, fields
                    .Where(f => f.FormID == r.Review.FormID)
                    .Where(f => f.Name == r.Name)
                    .FirstOrDefault().Weight))
                    .Where(ur => ur.r.Answer != null)
                    .Where(ur => ur.r.Type == "radio").Where(ur => ur.Item2 != 0);
            var child2 = child
                    .OrderBy(ur => ur.r.UserTarget).OrderByDescending(ur => int.Parse(ur.r.Answer) * ur.Item2)
                   .Select(ur => new TopModel
                   {
                       Grade = float.Parse(ur.r.Answer) * ur.Item2
                   })
                    .ToArray();

            if (child2.Length == 0)
                return 0;
            return child2.Sum(r => r.Grade)/child.Sum(ur => ur.Item2);
        }



        [HttpGet("Top/{N}/{Type}/{IsProject}")]
        public async Task<ActionResult<TopModel[]>> GetTopReviews(int N, string Type, Boolean IsProject)
        {
            var fields = await _context.Fields.ToArrayAsync();
            var userdata = _context.UserReviews.Include(r => r.Review).Include(r => r.Assignment)
                  .AsEnumerable()
                  // .GroupBy(r => r.AssignmentID)
                  // .Select(r => TopProjects(r.ToArray(), fields, IsProject))
                  .Where(p => p != null)

                  .ToArray();
            var toAverege = _context.UserReviews.Include(r => r.Review).ToArray();
           return OuterTopProjects(N, Type, IsProject, userdata, fields, toAverege);
        }


        public static TopModel[] OuterTopProjects(int N, string Type, Boolean IsProject, CSAMS.Models.UserReviews[] Userdata, CSAMS.Models.Fields[] fields,UserReviews[] ToAvrege)
        {
            var t = Userdata

                  ;
            Console.WriteLine($"N is {N} and Type is {Type}");
            Console.WriteLine(Userdata.Length + " testdata_length ");
           
            if (IsProject == true)
            {
                if (Type == "Top")
                {
                    return t
                           .GroupBy(r => r.AssignmentID)
                          .Select(r => TopController.TopProjects(r.ToArray(), fields, IsProject, 0))
                       .Where(r => r != null)

                         .OrderByDescending(p => p.Grade)
                         .Take(N)
                         .ToArray();
                    ;
                }
                else if (Type == "Bottom")
                {
                    Console.WriteLine(t.Length);
                    var x = t
                        .GroupBy(r => r.AssignmentID)
                       .Select(r => TopController.TopProjects(r.ToArray(), fields, IsProject, 0))
                       .Where(r => r != null)
                       .OrderBy(p => p.Grade)
                       .Take(N)

                       .ToArray();
                    return x;
                }
                else
                {
                    return t
                          .GroupBy(r => r.AssignmentID)
                          .Select(r => TopController.TopProjects(r.ToArray(), fields, IsProject, 0))
                       .Where(r => r != null)
                         .Take(2)
                         .ToArray();
                    ;
                }
            }
            else////////////////////////////
            {
                var average = TopController.GetMiddle(ToAvrege, fields);

                if (Type == "Top")
                {
                    return t

                           .GroupBy(r => r.UserReviewer)
                          .Select(r => TopController.TopProjects(r.ToArray(), fields, IsProject, average))

                       .Where(r => r != null)

                         .OrderBy(p => p.Grade)

                         .Take(N)

                         .ToArray();
                    ;
                }
                else if (Type == "Bottom")
                {
                    return t
                        .GroupBy(r => r.UserReviewer)
                       .Select(r => TopController.TopProjects(r.ToArray(), fields, IsProject, average))
                       .Where(r => r != null)
                       .OrderByDescending(p => p.Grade)
                       .Take(N)
                       .ToArray();

                }
                else
                {
                    return t
                          .GroupBy(r => r.ReviewID)
                          .Select(r => TopController.TopProjects(r.ToArray(), fields, IsProject, average))
                       .Where(r => r != null)
                         .Take(2)
                         .ToArray();
                    ;
                }
            }


        }


   

    }



}



