﻿using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Entities;

namespace BrasilGeo.Aplications.Adapter
{
    public class UserToDtoAdapter : IAdapter<User, UserDto>
    {
        public UserDto Adapte(User source)
        {
            return new UserDto
            {
                Id = source.Id,
                Email = source.Email,
                Roles = source.Roles.Select(name=>name.RoleName).ToList(),
            }; 
        }

    }
}
