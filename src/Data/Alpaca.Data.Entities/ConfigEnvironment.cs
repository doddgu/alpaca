using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    public class ConfigEnvironment : EntityBase<int>
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
