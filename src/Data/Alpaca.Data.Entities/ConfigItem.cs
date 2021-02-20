using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities
{
    [Index(nameof(ConfigAppID), nameof(ConfigEnvironmentID), nameof(IsDeleted))]
    public class ConfigItem : EntityBase<int>
    {
        [Required]
        [MaxLength(200)]
        public string Namespace { get; set; }

        public int ConfigAppID { get; set; }

        public int ConfigEnvironmentID { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
