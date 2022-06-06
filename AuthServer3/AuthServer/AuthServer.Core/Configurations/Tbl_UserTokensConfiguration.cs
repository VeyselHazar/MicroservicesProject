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
    public class Tbl_UserTokensConfiguration : IEntityTypeConfiguration<Tbl_UserTokens>
    {
        public void Configure(EntityTypeBuilder<Tbl_UserTokens> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Token).IsRequired().HasMaxLength(200);
        }
    }
}
