using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Security
{
    public class PasswordWrapper
    {
        public static string Encrypt(string password)
        {
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(base64));
                return BitConverter.ToString(result).Replace("-", "");
            }
        }
    }
}
