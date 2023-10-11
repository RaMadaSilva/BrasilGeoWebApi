﻿using System.Text.RegularExpressions;

namespace BrasilGeo.Domain.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string PATTERN = @"/^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/";

        public Email(string adress)
        {
            if (string.IsNullOrEmpty(adress))
                throw new Exception("E-mail invalido"); 
            
            Adress = adress.Trim().ToLower();

            if (Adress.Length < 5)
                throw new Exception("E-mail invalido");

            if (!EmailRegex().IsMatch(Adress))
                throw new Exception("E-mail Invalido"); 
        }

        public string Adress { get;}

        [GeneratedRegex(PATTERN)]
        private static partial Regex EmailRegex();

        public static implicit operator String(Email email) 
            => email.ToString(); 

        public static implicit operator Email(string adress)
            => new Email(adress);
    }
}