using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Enums.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class EnumDescriptionAttribute : Attribute
    {
        public string ZH { get; set; }

        public string EN { get; set; }
    }
}
