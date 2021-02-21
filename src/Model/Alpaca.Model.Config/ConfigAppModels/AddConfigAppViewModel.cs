using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Model.Config.ConfigAppModels
{
    public class AddConfigAppViewModel
    {
        public string Name { get; set; }

        public int VerifyMissingDays { get; set; }

        public List<int> AppEnvironmentList { get; set; }
    }
}
