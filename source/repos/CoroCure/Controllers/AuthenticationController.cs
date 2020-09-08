using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoroCure.Data;
using CoroCure.Data.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoroCure.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthenticationController(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("signin")]
        [Consumes("application/x-www-form-urlencoded")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromForm] string username, [FromForm] string password)
        {
            var compte = dbContext.Comptes.Where(c => c.Username == username && c.Password == password)
                                          .Include(c => c.Cardiologue)
                                          .SingleOrDefault();

            if (compte == null)
                return new UnauthorizedResult();

            var usernameClaim = new Claim(ClaimTypes.Name, username);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(usernameClaim);

            if(!string.IsNullOrWhiteSpace(compte.Roles))
            {
                foreach (var role in compte.Roles?.Split(',', System.StringSplitOptions.RemoveEmptyEntries))
                {
                    var roleClaim = new Claim(ClaimTypes.Role, role);
                    identity.AddClaim(roleClaim);
                }
            }

            var principal = new ClaimsPrincipal(identity);

            await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            /*var httpSession = httpContextAccessor.HttpContext.Session;
            httpSession.SetString("username", username);*/

            var dto = new CompteDTO
            {
                Username = compte.Username,
                FullName = $"{compte.Cardiologue.Nom} {compte.Cardiologue.Prenom}",
                Roles = compte.Roles.Split(',')
            };

            return new OkObjectResult(dto);
        }

        [HttpPost("signout")]
        public async Task Logout()
        {
            await httpContextAccessor.HttpContext.SignOutAsync();
        }

        [HttpGet("authorize")]
        [Authorize] // retourne 401 si non authentifié
        public ActionResult Session()
        {
            return Ok();
        }
    }
}
