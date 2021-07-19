using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonDirectory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDirectory.Persistence.Configurations
{
    public class PersonRelationshipConfiguration : IEntityTypeConfiguration<PersonRelationship>
    {
        public void Configure(EntityTypeBuilder<PersonRelationship> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.RelatedToPersonId).IsRequired();
            builder.Property(o => o.RelatedPersonId).IsRequired();
            builder.Property(o => o.RelationshipTypeId).IsRequired();

            builder.HasOne(x => x.RelatedToPerson).WithMany(x => x.RelatedPersons).HasForeignKey(x => x.RelatedToPersonId);
            builder.HasOne(x => x.RelatedPerson).WithMany().HasForeignKey(x => x.RelatedPersonId);
            builder.HasOne(x => x.RelationshipType).WithMany().HasForeignKey(x => x.RelationshipTypeId);

        }
    }
}
