using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Mapping.Model
{
    public class PropertyMapping
    {
        public PropertyInfo PropertyInfo { get; set; }

        public MapperBaseAttribute MapperAttribute { get; set; }

        public PropertyMapping(PropertyInfo propertyInfo, MapperBaseAttribute mapperBaseAttribute)
        {
            this.PropertyInfo = propertyInfo;
            this.MapperAttribute = mapperBaseAttribute;
        }
    }
}
