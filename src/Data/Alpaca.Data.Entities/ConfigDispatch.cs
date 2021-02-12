using Alpaca.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    public class ConfigDispatch : EntityBase<int>
    {
        public ConfigDispatchType Type { get; set; }

        public string JsonConfig { get; set; }

        public bool Enabled { get; set; }
    }
}
