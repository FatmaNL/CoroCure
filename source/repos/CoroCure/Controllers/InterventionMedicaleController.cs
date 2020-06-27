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
    public class InterventionMedicaleController : ControllerBase
    {
        private ApplicationDbContext _context;

        public InterventionMedicaleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<InterventionMedicale> Get()
        {
            return _context.InterventionMedicales.ToList();
        }

        [HttpGet("{Id}")]
        public InterventionMedicale GetInterventionMedicale(int id)
        {
            return _context.InterventionMedicales.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}