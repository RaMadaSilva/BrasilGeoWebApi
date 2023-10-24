using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Interfaces.Queries;
using System.Linq.Expressions;

namespace BrasilGeo.Aplications.Queries.UserQueries
{
    public  class UserQuery : IQuery
    {
        public Expression<Func<User , bool>> GetUsersQuey()
        {
            return User => true; 
        }
    }
}
