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
    public class FacteursRisqueAntecedantsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public FacteursRisqueAntecedantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<FacteursRisqueAntecedants> Get()
        {
            return _context.FacteursRisqueAntecedantss.ToList();
        }

        [HttpGet("{Id}")]
        public FacteursRisqueAntecedants GetFacteursRisqueAntecedants(int id)
        {
            return _context.FacteursRisqueAntecedantss.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}