using Alpaca.Infrastructure.Security;
using Alpaca.Model.Account;
using System;

namespace Alpaca.Biz.Account
{
    public class UserBiz
    {
        public UserViewModel GetByPassword(string userName, string password)
        {
            return new UserViewModel()
            {
                ID = 1,
                Name = userName,
                AccessToken = TokenMaker.GetJWT(1, userName)
            };
        }
    }
}
