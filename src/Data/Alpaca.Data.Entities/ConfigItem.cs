using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    public class ConfigItem : EntityBase<int>
    {
        public string Namespace { get; set; }

        public int ConfigAppID { get; set; }

        public int ConfigEnvironmentID { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }
}
