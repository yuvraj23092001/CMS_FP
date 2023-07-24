using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmsBackend.Models;

[Table("Class")]
public partial class Class
{
    [Key]
    public int Id { get; set; }

    [Column("FK_TeacherId")]
    public int? FkTeacherId { get; set; }

    [StringLength(50)]
    public string? ClassName { get; set; }

    [ForeignKey("FkTeacherId")]
    [InverseProperty("Classes")]
    public virtual User? FkTeacher { get; set; }

    [InverseProperty("FkClass")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
