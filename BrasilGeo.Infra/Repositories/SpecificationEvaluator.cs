using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Interfaces.Specifications;

namespace BrasilGeo.Infra.Repositories
{
    public static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                    .Take(specification.Take);
            }

            //query = specification.Includes.Aggregate
            //    (query, (current, include)
            //        => current.Include(include));

            return query;
        }
    }
}
