﻿using System.Collections.Generic;
using System.Linq;
using CoroCure.Data;
using CoroCure.Data.DTO;
using CoroCure.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Authorize]
        public Cardiologue GetCardiologue(int id)
        {
            return _context.Cardiologues.Where(c => c.CIN == id).SingleOrDefault();
        }

        [HttpPost]
        public void Create([FromBody] CardiologueDTO cardiologueDto)
        {
            var cardiologue = new Cardiologue(cardiologueDto);

            _context.Cardiologues.Add(cardiologue);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] CardiologueDTO cardiologueDto)
        {
            var dbCardiologue = _context.Cardiologues.Where(c => c.CIN == id)
                                                     .AsNoTracking()
                                                     .SingleOrDefault();

            if (dbCardiologue == null)
                return BadRequest("Cardiologue introuvable");

            var cardiologue = new Cardiologue(cardiologueDto);
            _context.Update(cardiologue);
            _context.SaveChanges();

            return Ok();
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