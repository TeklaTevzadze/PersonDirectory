using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonDirectory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Persistence.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.PersonId).IsRequired();
            builder.Property(o => o.PhoneNumberTypeId).IsRequired();
            builder.Property(o => o.Number).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Person).WithMany(x => x.PhoneNumbers).HasForeignKey(x => x.PersonId);
            builder.HasOne(x => x.PhoneNumberType).WithMany().HasForeignKey(x => x.PhoneNumberTypeId);
        }
    }
}
