using CSAMS.APIModels;
using CSAMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSAMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssignmentController (AppDbContext context)
        {
            _context = context;
        }

        public async Task<AssignmentModel[]> Get()
        {
            Console.Write("Test");
            return await _context.Assignments.Include(a => a.Course).Select(a => new AssignmentModel { ID = a.ID, Name = a.Name, Deadline = a.Deadline, ReviewDeadline = a.ReviewDeadline, Course = a.Course.CourseName }).ToArrayAsync();
        }
    }
}
