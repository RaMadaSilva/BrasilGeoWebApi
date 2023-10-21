using BrasilGeo.Domain.Entities.IBGE;


namespace BrasilGeo.Test.Builder.Location
{
    public class LocationIBGEBuilder
    {
        private long _id = 1; 
        private string _state = "EX"; 
        private string _city = "DefaultCity";

        public LocationIBGEBuilder WithId(long id)
        {
            _id = id;
            return this;
        }
        
        public LocationIBGEBuilder WithState(string state)
        {
            _state = state;
            return this;
        }

        public LocationIBGEBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }

        public LocationIBGE Build()
        {
            var location = new LocationIBGE(_state, _city);
            location.SetIdForTesting(_id);
            return location;
        }

    }
}
