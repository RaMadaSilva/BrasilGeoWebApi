using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Interfaces.Adapter;

namespace BrasilGeo.Aplications.Adapter
{
    public class LocationIBGEToDtoAdapter : IAdapter<LocationIBGE, LocationIBGEDto>
    {
        public LocationIBGEDto Adapte(LocationIBGE source)
        {
            return new LocationIBGEDto
            {
                Id = source.Id,
                City = source.City,
                State = source.State.Uf
            };
        }
    }
}
