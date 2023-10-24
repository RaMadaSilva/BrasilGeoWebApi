using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Interfaces.Repositories;
using BrasilGeo.Domain.ValueObjects;
using BrasilGeo.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BrasilGeo.Infra.Repositories
{
    public class UserRepostitory : BaseRepository<User>, IUserRepository
    {
        private readonly BrazilGeoContext _context;

        public UserRepostitory(BrazilGeoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUserWithRoleAsync()
        {
            return await _context
                 .Users.Include(r => r.Roles)
                 .ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context
                      .Users
                      .FirstOrDefaultAsync(x => x.Email.Adress == email);
        }

        public async Task<User> GetUserByEmailWithRoleAsync(string email)
        {
            return await _context
                   .Users
                   .Include(x => x.Roles)
                   .FirstOrDefaultAsync(x => x.Email.Adress == email);
        }

        public async Task<User> GetUserByIdWithRoleAsync(long id)
        {
            return await _context
                        .Users
                        .Include(x => x.Roles)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> AssociateUserToRolesAsync(long id, List<string> roles)
        {
            var user = await _context
                .Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if(user ==null || roles == null)
                return false;

            user.Roles.Clear(); 

            foreach(var role in roles)
            {
                var roleDb = await _context
                    .Roles
                    .SingleOrDefaultAsync(x=>x.RoleName==role);

                if (roleDb !=null)
                    user.AddRole(roleDb);
            }
            return true;
        }

    }
}