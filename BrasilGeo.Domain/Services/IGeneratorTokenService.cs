using BrasilGeo.Domain.Entities;

namespace BrasilGeo.Domain.Services
{
    public interface IGeneratorTokenService
    {
        string GenerateToken(User user);
    }
}
