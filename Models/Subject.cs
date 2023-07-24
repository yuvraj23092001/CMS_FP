using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmsBackend.Models;

[Table("Subject")]
public partial class Subject
{
    [Key]
    [Column("FK_SubjectId")]
    public int FkSubjectId { get; set; }

    [StringLength(50)]
    public string? SubjectName { get; set; }

    [InverseProperty("FkSubject")]
    public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}
