using BrasilGeo.Domain.Queries;

namespace BrasilGeo.Aplications.Queries
{
    public class UserQueryResult : IQueryResult
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
