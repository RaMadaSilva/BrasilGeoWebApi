using BrasilGeo.Domain.Helpers;

namespace BrasilGeo.Domain.Interfaces.Handlers
{
    public interface IQueryHandler<TQuery, TDto>
    {
        Task<TDto> HandleAsync(TQuery query);

    }
}
