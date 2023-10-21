using BrasilGeo.Aplications.Specifications;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Enums;

namespace BrasilGeo.Aplications.Queries.LocationIBGEQueries
{
    public class LocationIBGECountSpecificationQuery : BaseSpecification<LocationIBGE>
    {
        public LocationIBGECountSpecificationQuery(ESortOptions sortOptions, LocationIBGEParameterQuery query)
                     : base(locationIBGE =>
                     (string.IsNullOrEmpty(query.City) || locationIBGE.City == query.City) &&
                     (string.IsNullOrEmpty(query.State) || locationIBGE.State.Uf == query.State) && (query.Id != 0 || locationIBGE.Id == query.Id)
          )
        {


        }
    }
}

