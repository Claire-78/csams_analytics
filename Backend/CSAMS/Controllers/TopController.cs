using CSAMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using CSAMS.DTOS;
using System.Linq;
using System.Collections.Generic;

namespace CSAMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TopController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TopController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("Top")]
        public async Task<ActionResult<UserReviews[][]>> GetReviews()
        {
            var test = await _context.Assignments.ToArrayAsync();
            UserReviews[][] child=new UserReviews[test.ToList().Count][];
            for (int i = 0;i< test.ToList().Count; i++)

                child[i] = 
                    await _context.UserReviews.Include(ur => ur.Assignment).Include(ur => ur.Reviewer).Include(ur => ur.Target).Include(ur => ur.Review).OrderBy(ur=>ur.Answer).Where(ur => ur.AssignmentID == test[i].ID).Take(5).ToArrayAsync();

                  

            return child;

        }
       

           // await _context.UserReviews.Include(i => i.Assignment).Include(i => i.Reviewer).Include(i => i.Target).Include(i => i.Review).Where(ur => ur.Comment != null) .Take(5).ToArrayAsync();
           
        }
        

     
    }

       

