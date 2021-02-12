using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Interfaces.Account.Models
{
    public class UserModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public string AccessToken { get; set; }
    }
}
