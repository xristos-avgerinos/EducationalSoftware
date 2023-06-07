using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationalSoftware.Models;

[PrimaryKey("IdCourse", "Username")]
[Table("studentGrades")]
public partial class StudentGrade
{
    [Key]
    [Column("username")]
    [StringLength(40)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Key]
    [Column("idCourse")]
    public int IdCourse { get; set; }

    [Column("grade")]
    public int? Grade { get; set; }

    [ForeignKey("IdCourse")]
    [InverseProperty("StudentGrades")]
    public virtual Course IdCourseNavigation { get; set; } = null!;

    [ForeignKey("Username")]
    [InverseProperty("StudentGrades")]
    public virtual Student UsernameNavigation { get; set; } = null!;
}
