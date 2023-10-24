using BrasilGeo.Domain.Interfaces.Repositories;
using BrasilGeo.Infra.Context;

namespace BrasilGeo.Infra.Repositories
{
    public class UniteOfWork : IUniteOfWork
    {
        private IUserRepository _userRepository;
        private ILocationIBGERepository _locationIBGERepository;
        private BrazilGeoContext _context;

        public UniteOfWork(BrazilGeoContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository 
            => _userRepository ?? new UserRepostitory(_context);

        public ILocationIBGERepository LocationIBGERepository 
            => _locationIBGERepository ?? new LocationIBGERepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
