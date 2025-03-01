using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0405.Models;

public partial class Goal
{
    public int GoalId { get; set; }

    public string Task { get; set; } = null!;

    public string DueDate { get; set; } = null!;

    public int Quadrant { get; set; }
    
    [ForeignKey("CategoryID")]
    public int CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public bool Completed { get; set; }
}
