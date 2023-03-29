using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Repository
{
    public class SchoolContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public SchoolContext(DbContextOptions<SchoolContext> opt): base(opt) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            // modelBuilder.Entity<Classroom>()
            //     .HasMany(c => c.students)
            //     .WithOne(s => s.classroom)
            //     .HasForeignKey(s => s.ClassroomID);
        }
    }
}
