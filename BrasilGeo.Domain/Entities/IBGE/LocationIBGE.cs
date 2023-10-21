using BrasilGeo.Domain.ValueObjects.LocationIBGE;

namespace BrasilGeo.Domain.Entities.IBGE
{
    public class LocationIBGE: BaseEntity, IEquatable<LocationIBGE>
    {
        private LocationIBGE()
        {
            
        }
        public LocationIBGE(State state, string city)
        {
            State = state;
            City = city;
        }

        public State State { get; private set; }
        public string City { get; private set; }

        public void UpdateLocationIBGE(State state, string city)
        {
            State = state;

            City = city;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(State.Uf, City);
        }

        public bool Equals(LocationIBGE other)
        {
            if (other == null) return false;

            return State.Uf.Equals(other.State.Uf) && City == other.City;
        }
    }
}
