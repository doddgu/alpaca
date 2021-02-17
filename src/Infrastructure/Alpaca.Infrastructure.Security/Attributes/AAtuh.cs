using Alpaca.Infrastructure.Enums;
using Alpaca.Interfaces.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Security.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AAtuh : AuthorizeAttribute, IAuthorizationFilter
    {
        private List<string> _permissionCodes = null;

        public AAtuh(params string[] permissionCodes)
        {
            var tempPermissionCodes = permissionCodes?.ToList() ?? new List<string>();
            _permissionCodes = tempPermissionCodes.Distinct().Select(pc => ((int)Enum.Parse(typeof(PermissionCode), pc)).ToString()).ToList();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Unauthorized);
                return;
            }

            var userPermissions = user.FindAll("AlpacaPermission").Select(c => c.Value).ToList();

            if (userPermissions.Contains(((int)PermissionCode.Admin).ToString())) return;

            if (userPermissions.Intersect(_permissionCodes).Count() > 0) return;

            context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
        }
    }
}
