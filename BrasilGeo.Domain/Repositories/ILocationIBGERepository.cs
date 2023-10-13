using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.ValueObjects.LocationIBGE;

namespace BrasilGeo.Domain.Repositories
{
    public interface ILocationIBGERepository : IBaseRepository<LocationIBGE>
    {
        Task<LocationIBGE> GetLocationIBGEByCityNameAsync(string  cityName);
        Task<LocationIBGE> GetLocationIBGEByStateNameAsync(State state);
    }
}
