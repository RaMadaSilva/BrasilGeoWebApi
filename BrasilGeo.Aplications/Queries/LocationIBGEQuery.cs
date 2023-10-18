using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Queries;

namespace BrasilGeo.Aplications.Queries
{
    public class LocationIBGEQuery : IQuery
    {
        public Expression<Func<LocationIBGE, bool>> GetAllLocationIBGEQuery()
        {
            return LocationIBGE => true;
        }

        public Expression<Func<LocationIBGE, bool>> GetStateLocationIBGEQuery(string state)
        {
            return LocationIBGE => LocationIBGE.State.Uf == state;
        }

        public Expression<Func<LocationIBGE, bool>> GetCityLocationIBGEQuery(string city)
        {
            return LocationIBGE => LocationIBGE.City == city;
        }
    }
}
