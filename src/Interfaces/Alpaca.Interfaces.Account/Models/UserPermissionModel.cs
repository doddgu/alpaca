using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Interfaces.Account.Models
{
    public class UserPermissionModel
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public string PermissionCode { get; set; }

        public int AppID { get; set; }
    }
}
