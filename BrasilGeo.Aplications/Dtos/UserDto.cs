﻿namespace BrasilGeo.Aplications.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
