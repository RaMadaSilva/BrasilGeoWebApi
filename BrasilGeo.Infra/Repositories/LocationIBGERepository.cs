using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Repositories;
using BrasilGeo.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BrasilGeo.Infra.Repositories
{
    public class LocationIBGERepository : BaseRepository<LocationIBGE>, ILocationIBGERepository
    {
        private readonly BrazilGeoContext _context;

        public LocationIBGERepository(BrazilGeoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LocationIBGE>> GetLocationsByCityNameAsync(string cityName)
        {
            var locations = await _context.LocationIBGEs
                .Where(loc => loc.City == cityName).ToListAsync();

            return locations;
        }

        public async Task<List<LocationIBGE>> GetLocationsIBGEByStateAsync(string state)
        {

            return await _context.LocationIBGEs
                          .Where(location => location.State.Uf == state)
                          .ToListAsync();
        }

        public async Task<LocationIBGE> GetLocationsIBGEByIdAsync(long Id)
        {
            return await _context.LocationIBGEs
                .Where(location => location.Id == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<LocationIBGE> GetLocationIBGEByCityNameAndStateNameAsync(string cityName, string stateName)
        {
            var location = await _context.LocationIBGEs
                .Where(loc => loc.City == cityName && loc.State.Uf == stateName)
                .FirstOrDefaultAsync();

            return location;
        }

        public async Task<LocationIBGE> GetLocationIBGEByCityNameAsync(string cityName)
        {

            var location = await _context.LocationIBGEs
                .Where(loc => loc.City == cityName)
                .FirstOrDefaultAsync();

            return location;
        }
    }

}
