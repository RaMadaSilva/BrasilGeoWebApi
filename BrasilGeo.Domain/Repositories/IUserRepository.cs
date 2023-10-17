using BrasilGeo.Domain.Entities;

namespace BrasilGeo.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUserWithRoleAsync();
        Task<User> GetUserByEmailWithRoleAsync(string email);
        Task<User> GetUserByIdWithRoleAsync(long id);
        Task<bool> AssociateUserToRolesAsync(long id, List<string> roles);
    }
}
