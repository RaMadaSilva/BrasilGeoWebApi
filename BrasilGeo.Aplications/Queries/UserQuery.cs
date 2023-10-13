using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Queries;
using System.Linq.Expressions;

namespace BrasilGeo.Aplications.Queries
{
    public  class UserQuery : IQuery
    {
        public Expression<Func<User , bool>> GetUsersQuey()
        {
            return User => true; 
        }
    }
}
