using CoroCure.Data;
using CoroCure.Data.DTO;
using CoroCure.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoroCure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardiologueController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CardiologueController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public List<CardiologueDTO> Get()
        {
            return _context.Cardiologues.Include( c => c.Compte).Select(c => new CardiologueDTO(c)).ToList();
        }

        [HttpGet("{id}")]
        public Cardiologue GetCardiologue(int id)
        {
            return _context.Cardiologues.Where(c => c.CIN == id).SingleOrDefault();
        }

        [HttpPost]
        public void Create(Cardiologue cardiologue)
        {
            _context.Cardiologues.Add(cardiologue);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(int cin, Cardiologue cardiologue)
        {
            var dbCardiologue = _context.Cardiologues.Where(c => c.CIN == cin).SingleOrDefault();
            // set
            return;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var dbCardiologue = _context.Cardiologues.Include( c => c.Compte).Where(c => c.CIN == id).SingleOrDefault();
            _context.Cardiologues.Remove(dbCardiologue);
            _context.SaveChanges();
        }
    }
}