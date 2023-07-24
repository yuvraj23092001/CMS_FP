using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmsBackend.Models;

[Keyless]
[Table("Attendance")]
public partial class Attendance
{
    [Column("FK_SubjectId")]
    public int? FkSubjectId { get; set; }

    [Column("FK_UserId")]
    public int? FkUserId { get; set; }

    public int? Attended { get; set; }

    [ForeignKey("FkSubjectId")]
    public virtual Subject? FkSubject { get; set; }

    [ForeignKey("FkUserId")]
    public virtual User? FkUser { get; set; }
}
