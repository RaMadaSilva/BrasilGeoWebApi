namespace BrasilGeo.Aplications.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new(); 
    }
}
