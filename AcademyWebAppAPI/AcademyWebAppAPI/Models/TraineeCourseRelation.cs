﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebAppAPI.Models;

[PrimaryKey("TraineeId", "CourseId")]
[Table("TraineeCourseRelation")]
public partial class TraineeCourseRelation
{
    [Key]
    public long TraineeId { get; set; }

    [Key]
    public int CourseId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? RegistrationDate { get; set; }

    // Navigation Properties

    [ForeignKey("CourseId")]
    [InverseProperty("TraineeCourseRelations")]
    public virtual Course Course { get; set; }

    [ForeignKey("TraineeId")]
    [InverseProperty("TraineeCourseRelations")]
    public virtual Trainee Trainee { get; set; }
}