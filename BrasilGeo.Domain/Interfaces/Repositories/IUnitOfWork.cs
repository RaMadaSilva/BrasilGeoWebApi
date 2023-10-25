namespace BrasilGeo.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ILocationIBGERepository LocationIBGERepository { get; }

        Task CommitAsync();
    }
}
