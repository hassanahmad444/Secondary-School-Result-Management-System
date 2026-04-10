using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Secondary_School_Result_Management_System.Models.Entities;

namespace Secondary_School_Result_Management_System.Data
{
    public class SchoolResultDbContext : IdentityDbContext<IdentityUser>
    {
        public SchoolResultDbContext(DbContextOptions<SchoolResultDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSubjectClass> TeacherSubjectClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Result - computed properties are not mapped to DB columns
            modelBuilder.Entity<Result>()
                .Ignore(r => r.TotalScore)
                .Ignore(r => r.Grade);

            // TeacherSubjectClass - define the three-way relationship
            modelBuilder.Entity<TeacherSubjectClass>()
                .HasOne(t => t.Teacher)
                .WithMany(t => t.Assignments)
                .HasForeignKey(t => t.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeacherSubjectClass>()
                .HasOne(t => t.Subject)
                .WithMany()
                .HasForeignKey(t => t.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeacherSubjectClass>()
                .HasOne(t => t.SchoolClass)
                .WithMany()
                .HasForeignKey(t => t.SchoolClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}