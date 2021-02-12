using Alpaca.Infrastructure.Enums.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Enums
{
    public enum ErrorCode
    {
        [EnumDescription(
            ZH = "用户名不存在",
            EN = "User name does not exist")]
        UserNameNotExist = 10001,

        [EnumDescription(
            ZH = "密码错误",
            EN = "The password is incorrect")]
        PasswordIncorrect = 10002,

        [EnumDescription(
            ZH = "用户名已存在",
            EN = "The user name already exists")]
        UserNameExist = 10003,

        [EnumDescription(
            ZH = "名称已存在",
            EN = "Name already exists")]
        NameExist = 10004,
    }
}
