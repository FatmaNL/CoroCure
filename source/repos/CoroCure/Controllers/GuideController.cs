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
    public class GuideController : ControllerBase
    {
        private ApplicationDbContext _context;

        public GuideController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Guide> Get()
        {
            return _context.Guides.ToList();
        }

        [HttpGet("{Id}")]
        public Guide GetGuide(int id)
        {
            return _context.Guides.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}