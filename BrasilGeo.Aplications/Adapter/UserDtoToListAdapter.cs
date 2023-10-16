using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Entities;

namespace BrasilGeo.Aplications.Adapter
{
    public class UserDtoToListAdapter : IAdapter<IEnumerable<User>, IEnumerable<UserDto>>
    {
        public IEnumerable<UserDto> Adapte(IEnumerable<User> source)
        {
            return source.Select(userDto => new UserDto
                {
                    Id = userDto.Id,
                    Email = userDto.Email,
                    Roles = (List<string>)userDto.Roles
                }
            ); 
        }
    }
}
