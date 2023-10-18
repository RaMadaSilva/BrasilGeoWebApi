using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Queries;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Handlers;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class LocationIBGEQueryHandler : IQueryHandler<LocationIBGEQuery, IEnumerable<LocationIBGEDto>>
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IAdapter<IEnumerable<LocationIBGE>, IEnumerable<LocationIBGEDto>> _adapter;

        public LocationIBGEQueryHandler(IUniteOfWork uniteOfWork,
            IAdapter<IEnumerable<LocationIBGE>, IEnumerable<LocationIBGEDto>> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public async Task<IEnumerable<LocationIBGEDto>> HandleAsync(LocationIBGEQuery query)
        {
            var result = await _uniteOfWork.LocationIBGERepository.GetAllAsync();
            return _adapter.Adapte(result);
        }
    }
}
