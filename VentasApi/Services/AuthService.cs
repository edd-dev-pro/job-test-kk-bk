using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VentasApi.Services;

public class AuthService(IConfiguration cfg) : IAuthService
{
    private readonly IConfiguration _cfg = cfg;

    private const string USERNAME = "admin";
    private const string PASSWORD = "1234";

    public bool ValidateUser(LoginDto dto)
        => dto.Username == USERNAME && dto.Password == PASSWORD;

    public string GenerateToken(string username)
    {
        var jwt = _cfg.GetSection("Jwt");
        var key = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(jwt["Key"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(
                      double.Parse(jwt["ExpiresInMinutes"]!));

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: new[] { new Claim(ClaimTypes.Name, username) },
            expires: expires,
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
