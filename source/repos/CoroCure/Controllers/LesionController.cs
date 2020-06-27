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
    public class LesionController : ControllerBase
    {
        private ApplicationDbContext _context;

        public LesionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Lesion> Get()
        {
            return _context.Lesions.ToList();
        }

        [HttpGet("{Id}")]
        public Lesion GetLesion(int id)
        {
            return _context.Lesions.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}