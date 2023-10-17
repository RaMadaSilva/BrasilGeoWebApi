using BrasilGeo.Domain.Queries;

namespace BrasilGeo.Domain.Handlers
{
    public interface IQueryHandler<TQuery, TQueryResult> 
    {
        Task<TQueryResult> HandleAsync(TQuery query);
    }
}
