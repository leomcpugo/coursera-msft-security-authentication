using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        var user = UserRepository.GetUser(username);
        if (user == null)
            return Unauthorized();

        if (!PasswordHasher.VerifyPassword(password, user.Value.PasswordHash))
            return Unauthorized();

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, user.Value.Role)
        };

        var identity = new ClaimsIdentity(claims, "SafeVaultAuth");
        HttpContext.User = new ClaimsPrincipal(identity);

        return Ok();
    }
}
