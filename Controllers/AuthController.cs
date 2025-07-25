using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            // Hardcoded admin credentials
            const string adminUsername = "admin";
            const string adminPassword = "admin123";

            if (login.Username == adminUsername && login.Password == adminPassword)
            {
                // Return a simple token or flag
                return Ok(new
                {
                    success = true,
                    role = "admin",
                    token = "dummy-admin-token"
                });
            }

            return Unauthorized(new { success = false, message = "Invalid credentials" });
        }
    }
}
