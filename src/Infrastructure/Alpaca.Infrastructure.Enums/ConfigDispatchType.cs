using Alpaca.Infrastructure.Enums.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Enums
{
    public enum ConfigDispatchType
    {
        [EnumDescription(
            ZH = "Redis",
            EN = "Redis")]
        Redis = 1,

        [EnumDescription(
            ZH = "OwnIntegration",
            EN = "自有集成")]
        OwnIntegration = 2,
    }
}
