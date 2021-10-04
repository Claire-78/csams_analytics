using CSAMS.APIModels;
using CSAMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("project/{projectID}")]
        public async Task<ActionResult<ProjectComments[]>> GetProjectComments(int projectID)
        {
            var reviews = await _context.UserReviews.ToArrayAsync();
            return GetProjects(reviews, projectID);
        }

        public ProjectComments[] GetProjects(UserReviews[] reviews, int projectID)
        {
            return reviews.Where(r => r.AssignmentID == projectID && r.Comment != null)
                .Select(r => new ProjectComments { Target = r.UserTarget, Answer = r.Answer, AnswerType = r.Type, Comment = r.Comment, Reviewer = r.UserReviewer }).ToArray();
        }
    }
}
