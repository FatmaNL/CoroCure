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
    public class AngioplastieController : ControllerBase
    {
        private ApplicationDbContext _context;

        public AngioplastieController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Angioplastie> Get()
        {
            return _context.Angioplasties.ToList();
        }

        [HttpGet("{Id}")]
        public Angioplastie GetAngioplastie(int id)
        {
            return _context.Angioplasties.Where(c => c.Id == id).SingleOrDefault();
        }

        [HttpPost]
        public ActionResult AjouterAngioplastie([FromBody] AngioplastieDTO dto)
        {
            var entity = new Angioplastie(dto);

            var entry = _context.Angioplasties.Add(entity);

            if (dto.Coronarographie != null)
            {
                var coro = _context.Coronarographies.SingleOrDefault(c => c.Id == dto.Coronarographie.Id);
                coro.Angioplastie = entry.Entity;
                coro.AngioplastieId = entry.Entity.Id;
                _context.Update(coro);

            }

            _context.SaveChanges();

            return Ok();
        }
    }
}