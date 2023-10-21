using BrasilGeo.Aplications.Specifications;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Enums;

namespace BrasilGeo.Aplications.Queries.LocationIBGEQueries
{
    public class LocationIBGESpecificationQuery : BaseSpecification<LocationIBGE>
    {
        public LocationIBGESpecificationQuery(ESortOptions sortOptions, LocationIBGEParameterQuery query)
            : base(locationIBGE => (!string.IsNullOrEmpty(query.City) || locationIBGE.City == query.City) &&
            (!string.IsNullOrEmpty(query.State) ||locationIBGE.State.Uf == query.State) && (query.Id != 0) || locationIBGE.Id == query.Id)
        {
            ApplyPaging(query.PageSize * (query.PageIndex - 1),
                query.PageSize);

            switch (sortOptions)
            {
                case ESortOptions.CidadeAsc:
                    AddOrderBy(location => location.City);
                    break;
                case ESortOptions.CidadeDesc:
                    AddOrderByDescending(location => location.City);
                    break;
                default:
                    AddOrderBy(location => location.City!);
                    break;
            }
        }
    }

}
