using CSAMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CSAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SampleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("review")]
        public async Task<ActionResult<Reviews[]>> GetReviews()
        {
            return await _context.Reviews.Include(r => r.Form).ToArrayAsync();
        }

        [HttpGet("user")]
        public async Task<ActionResult<Users[]>> GetUsers()
        {
            return await _context.Users.Include(u => u.UserRole).ToArrayAsync();
        }
    }
}
