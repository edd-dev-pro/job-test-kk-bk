namespace VentasApi.Services;

public interface IAuthService
{
    string GenerateToken(string username);
    bool   ValidateUser(LoginDto dto);
}
