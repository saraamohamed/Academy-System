﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebAppAPI.Models;

[Table("Group")]
[Index("IsDeleted", Name = "groupIsDeletedIndex")]
public partial class Group
{
    [Key]
    public int GroupId { get; set; }

    [Required]
    [StringLength(70)]
    public string GroupName { get; set; }

    [DefaultValue(false)]
    public bool AcademyInNumbersPage { get; set; }

    [DefaultValue(false)]
    public bool GroupsPage { get; set; }

    [DefaultValue(false)]
    public bool UsersPage { get; set; }

    [DefaultValue(false)]
    public bool BranchesPage { get; set; }

    [DefaultValue(false)]
    public bool CoursesPage { get; set; }

    [DefaultValue(false)]
    public bool SubjectsPage { get; set; }

    [DefaultValue(false)]
    public bool TraineeAdditionPage { get; set; }

    [DefaultValue(false)]
    public bool CoursesToTraineeAdditionPage { get; set; }

    [DefaultValue(false)]
    public bool TraineeCombinedAccountStatementPage { get; set; }

    [DefaultValue(false)]
    public bool IsDeleted { get; set; }

    // Navigation Properties

    [InverseProperty("Group")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}