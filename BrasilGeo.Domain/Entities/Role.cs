namespace BrasilGeo.Domain.Entities
{
    public class Role: BaseEntity
    {
        public Role(string roleName)
        {
            RoleName = roleName;
        }

        public string RoleName { get; private set; }

        ICollection<User> Users { get; } = new List<User>();
    }
}
