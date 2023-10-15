namespace BrasilGeo.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
        }

        public long Id { get; private set; }
    }
}
