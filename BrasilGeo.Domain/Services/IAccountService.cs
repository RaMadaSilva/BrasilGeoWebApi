namespace BrasilGeo.Domain.Services
{
    public  interface IAccountService
    {
        bool ValidationPassword(string password, string passwordHash); 
    }
}
