using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoroCure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var cardiologue = dbContext.Comptes.Where(c => c.Username == username && c.Password == password)
                                               .SingleOrDefault();

            if (cardiologue == null)
                return new UnauthorizedResult();

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim("username-claim", username));
            var claims = new ClaimsPrincipal();
            claims.AddIdentity(identity);

            await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claims);
            /*var httpSession = httpContextAccessor.HttpContext.Session;
            httpSession.SetString("username", username);*/

            return new OkResult();
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
