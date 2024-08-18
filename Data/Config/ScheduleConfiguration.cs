using EF.InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EF.InitialMigration.Enums;

namespace EF.InitialMigration.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {


        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired();



            builder.Property(s => s.TiTle)
                .HasConversion(
                  x => x.ToString(),
                  x => (ScheduelEnum)Enum.Parse(typeof(ScheduelEnum), x)
                  );




            builder.ToTable("Schedules");

        }

      
    }

}
