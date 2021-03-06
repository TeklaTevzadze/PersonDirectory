// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonDirectory.Persistence.Context;

namespace PersonDirectory.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonDirectory.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("PersonDirectory.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PersonDirectory.Domain.Entities.PersonRelationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime2");

                    b.Property<int>("RelatedPersonId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedToPersonId")
                        .HasColumnType("int");

                    b.Property<int>("RelationshipTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RelatedPersonId");

                    b.HasIndex("RelatedToPersonId");

                    b.HasIndex("RelationshipTypeId");

                    b.ToTable("PersonRelationships");
                });

            modelBuilder.Entity("PersonDirectory.Domain.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumberTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("PhoneNumberTypeId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("PersonDirectory.Domain.Entities.PhoneNumberType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhoneNumberTypes");
                });

            modelBuilder.Entity("PersonDirectory.Domain.Entities.RelationshipType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RelationshipTypes");
                });

            modelBuilder.Entity("PersonDirectory.Domain.Entities.Person", b =>
                {
                    b.HasOne("PersonDirectory.Domain.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("PersonDirectory.Domain.Entities.PersonRelationship", b =>
                {
                    b.HasOne("PersonDirectory.Domain.Entities.Person", "RelatedPerson")
                        .WithMany()
                        .HasForeignKey("RelatedPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PersonDirectory.Domain.Entities.Person", "RelatedToPerson")
                        .WithMany("RelatedPersons")
                        .HasForeignKey("RelatedToPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PersonDirectory.Domain.Entities.RelationshipType", "RelationshipType")
                        .WithMany()
                        .HasForeignKey("RelationshipTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RelatedPerson");

                    b.Navigation("RelatedToPerson");

                    b.Navigation("RelationshipType");
                });

            modelBuilder.Entity("PersonDirectory.Domain.Entities.PhoneNumber", b =>
                {
                    b.HasOne("PersonDirectory.Domain.Entities.Person", "Person")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PersonDirectory.Domain.Entities.PhoneNumberType", "PhoneNumberType")
                        .WithMany()
                        .HasForeignKey("PhoneNumberTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("PhoneNumberType");
                });

            modelBuilder.Entity("PersonDirectory.Domain.Entities.Person", b =>
                {
                    b.Navigation("PhoneNumbers");

                    b.Navigation("RelatedPersons");
                });
#pragma warning restore 612, 618
        }
    }
}
