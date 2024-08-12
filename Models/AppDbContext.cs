using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.ViewModels;

namespace WebApplication1.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResult { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public AppDbContext()
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-9TOTELO; Initial Catalog = MyDatabase ; Integrated Security=True; Trust Server Certificate=True; ");
        //    base.OnConfiguring(optionsBuilder);

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>()
            .HasMany(x => x.Instructors).WithOne(x => x.Department).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Department>()
            .HasMany(x => x.Courses).WithOne(x => x.Department).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Course>()
            .HasMany(x => x.Instructors).WithOne(x => x.Course).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CrsResult>()
                .HasOne(x => x.Course).WithMany(x => x.CrsResults).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CrsResult>().HasKey(x => new { x.Course_Id, x.Student_id }) ;

            modelBuilder.Entity<CrsResult>()
                .HasOne(x => x.Student).WithMany(x => x.CrsResults).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CrsResult>()
                .HasKey(x => new { x.Course_Id, x.Student_id });

            modelBuilder.Entity<RegistureUserViewModel>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }


    }
}
