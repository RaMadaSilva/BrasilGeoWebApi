using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Queries.LocationIBGEQueries;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Interfaces.Adapter;
using BrasilGeo.Domain.Interfaces.Handlers;
using BrasilGeo.Domain.Interfaces.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class LocationIBGECodeQueryHandler : IQueryHandler<LocationIBGECodeQuery,
        LocationIBGEDto>
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IAdapter<LocationIBGE, LocationIBGEDto> _adapter;

        public LocationIBGECodeQueryHandler(IUnitOfWork uniteOfWork, 
            IAdapter<LocationIBGE, LocationIBGEDto> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public async Task<LocationIBGEDto> HandleAsync(LocationIBGECodeQuery query)
        {
            try
            {
                var result = await _uniteOfWork.LocationIBGERepository.GetByIdAsync(query.Id);
                if (result is null)
                    return null; 

                return _adapter.Adapte(result);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }
    }
}
