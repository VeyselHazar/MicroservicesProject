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
    internal class CompanyConfiguration
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.COMPANYNAME).IsRequired().HasMaxLength(255);
            builder.Property(x => x.COUNTRY).HasMaxLength(50);
            builder.Property(x => x.CITY).HasMaxLength(50);
            builder.Property(x => x.DISTRICT).HasMaxLength(50);
            builder.Property(x => x.ZIPCODE).HasMaxLength(50);
            builder.Property(x => x.ADDRESS).HasMaxLength(255);
            builder.Property(x => x.ADDRESS_1).HasMaxLength(255);
            builder.Property(x => x.TAXOFFICE).HasMaxLength(50);
            builder.Property(x => x.TELEPHONE).HasMaxLength(30);
            builder.Property(x => x.TELEPHONE_2).HasMaxLength(35);
            builder.Property(x => x.FAX).HasMaxLength(50);
            builder.Property(x => x.EMAIL).HasMaxLength(100);
            builder.Property(x => x.WEB_URL).HasMaxLength(255);
            builder.Property(x => x.NOTE).HasMaxLength(255);

            builder.Property(x => x.COMPANY_TYPE).IsRequired();
            builder.Property(x => x.IS_ABROAD).IsRequired();
            builder.Property(x => x.SPCODE1).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SPCODE2).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SPCODE3).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SPCODE4).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SPCODE5).IsRequired().HasMaxLength(255);
            builder.Property(x => x.IS_ACTIVE).IsRequired();
            builder.Property(x => x.COMPANY_LEVEL).IsRequired();
            builder.Property(x => x.DELETED_BY).HasMaxLength(50);
            builder.Property(x => x.UPDATED_BY).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UPDATED_ON).IsRequired();
            builder.Property(x => x.CREATED_BY).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CREATED_ON).IsRequired();

        }
    }
}
