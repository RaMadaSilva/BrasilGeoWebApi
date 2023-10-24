using BrasilGeo.Domain.Entities;

namespace BrasilGeo.Domain.Interfaces.Services
{
    public interface IGeneratorTokenService
    {
        string GenerateToken(User user);
    }
}
