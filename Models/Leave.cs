using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmsBackend.Models;

[Table("Leave")]
public partial class Leave
{
    [Key]
    public int Id { get; set; }

    public int IsApproved { get; set; }

    [Column("Leave")]
    public string Leave1 { get; set; } = null!;

    [Column("FK_LeaveId")]
    public int? FkLeaveId { get; set; }

    [ForeignKey("FkLeaveId")]
    [InverseProperty("Leaves")]
    public virtual User? FkLeave { get; set; }
}
