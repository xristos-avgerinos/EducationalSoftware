using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationalSoftware.Models;

[Table("students")]
public partial class Student
{
    [Key]
    [Column("username")]
    [StringLength(40)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(40)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [InverseProperty("UsernameNavigation")]
    public virtual ICollection<StudentDirectionQuiz> StudentDirectionQuizzes { get; set; } = new List<StudentDirectionQuiz>();

    [InverseProperty("UsernameNavigation")]
    public virtual ICollection<StudentDirectionTraffic> StudentDirectionTraffics { get; set; } = new List<StudentDirectionTraffic>();

    [InverseProperty("UsernameNavigation")]
    public virtual ICollection<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();

    [InverseProperty("UsernameNavigation")]
    public virtual ICollection<StudentRecommendationQuiz> StudentRecommendationQuizzes { get; set; } = new List<StudentRecommendationQuiz>();
}
