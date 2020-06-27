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
    public class StentController : ControllerBase
    {
        private ApplicationDbContext _context;

        public StentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Stent> Get()
        {
            return _context.Stents.ToList();
        }

        [HttpGet("{Id}")]
        public Stent GetStent(int id)
        {
            return _context.Stents.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}