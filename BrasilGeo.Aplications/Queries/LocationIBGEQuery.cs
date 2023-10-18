using System.Linq.Expressions;
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
