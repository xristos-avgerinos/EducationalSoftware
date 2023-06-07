using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationalSoftware.Models;

[PrimaryKey("IdDirection", "Username")]
[Table("studentDirectionTraffic")]
public partial class StudentDirectionTraffic
{
    [Key]
    [Column("username")]
    [StringLength(40)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Key]
    [Column("idDirection")]
    public int IdDirection { get; set; }

    [Column("traffic")]
    public int? Traffic { get; set; }

    [ForeignKey("IdDirection")]
    [InverseProperty("StudentDirectionTraffics")]
    public virtual Direction IdDirectionNavigation { get; set; } = null!;

    [ForeignKey("Username")]
    [InverseProperty("StudentDirectionTraffics")]
    public virtual Student UsernameNavigation { get; set; } = null!;
}
