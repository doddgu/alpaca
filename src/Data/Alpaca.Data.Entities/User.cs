using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    [Index(nameof(Name))]
    public class User : EntityBase<int>
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string NickName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
