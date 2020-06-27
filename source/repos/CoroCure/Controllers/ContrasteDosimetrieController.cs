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
    public class ContrasteDosimetrieController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ContrasteDosimetrieController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<ContrasteDosimetrie> Get()
        {
            return _context.ContrasteDosimetries.ToList();
        }

        [HttpGet("{Id}")]
        public ContrasteDosimetrie GetContrasteDosimetrie(int id)
        {
            return _context.ContrasteDosimetries.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}