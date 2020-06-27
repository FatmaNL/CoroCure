using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoroCure.Data;
using CoroCure.Data.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoroCure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PatientController : ControllerBase
    {
        private ApplicationDbContext _context;
        public PatientController (ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
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
        public void Create (Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

        }

        [HttpPut]
        public void Update(int id, Patient patient)
        {
            var dbPatient = _context.Patients.Where(c => c.Id == id).SingleOrDefault();
        } 


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var dbPatient = _context.Patients.Where(c => c.Id == id).SingleOrDefault();
            _context.Patients.Remove(dbPatient);
            _context.SaveChanges();

        }



    }

    
}