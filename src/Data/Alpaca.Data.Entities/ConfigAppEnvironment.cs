using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    public class ConfigAppEnvironment : EntityBase<int>
    {
        public int ConfigAppID { get; set; }

        public int ConfigEnvironmentID { get; set; }
    }
}
