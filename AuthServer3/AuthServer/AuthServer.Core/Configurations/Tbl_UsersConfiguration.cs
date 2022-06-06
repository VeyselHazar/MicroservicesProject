using AuthServer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Configurations
{
    public class Tbl_UsersConfiguration : IEntityTypeConfiguration<Tbl_Users>
    {
        public void Configure(EntityTypeBuilder<Tbl_Users> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name_Surname).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
