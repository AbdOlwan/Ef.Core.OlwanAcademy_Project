using EF.InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

namespace EF.InitialMigration.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {


        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.FName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LName)
             .HasColumnType("VARCHAR")
             .HasMaxLength(50)
             .IsRequired();


            builder.HasOne(I => I.Office)
             .WithOne(O => O.Instructor)
             .HasForeignKey<Instructor>(I => I.OfficeId) // this is the foregin key in the Office Entity
             .IsRequired(false); // Office has optional to have instructor but instructor should have Office (required)

            builder.HasIndex(I => I.OfficeId).IsUnique();

            builder.ToTable("Instructors");

        }
    }
}
