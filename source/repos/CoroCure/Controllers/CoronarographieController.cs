using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoroCure.Data;
using CoroCure.Data.DTO;
using CoroCure.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoroCure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronarographieController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CoronarographieController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Coronarographie> Get()
        {
            return _context.Coronarographies.ToList();
        }

        [HttpGet("{Id}")]
        public Coronarographie GetCoronarographie(int id)
        {
            return _context.Coronarographies.Where(c => c.Id == id).SingleOrDefault();
        }

        [HttpPost]
        public ActionResult AddCoronarographie([FromBody] CoronarographieDTO dto)
        {
            var coronarographie = new Coronarographie(dto);
            _context.Coronarographies.Add(coronarographie);

            return Ok();
        }
    }
}