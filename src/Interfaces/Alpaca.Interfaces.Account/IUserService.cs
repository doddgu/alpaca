using Alpaca.Interfaces.Account.Models;
using System;
using System.Collections.Generic;

namespace Alpaca.Interfaces.Account
{
    public interface IUserService
    {
        UserModel Get(int userID);

        List<string> GetUserPermissionList(int userID);
    }
}
