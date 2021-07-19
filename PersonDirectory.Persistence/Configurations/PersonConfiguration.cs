using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonDirectory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(o => o.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(o => o.LastName).IsRequired().HasMaxLength(50);
            builder.Property(o => o.GenderId).IsRequired(false);
            builder.Property(o => o.IdentityNumber).IsRequired().HasMaxLength(11);
            builder.Property(o => o.BirthDate).IsRequired();
            builder.Property(o => o.DateCreated).IsRequired();

            builder.HasOne(o => o.Gender).WithMany().HasForeignKey(o => o.GenderId);
        }
    }
}
