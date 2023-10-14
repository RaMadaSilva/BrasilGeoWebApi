﻿using BrasilGeo.Domain.ValueObjects.LocationIBGE;

namespace BrasilGeo.Domain.Entities.IBGE
{
    public class LocationIBGE: BaseEntity, IEquatable<LocationIBGE>
    {
        public LocationIBGE(State state, string city)
        {
            State = state;
            City = city;
        }

        public State State { get; private set; }
        public string City { get; private set; }

        public bool Equals(LocationIBGE? other)
        {
            return State == other?.State && City == other.City;
        }
    }
}