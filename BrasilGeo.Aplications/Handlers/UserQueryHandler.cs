using BrasilGeo.Aplications.Queries;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Handlers;
using BrasilGeo.Domain.Repositories;

namespace BrasilGeo.Aplications.Handlers
{
    public class UserQueryHandler : IQueryHandler<UserQuery, UserQueryResult>
    {
        private readonly IUniteOfWork _uniteOfWork;

        public UserQueryHandler(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public Task<UserQueryResult> HandleAsync(UserQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> HandlerQueryUser()
        {
           return  await _uniteOfWork.UserRepository.GetAllAsync();
        }
    }
}
