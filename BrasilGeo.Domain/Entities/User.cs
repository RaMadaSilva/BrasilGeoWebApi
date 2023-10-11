using BrasilGeo.Domain.ValueObjects;

namespace BrasilGeo.Domain.Entities
{
    public class User : BaseEntity, IEquatable<User>
    {
        public User(Email email, string password)
        {
            Email = email;
            Password = password;
        }

        public Email Email { get; private set; }
        public string Password { get; private set; }
        ICollection<Role> Roles { get;  } = new List<Role>();
        public bool Equals(User? other)
        {
           return Email== other.Email;
        }
    }
}
