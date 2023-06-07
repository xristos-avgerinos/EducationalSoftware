using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationalSoftware.Models;

[Table("direction")]
public partial class Direction
{
    [Key]
    [Column("idDirection")]
    public int IdDirection { get; set; }

    [Column("title")]
    [StringLength(45)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [InverseProperty("IdDirectionNavigation")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [InverseProperty("IdDirectionNavigation")]
    public virtual ICollection<StudentDirectionQuiz> StudentDirectionQuizzes { get; set; } = new List<StudentDirectionQuiz>();

    [InverseProperty("IdDirectionNavigation")]
    public virtual ICollection<StudentDirectionTraffic> StudentDirectionTraffics { get; set; } = new List<StudentDirectionTraffic>();

    [InverseProperty("IdDirectionNavigation")]
    public virtual ICollection<StudentRecommendationQuiz> StudentRecommendationQuizzes { get; set; } = new List<StudentRecommendationQuiz>();
}
