using Alpaca.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Robust.Exceptions
{
    public class AException : Exception
    {
        public int ErrorCode { get; set; }

        public string ENMessage { get; set; }

        public string ZHMessage { get; set; }

        public AException() { }

        public AException(ErrorCode errorCode)
        {
            var enumDescription = EnumWrapper.GetEnumDescription(errorCode);

            ErrorCode = (int)errorCode;
            ZHMessage = enumDescription.ZH;
            ENMessage = enumDescription.EN;
        }

        public override string ToString()
        {
            return ENMessage;
        }
    }
}
