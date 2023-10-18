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

        public async Task<IEnumerable<LocationIBGE>> ListLocationsByCityName(string cityName)
        {
            var locations = await _context.LocationIBGEs
                .Where(loc => loc.City == cityName).ToListAsync();

            return locations;
        }



        public async Task<LocationIBGE> GetLocationIBGEByCityNameAndStateName(string cityName, string stateName)
        {
            var location = await _context.LocationIBGEs
                .Where(loc => loc.City == cityName && loc.State == stateName)
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

        public async Task<LocationIBGE> GetLocationIBGEByStateNameAsync(string state)
        {

            var location = await _context.LocationIBGEs
                .Where(loc => loc.State == state)
                .FirstOrDefaultAsync();

            return location;
        }
    }

}
