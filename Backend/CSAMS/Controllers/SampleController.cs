using CSAMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using CSAMS.DTOS;


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
            
            
            Console.WriteLine("here");
            return await _context.Users.Include(u => u.UserRole).ToArrayAsync();
        }

        //////////////////////////////
       
        [HttpPost("user")]
        public ActionResult<Users> PostUser(User newuser)
        {
           
            
            return Ok();
        }


        [HttpPost("user")]
        public ActionResult<Users> PostUserFilter(UserFilter newuser)
        {


            return Ok();
        }

        ///////////////////
    }
}
