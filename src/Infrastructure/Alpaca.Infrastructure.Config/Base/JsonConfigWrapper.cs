using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Config.Base
{
    public class JsonConfigWrapper
    {
        private IConfiguration _config = null;

        public IConfiguration Configuration { get { return _config; } }

        public JsonConfigWrapper(string jsonFilePath)
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile(jsonFilePath, false, true)
                .Build();
        }

        public string GetConnectionString(string name = "Default")
        {
            return _config.GetConnectionString(name);
        }

        public TConfig GetModel<TConfig>(string sectionKey)
        {
            return _config.GetSection(sectionKey).Get<TConfig>();
        }

        public void RegisterChangeCallback(Action<object> callback)
        {
            var reloadToken = _config.GetReloadToken();
            reloadToken.RegisterChangeCallback((o) =>
            {
                try
                {
                    callback(o);
                }
                finally
                {
                    RegisterChangeCallback(callback);
                }
            }, _config);
        }
    }
}
