using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Queries.LocationIBGEQueries;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Enums;
using BrasilGeo.Domain.Helpers;
using BrasilGeo.Domain.Interfaces.Adapter;
using BrasilGeo.Domain.Interfaces.Handlers;
using BrasilGeo.Domain.Interfaces.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class LocationIBGEWithParameterQueryHandler  : IQueryHandler<LocationIBGEParameterQuery, Pagination<LocationIBGEDto>>
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IAdapter<IEnumerable<LocationIBGE>, IEnumerable<LocationIBGEDto>> _adapter;

        public LocationIBGEWithParameterQueryHandler(IUniteOfWork uniteOfWork,
            IAdapter<IEnumerable<LocationIBGE>, IEnumerable<LocationIBGEDto>> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public async Task<Pagination<LocationIBGEDto>> HandleAsync(LocationIBGEParameterQuery query)
        {
            try
            {
                if (!Enum.TryParse(query.Sort, true, out ESortOptions sortOptions))
                    return null;

                var locationIBGESpecification = new LocationIBGESpecificationQuery(sortOptions, query);
                var locationIBGECountSpecification = new LocationIBGECountSpecificationQuery(sortOptions, query);

                var totalItems = await _uniteOfWork.LocationIBGERepository.CountAsync(locationIBGECountSpecification);

                var locationsIBGE = await _uniteOfWork.LocationIBGERepository.ListAsync(locationIBGESpecification);

                var locations = _adapter.Adapte(locationsIBGE);

                return new Pagination<LocationIBGEDto>
                {
                    PageIndex = query.PageIndex,
                    PageSize = query.PageSize,
                    Count = totalItems,
                    Data = locations
                    
                };

            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
