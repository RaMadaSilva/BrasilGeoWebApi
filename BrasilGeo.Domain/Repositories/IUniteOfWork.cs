namespace BrasilGeo.Domain.Repositories
{
    public interface IUniteOfWork
    {
        IUserRepository UserRepository { get; }
        ILocationIBGERepository LocationIBGERepository { get; }

        Task CommitAsync(); 
    }
}
