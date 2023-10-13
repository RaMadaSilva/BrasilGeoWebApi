using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Repositories;
using BrasilGeo.Domain.ValueObjects.LocationIBGE;
using BrasilGeo.Infra.Context;

namespace BrasilGeo.Infra.Repositories
{
    public class LocationIBGERepository : BaseRepository<LocationIBGE>, ILocationIBGERepository
    {
        private readonly BrazilGeoContext _context;

        public LocationIBGERepository(BrazilGeoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<LocationIBGE> GetLocationIBGEByCityNameAsync(string cityName)
        {
            throw new NotImplementedException();
        }

        public async Task<LocationIBGE> GetLocationIBGEByStateNameAsync(State state)
        {
            throw new NotImplementedException();
        }
    }
}
