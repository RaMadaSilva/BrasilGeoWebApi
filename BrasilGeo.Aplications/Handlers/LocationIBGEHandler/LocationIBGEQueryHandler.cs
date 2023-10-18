using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Queries;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Handlers;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class LocationIBGEQueryHandler : IQueryHandler<LocationIBGEQuery, IEnumerable<LocationIBGEDto>>
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IAdapter<IEnumerable<LocationIBGEQuery>, IEnumerable<LocationIBGEDto>> _adapter;

        public LocationIBGEQueryHandler(IUniteOfWork uniteOfWork,
            IAdapter<IEnumerable<LocationIBGEQuery>, IEnumerable<LocationIBGEDto>> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public Task<IEnumerable<LocationIBGEDto>> HandleAsync(LocationIBGEQuery query)
        {
            return null;
        }
    }
}
