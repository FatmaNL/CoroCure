using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using CoroCure.Data;
using CoroCure.Data.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace CoroCure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private ApplicationDbContext _context;
        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Authorize]
        public List<Patient> Get()
        {
            return _context.Patients.ToList();
        }

        [HttpGet("{id}")]
        public Patient GetPatient(int id)
        {
            return _context.Patients.Where(c => c.Id == id).SingleOrDefault();
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public void Create([FromBody] Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] Patient patient)
        {
            var exists = _context.Patients.Where(c => c.Id == id)
                                          .AsNoTracking()
                                          .SingleOrDefault() != null;

            if (!exists)
                return BadRequest("Patient introuvable");

            _context.Update(patient);
            _context.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var dbPatient = _context.Patients.Where(c => c.Id == id).SingleOrDefault();
                _context.Patients.Remove(dbPatient);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null && ex.InnerException is PostgresException)
                {
                    var pEx = ex.InnerException as PostgresException;
                    return BadRequest(pEx.Detail);
                }
        
                return BadRequest("Suppression de patient échouée");
            }

        }



    }


}