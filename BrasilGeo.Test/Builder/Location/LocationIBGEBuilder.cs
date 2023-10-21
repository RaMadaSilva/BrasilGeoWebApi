using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.ValueObjects.LocationIBGE;

namespace BrasilGeo.Test.Builder.Location
{
    public class LocationIBGEBuilder
    {
        private readonly LocationIBGE _instance;

        public LocationIBGEBuilder()
        {
            _instance = new LocationIBGE("EX", "exampleCity");
        }


        public LocationIBGEBuilder WithId(long Id)
        {
            _instance.Id = Id;
            return this;
        }
        
        public LocationIBGEBuilder WithState(State state)
        {
            _instance.State.Uf = state.Uf;
            return this;
        }

        public LocationIBGEBuilder WithCity(string city)
        {
            _instance.City = city;
            return this;
        }

        public LocationIBGE Build()
        {
            return _instance;
        }

    }
}
