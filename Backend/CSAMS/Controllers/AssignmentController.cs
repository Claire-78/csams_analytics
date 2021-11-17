using CSAMS.APIModels;
using CSAMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.Controllers
{
    /// <summary>
    /// Class for getting the Assignments
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssignmentController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Assignments
        /// </summary>
        /// <returns>Array of AssignmentModels</returns>
        public async Task<AssignmentModel[]> Get()
        {
            return await _context.Assignments.Include(a => a.Course).Select(a => new AssignmentModel { ID = a.ID, Name = a.Name, Deadline = a.Deadline, ReviewDeadline = a.ReviewDeadline, Course = a.Course.CourseName }).ToArrayAsync();
        }
    }
}
