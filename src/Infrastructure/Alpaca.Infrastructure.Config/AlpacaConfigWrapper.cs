using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Config
{
    public class AlpacaConfigWrapper
    {
        private static IConfiguration _config = null;

        static AlpacaConfigWrapper()
        {
            _config = new ConfigurationBuilder()
            .AddJsonFile("Alpaca.json", false, true)
            .Build();
        }

        public static string GetConnectionString(string name = "Default")
        {
            return _config.GetConnectionString(name);
        }

        public static string GetTokenSecretKey()
        {
            var secretKey = _config["Token:SecretKey"];
            if (string.IsNullOrWhiteSpace(secretKey))
            {
                secretKey = "doddgu.alpaca@github";
            }

            return secretKey;
        }
    }
}
