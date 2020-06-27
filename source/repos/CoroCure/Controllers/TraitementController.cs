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
    public class TraitementController : ControllerBase
    {
        private ApplicationDbContext _context;

        public TraitementController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Traitement> Get()
        {
            return _context.Traitements.ToList();
        }

        [HttpGet("{Id}")]
        public Traitement GetTraitement(int id)
        {
            return _context.Traitements.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}