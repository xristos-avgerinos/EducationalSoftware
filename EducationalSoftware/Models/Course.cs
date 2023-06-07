using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationalSoftware.Models;

[Table("course")]
public partial class Course
{
    [Key]
    [Column("idCourse")]
    public int IdCourse { get; set; }

    [Column("title")]
    [StringLength(45)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [Column("idDirection")]
    public int? IdDirection { get; set; }

    [ForeignKey("IdDirection")]
    [InverseProperty("Courses")]
    public virtual Direction? IdDirectionNavigation { get; set; }

    [InverseProperty("IdCourseNavigation")]
    public virtual ICollection<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();
}
