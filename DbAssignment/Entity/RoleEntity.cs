﻿using System.ComponentModel.DataAnnotations;

namespace DbAssignment.Entity;

internal class RoleEntity
{
    [Key]
    public int Id { get; set; }
    public string RoleName { get; set; } = null!;
}
