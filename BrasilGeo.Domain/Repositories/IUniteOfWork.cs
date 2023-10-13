namespace BrasilGeo.Domain.Repositories
{
    public interface IUniteOfWork
    {
        IUserRepository UserRepository { get; }

        Task CommitAsync(); 
    }
}
