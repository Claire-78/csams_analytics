using CSAMS.APIModels;
using CSAMS.DTOS;
using CSAMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.Controllers
{
    /// <summary>
    /// Class for getting filtered comments
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get UserReviews based on filtering by Reviewer
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>Array of filtered UserReviews</returns>
        [HttpPost("reviewer")]
        public async Task<ActionResult<CommentModel[]>> GetCommentsByReviewer(PostMessage filters)
        {
            var reviewer = await _context.Users.Where(u => u.ID == filters.Id).FirstOrDefaultAsync();

            if (reviewer is null)
                return BadRequest($"No reviewer with ID {filters.Id} exist!");

            var reviews = await _context.UserReviews.ToArrayAsync();

            //Filter by Reviewer
            var returnValue = reviews.Where(m => m.UserReviewer == filters.Id && m.Comment != null).ToArray();

            if (returnValue.Length == 0 || returnValue is null)
                return BadRequest($"Reviewer {filters.Id} has no commented reviews!");


            //Filter by AnswerType
            if (filters.AnswerType != "")
            {
                returnValue = returnValue.Where(m => m.Type.Contains(filters.AnswerType)).ToArray();

                if (returnValue.Length == 0 || returnValue is null)
                    return BadRequest($"Reviewer {filters.Id} has no commented reviews with an answer type '{filters.AnswerType}'!");
            }

            //Filter by Answer
            if (filters.Answer != "")
            {
                returnValue = returnValue.Where(m => m.Answer != null && m.Answer.Contains(filters.Answer)).ToArray();

                if (returnValue.Length == 0 || returnValue is null)
                    return BadRequest($"Reviewer {filters.Id} has no commented reviews with an answer type '{filters.AnswerType}' and the answer '{filters.Answer}'!");
            }

            //Filter by Comment
            if (filters.Comment != "")
            {
                returnValue = returnValue.Where(m => m.Comment.Contains(filters.Comment)).ToArray();

                if (returnValue.Length == 0 || returnValue is null)
                    return BadRequest($"Reviewer {filters.Id} has no commented reviews with an answer type '{filters.AnswerType}', the answer '{filters.Answer}' and a comment that contains '{filters.Comment}'!");
            }

            return returnValue.Select(m => new CommentModel { Target = m.UserTarget, Answer = m.Answer, AnswerType = m.Type, Comment = m.Comment, Reviewer = m.UserReviewer }).ToArray();
        }

        /// <summary>
        /// Get UserReviews based on filtering by Assignment
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>Array of filtered UserReviews</returns>
        [HttpPost("project")]
        public async Task<ActionResult<CommentModel[]>> GetCommentsByAssignment(PostMessage filters)
        {
            var project = await _context.Assignments.Where(A => A.ID == filters.Id).FirstOrDefaultAsync();

            if (project is null)
                return BadRequest($"No project with ID {filters.Id} exist!");

            var reviews = await _context.UserReviews.ToArrayAsync();

            //Filter by Project
            var returnValue = reviews.Where(m => m.AssignmentID == filters.Id).ToArray();

            if (returnValue.Length == 0 || returnValue is null)
                return BadRequest($"Project {filters.Id} has no commented reviews!");


            //Filter by AnswerType
            if (filters.AnswerType != "")
            {
                returnValue = returnValue.Where(m => m.Type.Contains(filters.AnswerType)).ToArray();

                if (returnValue.Length == 0 || returnValue is null)
                    return BadRequest($"Project {filters.Id} has no commented reviews with an answer type '{filters.AnswerType}'!");
            }

            //Filter by Answer
            if (filters.Answer != "")
            {
                returnValue = returnValue.Where(m => m.Answer != null && m.Answer.Contains(filters.Answer)).ToArray();

                if (returnValue.Length == 0 || returnValue is null)
                    return BadRequest($"Project {filters.Id} has no commented reviews with an answer type '{filters.AnswerType}' and the answer '{filters.Answer}'!");
            }

            //Filter by Comment
            if (filters.Comment != "")
            {
                returnValue = returnValue.Where(m => m.Comment != null && m.Comment.Contains(filters.Comment)).ToArray();

                if (returnValue.Length == 0 || returnValue is null)
                    return BadRequest($"Project {filters.Id} has no commented reviews with an answer type '{filters.AnswerType}', the answer '{filters.Answer}' and a comment that contains '{filters.Comment}'!");
            }

            return returnValue.Select(m => new CommentModel { Target = m.UserTarget, Answer = m.Answer, AnswerType = m.Type, Comment = m.Comment, Reviewer = m.UserReviewer }).ToArray();
        }

        /// <summary>
        /// Filters UserReviews based on projectID
        /// </summary>
        /// <param name="reviews"></param>
        /// <param name="projectID"></param>
        /// <returns>Array of filtered UserReviews</returns>
        public static CommentModel[] GetProjects(UserReviews[] reviews, int projectID)
        {
            var proco = reviews.Where(r => r.AssignmentID == projectID && r.Comment != null)
                .Select(r => new CommentModel { Target = r.UserTarget, Answer = r.Answer, AnswerType = r.Type, Comment = r.Comment, Reviewer = r.UserReviewer }).ToArray();

            if (proco.Length != 0) return proco;
            return null;
        }

        /// <summary>
        /// Filters UserReviews based on reviewerID
        /// </summary>
        /// <param name="reviews"></param>
        /// <param name="reviewerID"></param>
        /// <returns>Array of filtered UserReviews</returns>
        public static CommentModel[] GetReviewers(UserReviews[] reviews, int reviewerID)
        {
            var model = reviews.Where(m => m.UserReviewer == reviewerID && m.Comment != null)
                .Select(m => new CommentModel { Target = m.UserTarget, Answer = m.Answer, AnswerType = m.Type, Comment = m.Comment, Reviewer = m.UserReviewer }).ToArray();

            if (model.Length != 0) return model;
            return null;
        }
    }
}
