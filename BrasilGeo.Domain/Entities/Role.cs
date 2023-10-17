using System.Text.Json.Serialization;

namespace BrasilGeo.Domain.Entities
{
    public class Role: BaseEntity
    {
        private Role()
        {
            
        }
        public Role(string roleName)
        {
            RoleName = roleName;
        }

        public string RoleName { get; private set; }

        [JsonIgnore]
        public ICollection<User> Users { get; } = new List<User>();

        public static implicit operator Role(string roleName) => new Role(roleName);

        public static implicit operator string(Role role) => role.ToString();

    }
}
