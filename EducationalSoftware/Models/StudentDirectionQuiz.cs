using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationalSoftware.Models;

[PrimaryKey("IdDirection", "Username")]
[Table("studentDirectionQuiz")]
public partial class StudentDirectionQuiz
{
    [Key]
    [Column("username")]
    [StringLength(40)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Key]
    [Column("idDirection")]
    public int IdDirection { get; set; }

    [Column("score")]
    public int? Score { get; set; }

    [ForeignKey("IdDirection")]
    [InverseProperty("StudentDirectionQuizzes")]
    public virtual Direction IdDirectionNavigation { get; set; } = null!;

    [ForeignKey("Username")]
    [InverseProperty("StudentDirectionQuizzes")]
    public virtual Student UsernameNavigation { get; set; } = null!;
}
