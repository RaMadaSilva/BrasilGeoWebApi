namespace BrasilGeo.Domain.Adapter
{
    public interface IAdapter<in TSource, out TDestination>
    {
        TDestination Adapte(TSource source);
    }
}
