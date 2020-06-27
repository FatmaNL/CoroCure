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
    public class ProcedureController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ProcedureController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Procedure> Get()
        {
            return _context.Procedures.ToList();
        }

        [HttpGet("{Id}")]
        public Procedure GetProcedure(int id)
        {
            return _context.Procedures.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}