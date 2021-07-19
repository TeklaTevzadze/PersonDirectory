using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonDirectory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Persistence.Configurations
{
    public class PhoneNumberTypeConfiguration : IEntityTypeConfiguration<PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
