using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmsBackend.Models;

[Table("User")]
[Index("EmailId", Name = "UQ__User__7ED91AEE3EAFA3AD", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("User_Id")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int UserRole { get; set; }

    [Column("DOB", TypeName = "datetime")]
    public DateTime Dob { get; set; }

    public int? Salary { get; set; }

    public int Contact { get; set; }

    [Column("EmailID")]
    [StringLength(256)]
    public string EmailId { get; set; } = null!;

    [Column("FK_ClassId")]
    public int? FkClassId { get; set; }

    [InverseProperty("FkTeacher")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    [ForeignKey("FkClassId")]
    [InverseProperty("Users")]
    public virtual Class? FkClass { get; set; }

    [InverseProperty("FkLeave")]
    public virtual ICollection<Leave> Leaves { get; set; } = new List<Leave>();

    [InverseProperty("FkCreatedByNavigation")]
    public virtual ICollection<Notice> Notices { get; set; } = new List<Notice>();

    [InverseProperty("FkStudent")]
    public virtual ICollection<StudentTeacher> StudentTeacherFkStudents { get; set; } = new List<StudentTeacher>();

    [InverseProperty("FkTeacher")]
    public virtual ICollection<StudentTeacher> StudentTeacherFkTeachers { get; set; } = new List<StudentTeacher>();

    [InverseProperty("FkTeacher")]
    public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}
