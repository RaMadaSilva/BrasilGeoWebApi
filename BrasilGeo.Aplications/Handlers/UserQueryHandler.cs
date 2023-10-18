using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Queries;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Handlers;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers
{
    public class UserQueryHandler : IQueryHandler<UserQuery, IEnumerable<UserDto>>
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IAdapter<IEnumerable<User>, IEnumerable<UserDto>> _adapter;

        public UserQueryHandler(IUniteOfWork uniteOfWork,
            IAdapter<IEnumerable<User>, IEnumerable<UserDto>> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public async Task<IEnumerable<UserDto>> HandleAsync(UserQuery query)
        {
            var resutl = await _uniteOfWork.UserRepository.GetAllUserWithRoleAsync();
            return _adapter.Adapte(resutl); 
        }
    }
}
