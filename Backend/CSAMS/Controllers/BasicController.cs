using CSAMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.Controllers
{
    /// <summary>
    /// Controller that was originally meant to be part of an example
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BasicController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Call that is used to showcase Pagination on the frontend
        /// </summary>
        /// <returns>Array of UserReviews with a comment</returns>
        [HttpGet("Comments")]
        public async Task<ActionResult<UserReviews[]>> GetComments()
        {
            return await _context.UserReviews.Include(i => i.Assignment).Include(i => i.Reviewer).Include(i => i.Target).Include(i => i.Review).Where(ur => ur.Comment != null).ToArrayAsync();
        }
    }
}
