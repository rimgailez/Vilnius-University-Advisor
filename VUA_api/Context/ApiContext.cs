using Microsoft.EntityFrameworkCore;

namespace VUA_api.Context
{
    public class ApiContext : DbContext
    {
        public DbSet<Lecturer> lecturers { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<StudyProgramme> studyProgrammes { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lecturer>().ToTable("Lecturer");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<StudyProgramme>().ToTable("StudyProgramme");
        }
    }
}
