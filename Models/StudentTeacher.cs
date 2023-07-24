using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmsBackend.Models;

[Table("StudentTeacher")]
public partial class StudentTeacher
{
    [Key]
    public int Id { get; set; }

    [Column("FK_StudentId")]
    public int? FkStudentId { get; set; }

    [Column("FK_TeacherId")]
    public int? FkTeacherId { get; set; }

    [ForeignKey("FkStudentId")]
    [InverseProperty("StudentTeacherFkStudents")]
    public virtual User? FkStudent { get; set; }

    [ForeignKey("FkTeacherId")]
    [InverseProperty("StudentTeacherFkTeachers")]
    public virtual User? FkTeacher { get; set; }
}
