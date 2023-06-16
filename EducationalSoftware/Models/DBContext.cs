using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EducationalSoftware.Models;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentDirectionQuiz> StudentDirectionQuizzes { get; set; }

    public virtual DbSet<StudentDirectionTraffic> StudentDirectionTraffics { get; set; }

    public virtual DbSet<StudentGrade> StudentGrades { get; set; }

    public virtual DbSet<StudentRecommendationQuiz> StudentRecommendationQuizzes { get; set; }

    public virtual DbSet<StudentRepeatQuiz> StudentRepeatQuizzes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MITSOSNOTEBOOK\\SQLEXPRESS;Database=EduSoftDB;Trusted_Connection=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.IdCourse).HasName("course_pk");

            entity.HasOne(d => d.IdDirectionNavigation).WithMany(p => p.Courses).HasConstraintName("course_direction_idDirection_fk");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.IdDirection).HasName("idDirection");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("students_pk");
        });

        modelBuilder.Entity<StudentDirectionQuiz>(entity =>
        {
            entity.HasKey(e => new { e.IdDirection, e.Username }).HasName("studentDirectionQuiz_pk");

            entity.HasOne(d => d.IdDirectionNavigation).WithMany(p => p.StudentDirectionQuizzes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studentDirectionQuiz_direction_idDirection_fk");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.StudentDirectionQuizzes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studentDirectionQuiz_students_username_fk");
        });

        modelBuilder.Entity<StudentDirectionTraffic>(entity =>
        {
            entity.HasKey(e => new { e.IdDirection, e.Username }).HasName("studentDirectionTraffic_pk");

            entity.Property(e => e.Traffic).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.IdDirectionNavigation).WithMany(p => p.StudentDirectionTraffics)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studentDirectionTraffic_direction_idDirection_fk");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.StudentDirectionTraffics)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studentDirectionTraffic_students_username_fk");
        });

        modelBuilder.Entity<StudentGrade>(entity =>
        {
            entity.HasKey(e => new { e.IdCourse, e.Username }).HasName("studentGrades_pk");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.StudentGrades)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studentGrades_course_idCourse_fk");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.StudentGrades)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studentGrades_students_username_fk");
        });

        modelBuilder.Entity<StudentRecommendationQuiz>(entity =>
        {
            entity.HasKey(e => new { e.IdDirection, e.Username }).HasName("studentRecommendationQuiz_pk");

            entity.HasOne(d => d.IdDirectionNavigation).WithMany(p => p.StudentRecommendationQuizzes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studentRecommendationQuiz_direction_idDirection_fk");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.StudentRecommendationQuizzes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("studentRecommendationQuiz_students_username_fk");
        });

        modelBuilder.Entity<StudentRepeatQuiz>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.UsernameNavigation).WithMany().HasConstraintName("studentRepeatQuiz_students_username_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
