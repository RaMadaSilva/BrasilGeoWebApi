using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Entities.IBGE;

namespace BrasilGeo.Aplications.Adapter
{
    public class LocationIBGEToDtoAdapter : IAdapter<LocationIBGE, LocationIBGEDto>
    {
        public LocationIBGEDto Adapte(LocationIBGE source)
        {
            return new LocationIBGEDto
            {
                City = source.City,
                State = source.State
            };
        }
    }
}
