using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    public class ConfigItemSniffer : EntityBase<int>
    {
        public int ConfigAppID { get; set; }

        public string Namespace { get; set; }

        public int Status { get; set; }

        public DateTime VerifyMissingTime { get; set; }
    }
}
