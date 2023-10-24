using BrasilGeo.Domain.Interfaces.Queries;

namespace BrasilGeo.Aplications.Queries.LocationIBGEQueries
{
    public sealed record LocationIBGEStateQuery(string State): IQuery
    {
    }
}
