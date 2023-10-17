using BrasilGeo.Aplications.Queries;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Handlers;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers
{
    public class UserQueryHandler : IQueryHandler<UserQuery, IEnumerable<UserQueryResult>>
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IAdapter<IEnumerable<User>, IEnumerable<UserQueryResult>> _adapter;

        public UserQueryHandler(IUniteOfWork uniteOfWork,
            IAdapter<IEnumerable<User>, IEnumerable<UserQueryResult>> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public async Task<IEnumerable<UserQueryResult>> HandleAsync(UserQuery query)
        {
            var resutl = await _uniteOfWork.UserRepository.GetAllAsync();
            return _adapter.Adapte(resutl); 
        }
    }
}
