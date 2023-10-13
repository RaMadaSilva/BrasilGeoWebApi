using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.ValueObjects;

namespace BrasilGeo.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByEmailAsync(Email email);
        Task<IEnumerable<User>> GetAllUserWithRoleAsync();
        Task<User> GetUserByEmailWithRoleAsync(Email email);
        Task<User> GetUserByIdWithRoleAsync(long id);
        Task<bool> AssociateUserToRolesAsync(long id, List<string> roles);
    }
}
