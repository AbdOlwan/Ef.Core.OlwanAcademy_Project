using EF.InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace EF.InitialMigration.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Course> courses {  get; set; }
        public DbSet < Instructor> instructors { get; set; }
        public DbSet<Office> offices { get; set; }
        public DbSet<Section> sections { get; set; }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var Config = new ConfigurationBuilder()
                .AddJsonFile("appsettengs.json")
                .Build();

            var constr = Config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(constr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Course).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
