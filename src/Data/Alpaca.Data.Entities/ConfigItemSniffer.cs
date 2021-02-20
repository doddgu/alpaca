using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    [Index(nameof(ConfigAppID), nameof(Namespace), nameof(IsDeleted))]
    public class ConfigItemSniffer : EntityBase<int>
    {
        public int ConfigAppID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Namespace { get; set; }

        public int Status { get; set; }

        public DateTime VerifyMissingTime { get; set; }
    }
}
