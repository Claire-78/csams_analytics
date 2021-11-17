using CSAMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace CSAMS.Controllers
{
    /// <summary>
    /// This class was supposed to be a sample for how to get data from the database
    /// It is now used to get all Users in the database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SampleController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>Array of Users</returns>
        [HttpGet("user")]
        public async Task<ActionResult<Users[]>> GetUsers()
        {
            return await _context.Users.Include(u => u.UserRole).ToArrayAsync();
        }
    }
}
