using BrasilGeo.Aplications.Specifications;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Enums;

namespace BrasilGeo.Aplications.Queries.LocationIBGEQueries
{
    public class LocationIBGESpecificationQuery : BaseSpecification<LocationIBGE>
    {
        public LocationIBGESpecificationQuery(ESortOptions sortOptions, LocationIBGEParameterQuery query)
            : base(locationIBGE =>
            string.IsNullOrEmpty(query.Search) || locationIBGE.City.Contains(query.Search)
            || locationIBGE.State.Uf.Contains(query.Search) || locationIBGE.Id.Equals(long.Parse(query.Search)))
        {
            ApplyPaging(query.PageSize * (query.PageIndex - 1),
                query.PageSize);

            switch (sortOptions)
            {
                case ESortOptions.StateAsc:
                    AddOrderBy(location => location.State);
                    break;
                case ESortOptions.StateDesc:
                    AddOrderByDescending(location => location.State);
                    break;
                default:
                    AddOrderBy(location => location.State!);
                    break;
            }
        }
    }

}
