// Controllers/UserController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(string username, string email, string password)
    {
        var cleanUsername = InputSanitizer.SanitizeUsername(username);
        var cleanEmail = InputSanitizer.SanitizeEmail(email);

        if (string.IsNullOrEmpty(cleanUsername) ||
            string.IsNullOrEmpty(cleanEmail) ||
            string.IsNullOrWhiteSpace(password))
        {
            return BadRequest("Invalid input");
        }

        UserRepository.CreateUser(
            cleanUsername,
            cleanEmail,
            password,
            role: "user"
        );

        return Ok();
    }
}
