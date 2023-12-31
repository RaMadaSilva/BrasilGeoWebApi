﻿using BrasilGeo.Domain.Interfaces.Services;

namespace BrasilGeo.Aplications.Services
{
    public class AccountService : IAccountService
    {
        public bool ValidationPassword(string password, string passwordHash)
            => passwordHash.Equals(password);
    }
}
