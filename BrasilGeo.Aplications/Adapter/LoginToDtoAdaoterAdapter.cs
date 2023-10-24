using BrasilGeo.Aplications.Commands.UserCommands;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Interfaces.Adapter;

namespace BrasilGeo.Aplications.Adapter
{
    public class LoginToDtoAdaoterAdapter : IAdapter<LoginCommand, LoginDto>
    {
        public LoginDto Adapte(LoginCommand source)
        {
            return new LoginDto
            {
                Email = source.Email,
                Password = source.Password,
            };
        }
    }
}
