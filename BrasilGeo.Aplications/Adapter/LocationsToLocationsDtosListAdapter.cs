using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Interfaces.Adapter;

namespace BrasilGeo.Aplications.Adapter
{
    public class LocationsToLocationsDtosListAdapter : 
        IAdapter<IEnumerable<LocationIBGE>, IEnumerable<LocationIBGEDto>>
    {
        public IEnumerable<LocationIBGEDto> Adapte(IEnumerable<LocationIBGE> source)
        {
            return source.Select(locationIBGE => new LocationIBGEDto
            {
                Id = locationIBGE.Id,
                City = locationIBGE.City,
                State = locationIBGE.State,
            });
        }
    }
}
