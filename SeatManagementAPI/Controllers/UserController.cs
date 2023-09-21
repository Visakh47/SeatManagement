using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeatManagementAPI.Models;
using System.Security.Claims;

namespace SeatManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController() { }

        [HttpPost]
        public async Task<ActionResult> AuthenticateUser([FromBody] User user) {
            if (user.username == "test" && user.password == "test")
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Role, "User")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");

                var claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return Ok();

            }
            else {
                await HttpContext.SignOutAsync("MyCookieAuth");
                return Unauthorized();
            }
        }
    }
}
