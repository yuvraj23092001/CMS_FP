using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmsBackend.Models;

public partial class FinalSmsContext : DbContext
{
    public FinalSmsContext()
    {
    }

    public FinalSmsContext(DbContextOptions<FinalSmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Leave> Leaves { get; set; }

    public virtual DbSet<Notice> Notices { get; set; }

    public virtual DbSet<StudentTeacher> StudentTeachers { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectTeacher> SubjectTeachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:tempDbString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasOne(d => d.FkSubject).WithMany().HasConstraintName("Attendance_SubjectId");

            entity.HasOne(d => d.FkUser).WithMany().HasConstraintName("Attendance_teacher");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC07045BDE3B");

            entity.HasOne(d => d.FkTeacher).WithMany(p => p.Classes).HasConstraintName("Fk_Class");
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Leave__3214EC077F478577");

            entity.HasOne(d => d.FkLeave).WithMany(p => p.Leaves).HasConstraintName("FK_Leave_FK_LeaveId_To_User");
        });

        modelBuilder.Entity<Notice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notice__3214EC07AC51F0FE");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FkCreatedByNavigation).WithMany(p => p.Notices).HasConstraintName("FK_Notice_FK_CreatedBy_To_User");
        });

        modelBuilder.Entity<StudentTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentT__3214EC077FAAC70A");

            entity.HasOne(d => d.FkStudent).WithMany(p => p.StudentTeacherFkStudents).HasConstraintName("ForeignKey");

            entity.HasOne(d => d.FkTeacher).WithMany(p => p.StudentTeacherFkTeachers).HasConstraintName("student_teacher");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.FkSubjectId).HasName("PK__Subject__53ACDEB0926C8B69");
        });

        modelBuilder.Entity<SubjectTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubjectT__3214EC07AF885B92");

            entity.HasOne(d => d.FkSubject).WithMany(p => p.SubjectTeachers).HasConstraintName("Subject_SubjectId");

            entity.HasOne(d => d.FkTeacher).WithMany(p => p.SubjectTeachers).HasConstraintName("subject_teacher");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__206D917020BA3A36");

            entity.HasOne(d => d.FkClass).WithMany(p => p.Users).HasConstraintName("FK_User_FK_ClassId_To_Class");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
