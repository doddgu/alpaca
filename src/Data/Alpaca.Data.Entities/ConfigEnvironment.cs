using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    public class ConfigEnvironment : EntityBase<int>
    {
        public string Name { get; set; }
    }
}
