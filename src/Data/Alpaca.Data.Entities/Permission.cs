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
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
