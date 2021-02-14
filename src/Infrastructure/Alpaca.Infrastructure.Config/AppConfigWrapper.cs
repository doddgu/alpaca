using Alpaca.Infrastructure.Config.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Config
{
    public class AppConfigWrapper
    {
        private static JsonConfigWrapper _wrapper = null;

        static AppConfigWrapper()
        {
            _wrapper = new JsonConfigWrapper("appsettings.json");
        }

        public static string GetConnectionString(string name = "Default")
        {
            return _wrapper.GetConnectionString(name);
        }

        public static TConfig GetModel<TConfig>(string sectionKey)
        {
            return _wrapper.GetModel<TConfig>(sectionKey);
        }

        public static void RegisterChangeCallback(Action<object> callback)
        {
            _wrapper.RegisterChangeCallback(callback);
        }

        public static IConfiguration GetConfiguration()
        {
            return _wrapper.Configuration;
        }
    }
}
