using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Queries.LocationIBGEQueries;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Handlers;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class LocationIBGECodeQueryHandler : IQueryHandler<LocationIBGECodeQuery,
        LocationIBGEDto>
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IAdapter<LocationIBGE, LocationIBGEDto> _adapter;

        public LocationIBGECodeQueryHandler(IUniteOfWork uniteOfWork, 
            IAdapter<LocationIBGE, LocationIBGEDto> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public async Task<LocationIBGEDto> HandleAsync(LocationIBGECodeQuery query)
        {
            try 
            {

               var result =  await _uniteOfWork.LocationIBGERepository.GetByIdAsync(query.Id); 

                return _adapter.Adapte(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
