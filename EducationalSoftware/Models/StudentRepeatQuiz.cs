using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationalSoftware.Models;

[Keyless]
[Table("studentRepeatQuiz")]
public partial class StudentRepeatQuiz
{
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Username { get; set; }

    [Column("score")]
    public int? Score { get; set; }

    [ForeignKey("Username")]
    public virtual Student? UsernameNavigation { get; set; }
}
