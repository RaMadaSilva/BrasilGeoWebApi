﻿using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Interfaces.Adapter;

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
                    Roles = userDto.Roles.Select(name=>name.RoleName).ToList()
                }
            ); 
        }
    }
}
