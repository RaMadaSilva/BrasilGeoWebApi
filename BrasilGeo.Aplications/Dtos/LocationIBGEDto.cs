using BrasilGeo.Domain.ValueObjects.LocationIBGE;

namespace BrasilGeo.Aplications.Dtos
{
    public class LocationIBGEDto
    {
        public string City { get; set; } = string.Empty;
        public State State { get; set; } = null!; 
    }
}
