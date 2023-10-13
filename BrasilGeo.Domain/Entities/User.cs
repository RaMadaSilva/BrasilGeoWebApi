using BrasilGeo.Domain.ValueObjects;

namespace BrasilGeo.Domain.Entities
{
    public class User : BaseEntity, IEquatable<User>
    {
        private readonly List<Role> _roles = new();
        public User(Email email, Password password)
        {
            Email = email;
            PasswordHash = password;
        }

        public Email Email { get; private set; }
        public Password PasswordHash { get; private set; }
        public ICollection<Role> Roles => _roles;

        public void UpdateUser(Email email, Password password, List<string> roles)
        {
            Email = email; 

            PasswordHash = password; 

            //Por melhorar
            foreach (var role in roles)
            {
               
                AddRole(role);
            }
               
        }

        public void AddRole(Role role) => _roles.Add(role);
        public bool Equals(User? other)
        {
            return Email == other.Email;
        }
    }
}
