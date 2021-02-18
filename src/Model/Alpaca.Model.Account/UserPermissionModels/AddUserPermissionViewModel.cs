using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Model.Account.UserPermissionModels
{
    public class AddUserPermissionViewModel
    {
        public int UserID { get; set; }

        public string PermissionCode { get; set; }

        public int AppID { get; set; }
    }
}
