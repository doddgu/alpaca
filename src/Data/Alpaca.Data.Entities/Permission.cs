using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    public class Permission : EntityBase<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required]
        [MaxLength(24)]
        public string Code { get; set; }
    }
}
