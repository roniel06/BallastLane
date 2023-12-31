﻿using System.ComponentModel.DataAnnotations;

namespace BallastLane.Infrastructure.Models.Core;

public abstract class BaseModel
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}
