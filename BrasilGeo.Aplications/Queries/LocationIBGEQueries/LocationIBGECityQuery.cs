using BrasilGeo.Domain.Queries;

namespace BrasilGeo.Aplications.Queries.LocationIBGEQueries
{
    public sealed record LocationIBGECityQuery(string city): IQuery
    {
    }
}
