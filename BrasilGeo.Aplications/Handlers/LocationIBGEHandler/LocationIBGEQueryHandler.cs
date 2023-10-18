using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Queries;
using BrasilGeo.Domain.Handlers;

namespace BrasilGeo.Aplications.Handlers.LocationIBGEHandler
{
    public class LocationIBGEQueryHandler : IQueryHandler<LocationIBGEQuery,LocationIBGEDto>
    {
        public Task<LocationIBGEDto> HandleAsync(LocationIBGEQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
