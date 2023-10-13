using BrasilGeo.Domain.Repositories;
using BrasilGeo.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasilGeo.Infra.Repositories
{
    public class UniteOfWork : IUniteOfWork
    {
        private IUserRepository _userRepository;
        private BrazilGeoContext _context;

        public UniteOfWork(BrazilGeoContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository 
            => _userRepository ?? new UserRepostitory(_context); 

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
