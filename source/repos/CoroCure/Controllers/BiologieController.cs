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
    public class BiologieController : ControllerBase
    {
        private ApplicationDbContext _context;

        public BiologieController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Biologie> Get()
        {
            return _context.Biologies.ToList();
        }

        [HttpGet("{Id}")]
        public Biologie GetBiologie(int id)
        {
            return _context.Biologies.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}