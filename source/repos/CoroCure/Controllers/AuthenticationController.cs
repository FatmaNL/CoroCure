using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoroCure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoroCure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private ApplicationDbContext _context;

        public AuthenticationController(ApplicationDbContext context)
        {
           _context = context;
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var compte = _context.Comptes.Where(c => c.Username == username && c.Password == password).SingleOrDefault();
            if (compte == null)
            {
                return Forbid();
            }
            //start http session
            return Ok();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            // supprimer session http
            return Ok();
        }
    }
}