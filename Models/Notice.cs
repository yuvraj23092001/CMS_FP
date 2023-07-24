using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmsBackend.Models;

[Table("Notice")]
public partial class Notice
{
    [Key]
    public int Id { get; set; }

    [Column("Notice")]
    public string? Notice1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column("FK_CreatedBy")]
    public int? FkCreatedBy { get; set; }

    [ForeignKey("FkCreatedBy")]
    [InverseProperty("Notices")]
    public virtual User? FkCreatedByNavigation { get; set; }
}
