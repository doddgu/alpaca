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
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.HasData(new UserPermission()
            {
                ID = 1,
                AppID = 0,
                PermissionCode = ((int)PermissionCode.Admin).ToString(),
                UserID = 1,
                IsDeleted = false,
                CreateTime = DateTime.Now,
                CreateUserID = 0,
                UpdateTime = DateTime.Now,
                UpdateUserID = 0
            });
        }
    }
}
