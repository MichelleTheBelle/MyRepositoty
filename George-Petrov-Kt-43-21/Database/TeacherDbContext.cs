using Microsoft.EntityFrameworkCore;
using George_Petrov_Kt_43_21.Configurations;
using George_Petrov_Kt_43_21.Models;

namespace George_Petrov_Kt_43_21.Database
{
    public class TeacherDbContext : DbContext
    {
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<TeachingLoad> TeachingLoads { get; set; }
        DbSet<Degree> Degrees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TeachingLoadConfiguration());
            modelBuilder.ApplyConfiguration(new  DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new  PositionConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        }
        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options) 
        {

        }

    }
}
