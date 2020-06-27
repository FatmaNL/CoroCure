using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoroCure.Data;
using CoroCure.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoroCure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BallonController : ControllerBase
    {
        private ApplicationDbContext _context;

        public BallonController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Ballon> Get()
        {
            return _context.Ballons.ToList();
        }

        [HttpGet("{Id}")]
        public Ballon GetBallon(int id)
        {
            return _context.Ballons.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}