using Alpaca.Infrastructure.Enums.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Enums
{
    public enum PermissionCode
    {
        [EnumDescription(
            ZH = "管理员",
            EN = "Admin")]
        Admin = 100,

        [EnumDescription(
            ZH = "用户权限管理",
            EN = "User permission management")]
        UserPermissionManagement = 100101,

        [EnumDescription(
            ZH = "用户管理",
            EN = "User management")]
        UserManagemenet = 100102,
    }
}
