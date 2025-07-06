using Microsoft.AspNetCore.Mvc;
using VentasApi.Services;

namespace VentasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService auth) : ControllerBase
{
    // POST api/auth/login
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        if (!auth.ValidateUser(dto))
            return Unauthorized("Credenciales inválidas");

        var token = auth.GenerateToken(dto.Username);
        return Ok(new { token });
    }
}
