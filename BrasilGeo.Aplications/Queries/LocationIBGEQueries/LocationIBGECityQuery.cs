﻿using BrasilGeo.Domain.Interfaces.Queries;

namespace BrasilGeo.Aplications.Queries.LocationIBGEQueries
{
    public sealed record LocationIBGECityQuery(string City): IQuery
    {
    }
}
