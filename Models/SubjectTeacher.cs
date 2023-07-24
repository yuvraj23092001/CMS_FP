using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmsBackend.Models;

[Table("SubjectTeacher")]
public partial class SubjectTeacher
{
    [Key]
    public int Id { get; set; }

    [Column("FK_SubjectId")]
    public int? FkSubjectId { get; set; }

    [Column("FK_TeacherId")]
    public int? FkTeacherId { get; set; }

    [ForeignKey("FkSubjectId")]
    [InverseProperty("SubjectTeachers")]
    public virtual Subject? FkSubject { get; set; }

    [ForeignKey("FkTeacherId")]
    [InverseProperty("SubjectTeachers")]
    public virtual User? FkTeacher { get; set; }
}
