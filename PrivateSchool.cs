using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IndividualProjectB
{
    public partial class PrivateSchool : DbContext
    {
        public PrivateSchool()
            : base("name=PrivateSchool")
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Assignments)
                .Map(m => m.ToTable("assignment_course").MapLeftKey("assignmentID").MapRightKey("courseID"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Trainers)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("trainers_course").MapLeftKey("courseID").MapRightKey("trainerID"));

            modelBuilder.Entity<Student>()
                .Property(e => e.tuitions)
                .HasPrecision(5, 1);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Courses)
                .WithMany(e => e.Students)
                .Map(m => m.ToTable("student_course").MapLeftKey("studentID").MapRightKey("courseID"));
        }
    }
}
