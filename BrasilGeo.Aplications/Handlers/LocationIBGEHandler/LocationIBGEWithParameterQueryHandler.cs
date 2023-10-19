using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Queries;
using BrasilGeo.Aplications.Queries.LocationIBGEQueries;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Enums;
using BrasilGeo.Domain.Handlers;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class LocationIBGEWithParameterQueryHandler  : IQueryHandler<LocationIBGEParameterQuery, IEnumerable<LocationIBGEDto>>
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IAdapter<IEnumerable<LocationIBGE>, IEnumerable<LocationIBGEDto>> _adapter;

        public LocationIBGEWithParameterQueryHandler(IUniteOfWork uniteOfWork,
            IAdapter<IEnumerable<LocationIBGE>, IEnumerable<LocationIBGEDto>> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public async Task<IEnumerable<LocationIBGEDto>> HandleAsync(LocationIBGEParameterQuery query)
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
