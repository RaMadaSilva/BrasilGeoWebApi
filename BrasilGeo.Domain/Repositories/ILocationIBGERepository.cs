using BrasilGeo.Domain.Entities.IBGE;

namespace BrasilGeo.Domain.Repositories
{
    public interface ILocationIBGERepository : IBaseRepository<LocationIBGE>
    {
        Task<LocationIBGE> GetLocationIBGEByCityNameAsync(string  cityName);
        Task<List<LocationIBGE>> GetLocationsIBGEByState(string state); 
        Task<LocationIBGE> GetLocationIBGEByCityNameAndStateName(string cityName, string stateName);
        Task<List<LocationIBGE>> GetLocationsByCityName(string cityName);
        Task<List<LocationIBGE>> GetLocationsIBGEByState(string state);
        Task<LocationIBGE> GetLocationsIBGEById(long Id);
    }
}
