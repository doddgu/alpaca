using Alpaca.Infrastructure.Enums.Attributes;
using System;

namespace Alpaca.Infrastructure.Enums
{
    public class EnumWrapper
    {
        public static EnumDescriptionAttribute GetEnumDescription(object enumSubitem)
        {
            enumSubitem = (Enum)enumSubitem;
            string value = enumSubitem.ToString();

            var fieldinfo = enumSubitem.GetType().GetField(value);

            if (fieldinfo != null)
            {
                var objs = fieldinfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

                if (objs != null && objs.Length > 0)
                {
                    return (EnumDescriptionAttribute)objs[0];
                }
                else
                {
                    return new EnumDescriptionAttribute();
                }
            }
            else
            {
                return new EnumDescriptionAttribute();
            }
        }
    }
}
