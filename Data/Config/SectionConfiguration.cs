using EF.InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace EF.InitialMigration.Data.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {


        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired();


            builder.Property(x => x.SectionName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.HasOne(s => s.Course)
                  .WithMany(c => c.Sections)
                  .HasForeignKey(c => c.CourseId)
                  .IsRequired();

            builder.HasOne(s => s.Instructor)
                 .WithMany(c => c.Sections)
                 .HasForeignKey(c => c.InstructorId)
                 .IsRequired(false);

            builder.HasOne(S => S.Schedule)
                .WithMany(c => c.Sections)
                .HasForeignKey(S => S.ScheduleId)
                .IsRequired();

            builder.OwnsOne(S => S.TimeSlot, Ts =>
            {
                Ts.Property(p => p.StartTime).HasColumnType("time").HasColumnName("StartTime");
                Ts.Property(p => p.EndTime).HasColumnType("time").HasColumnName("EndTime");

            });

            builder.HasMany(s => s.Students)
                      .WithMany(s => s.Sections)
                      .UsingEntity<Enrollment>();

            builder.ToTable("Sections");

        }

    }
}
