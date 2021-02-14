using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Model.Config.ConfigAppModels
{
    public class ConfigAppViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int VerifyMissingDays { get; set; }

        public int UpdateUserID { get; set; }

        public string UpdateUserName { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
