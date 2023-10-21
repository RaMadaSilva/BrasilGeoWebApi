using BrasilGeo.Aplications.Specifications;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Enums;

namespace BrasilGeo.Aplications.Queries.LocationIBGEQueries
{
    public class LocationIBGECountSpecificationQuery : BaseSpecification<LocationIBGE>
    {
        public LocationIBGECountSpecificationQuery(ESortOptions sortOptions, LocationIBGEParameterQuery query)
            : base(locationIBGE =>
            string.IsNullOrEmpty(query.Search) || locationIBGE.City.Contains(query.Search)
            || locationIBGE.State.Uf.Contains(query.Search) || locationIBGE.Id.ToString().Contains(query.Search))
        {
           
            
        }
    }
}

