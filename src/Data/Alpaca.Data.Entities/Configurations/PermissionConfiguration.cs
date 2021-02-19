using Alpaca.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            var id = 0;

            var lstPermission = Enum.GetNames(typeof(PermissionCode)).Select(pc => new Permission()
            {
                ID = ++id,
                Code = ((int)Enum.Parse(typeof(PermissionCode), pc)).ToString(),
                Name = pc,
                IsDeleted = false,
                CreateTime = DateTime.Now,
                CreateUserID = 0,
                UpdateTime = DateTime.Now,
                UpdateUserID = 0
            }).ToList();

            builder.HasData(lstPermission);
        }
    }
}
