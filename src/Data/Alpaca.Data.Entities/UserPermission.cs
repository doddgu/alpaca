using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    [Index(nameof(UserID), nameof(IsDeleted))]
    public class UserPermission : EntityBase<int>
    {
        public int UserID { get; set; }

        [Required]
        [MaxLength(24)]
        public string PermissionCode { get; set; }

        public int AppID { get; set; }
    }
}
