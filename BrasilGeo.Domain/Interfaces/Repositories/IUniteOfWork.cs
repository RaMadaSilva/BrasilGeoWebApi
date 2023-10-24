namespace BrasilGeo.Domain.Interfaces.Repositories
{
    public interface IUniteOfWork
    {
        IUserRepository UserRepository { get; }
        ILocationIBGERepository LocationIBGERepository { get; }

        Task CommitAsync();
    }
}
