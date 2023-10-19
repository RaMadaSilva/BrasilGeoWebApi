using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Queries;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Enums;
using BrasilGeo.Domain.Handlers;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class LocationIBGEQueryHandler  : IQueryHandler<LocationIBGEReadQuery, IEnumerable<LocationIBGEDto>>
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IAdapter<IEnumerable<LocationIBGE>, IEnumerable<LocationIBGEDto>> _adapter;

        public LocationIBGEQueryHandler(IUniteOfWork uniteOfWork,
            IAdapter<IEnumerable<LocationIBGE>, IEnumerable<LocationIBGEDto>> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public async Task<IEnumerable<LocationIBGEDto>> HandleAsync(LocationIBGEReadQuery query)
        {
            if (!Enum.TryParse(query.Sort, true, out ESortOptions sortOptions))
                return null;

            var locationIBGESpecification = new LocationIBGESpecificationQuery(sortOptions, query);

            var totalItems = await _uniteOfWork.LocationIBGERepository.CountAsync(locationIBGESpecification);

            var locationsIBGE = await _uniteOfWork.LocationIBGERepository.ListAsync(locationIBGESpecification);

            return _adapter.Adapte(locationsIBGE); 
        }
    }
}
