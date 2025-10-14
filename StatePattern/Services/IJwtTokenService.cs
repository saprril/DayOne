using StatePattern.Models;

namespace StatePattern.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
