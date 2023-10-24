namespace BrasilGeo.Domain.Interfaces.Adapter
{
    public interface IAdapter<in TSource, out TDestination>
    {
        TDestination Adapte(TSource source);
    }
}
