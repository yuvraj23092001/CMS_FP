/*using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmsBackend.Models;

public partial class SmsContext : DbContext
{
    public SmsContext()
    {
    }

    public SmsContext(DbContextOptions<SmsContext> options)
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

    *//*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:tempDbString");


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*//*
}
*/