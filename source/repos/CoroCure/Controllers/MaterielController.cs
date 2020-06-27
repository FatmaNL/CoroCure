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
    public class MaterielController : ControllerBase
    {
        private ApplicationDbContext _context;

        public MaterielController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Materiel> Get()
        {
            return _context.Materiels.ToList();
        }

        [HttpGet("{Id}")]
        public Materiel GetMateriel(int id)
        {
            return _context.Materiels.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}