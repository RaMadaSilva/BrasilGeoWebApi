﻿using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Queries.LocationIBGEQueries;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Interfaces.Adapter;
using BrasilGeo.Domain.Interfaces.Handlers;
using BrasilGeo.Domain.Interfaces.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class LocationIBGECityQueryHandler : IQueryHandler<LocationIBGECityQuery,
        IEnumerable<LocationIBGEDto>>
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IAdapter<IEnumerable<LocationIBGE>, IEnumerable<LocationIBGEDto>> _adapter;

        public LocationIBGECityQueryHandler(IUnitOfWork uniteOfWork, IAdapter<IEnumerable<LocationIBGE>, 
            IEnumerable<LocationIBGEDto>> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public async Task<IEnumerable<LocationIBGEDto>> HandleAsync(LocationIBGECityQuery query)
        {
            try 
            {
                var result = await _uniteOfWork.LocationIBGERepository.GetLocationsByCityNameAsync(query.City);
                return _adapter.Adapte(result); 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
