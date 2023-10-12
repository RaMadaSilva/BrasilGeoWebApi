using BrasilGeo.Domain.ValueObjects;

namespace BrasilGeo.Domain.Entities
{
    public class User : BaseEntity, IEquatable<User>
    {
        private readonly List<Role> _roles = new();
        public User(Email email, string password)
        {
            Email = email;
            Password = password;
        }

        public Email Email { get; private set; }
        public string Password { get; private set; }
        IReadOnlyCollection<Role> Roles => _roles;

        public void AddRole(Role role) => _roles.Add(role);
        public bool Equals(User? other)
        {
            return Email == other.Email;
        }
    }
}
