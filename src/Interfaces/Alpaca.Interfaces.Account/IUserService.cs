using Alpaca.Interfaces.Account.Models;
using System;
using System.Collections.Generic;

namespace Alpaca.Interfaces.Account
{
    public interface IUserService
    {
        UserModel Get(int userID);

        List<string> GetUserPermissionList(int userID);

        void UpsertUser(UserModel user);

        void DeleteUser(int userID);

        void AddUserPermission(UserPermissionModel userPermission);

        void DeleteUserPermission(int userID, int userPermissionID);
    }
}
