﻿using System.ComponentModel.DataAnnotations;

namespace DbAssignment.Entity;

internal class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
}
