using Alpaca.Interfaces.Account.Models;
using System;

namespace Alpaca.Interfaces.Account
{
    public interface IUserService
    {
        UserModel Get(int ID);
    }
}
