using BrasilGeo.Domain.Queries;

namespace BrasilGeo.Domain.Handlers
{
    public interface IQueryHandler<TQuery, TQueryResult> where TQuery : IQuery
        where TQueryResult : IQueryResult
    {
        Task<TQueryResult> HandleAsync(TQuery query);
    }
}
