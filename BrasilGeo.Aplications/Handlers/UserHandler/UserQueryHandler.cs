using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Queries.UserQueries;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Interfaces.Adapter;
using BrasilGeo.Domain.Interfaces.Repositories;

namespace BrasilGeo.Aplications.Handlers.UserHandler
{
    public class UserQueryHandler 
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IAdapter<IEnumerable<User>, IEnumerable<UserDto>> _adapter;

        public UserQueryHandler(IUnitOfWork uniteOfWork,
            IAdapter<IEnumerable<User>, IEnumerable<UserDto>> adapter)
        {
            _uniteOfWork = uniteOfWork;
            _adapter = adapter;
        }

        public async Task<IEnumerable<UserDto>> HandleAsync(UserQuery query)
        {
            try
            {
                var resutl = await _uniteOfWork.UserRepository.GetAllUserWithRoleAsync();
                return _adapter.Adapte(resutl); 

            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
