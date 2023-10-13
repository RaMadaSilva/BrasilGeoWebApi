using System.Security.Cryptography;
using System.Text;

namespace BrasilGeo.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        public Password(string pass)
        {
            Pass = EncryptPassword(pass);
        }

        public string Pass { get; private set; }

        public static implicit operator Password(string pass) =>new Password(pass);

        public static implicit operator string(Password password) => password.ToString(); 

        private string EncryptPassword(string password)
        {
            var md5 = MD5.Create();
            var code = Encoding.ASCII.GetBytes(password);
            var hash = md5.ComputeHash(code);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));
            return sb.ToString();
        }
    }
}
