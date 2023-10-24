namespace BrasilGeo.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        bool ValidationPassword(string password, string passwordHash);
    }
}
