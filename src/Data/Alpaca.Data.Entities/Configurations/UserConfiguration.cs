using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Data.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User()
            {
                ID = 1,
                Name = "admin",
                NickName = "Admin",
                Password = "DB69FC039DCBD2962CB4D28F5891AAE1",
                IsDeleted = false,
                CreateTime = DateTime.Now,
                CreateUserID = 0,
                UpdateTime = DateTime.Now,
                UpdateUserID = 0
            });
        }
    }
}
