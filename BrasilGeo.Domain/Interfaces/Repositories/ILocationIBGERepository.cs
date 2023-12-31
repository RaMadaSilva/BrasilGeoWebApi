﻿using BrasilGeo.Domain.Entities.IBGE;

namespace BrasilGeo.Domain.Interfaces.Repositories
{
    public interface ILocationIBGERepository : IBaseRepository<LocationIBGE>
    {
        Task<List<LocationIBGE>> GetLocationsIBGEByStateAsync(string state);
        Task<LocationIBGE> GetLocationIBGEByCityNameAndStateNameAsync(string cityName, string stateName);
        Task<List<LocationIBGE>> GetLocationsByCityNameAsync(string cityName);
        Task<LocationIBGE> GetLocationIBGEByCityNameAsync(string cityName);
    }
}
