using BrasilGeo.Domain.Entities.IBGE;

namespace BrasilGeo.Domain.Repositories
{
    public interface ILocationIBGERepository : IBaseRepository<LocationIBGE>
    {
        Task<List<LocationIBGE>> GetLocationsIBGEByState(string state); 
        Task<LocationIBGE> GetLocationIBGEByCityNameAndStateNameAsync(string cityName, string stateName);
        Task<List<LocationIBGE>> GetLocationsByCityNameAsync(string cityName);
        Task<LocationIBGE> GetLocationIBGEByCityNameAsync(string cityName);
    }
}
