using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    public class ConfigApp : EntityBase<int>
    {
        public string Name { get; set; }

        public int VerifyMissingDays { get; set; }
    }
}
