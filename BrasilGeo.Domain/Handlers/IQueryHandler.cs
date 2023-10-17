using BrasilGeo.Domain.Queries;

namespace BrasilGeo.Domain.Handlers
{
    public interface IQueryHandler<TQuery, TDto> 
    {
        Task<TDto> HandleAsync(TQuery query);
    }
}
