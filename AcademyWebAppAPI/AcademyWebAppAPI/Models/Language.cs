﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebAppAPI.Models;

[Table("Language")]
[Index("IsDeleted", Name = "languageIsDeletedIndex")]
public partial class Language
{
    [Key]
    public long LanguageId { get; set; }

    [Required]
    [StringLength(50)]
    public string LanguageName { get; set; }

    [DefaultValue(false)]
    public bool IsDeleted { get; set; }

    // Navigation Properties

    [InverseProperty("Language")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}