using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Alpaca.Service.Open
{
    public static class UserExtension
    {
        public static int GetUserID(this ClaimsPrincipal claims)
        {
            return int.Parse(claims.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
