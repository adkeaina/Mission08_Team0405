using System;
using System.Collections.Generic;

namespace Mission08_Team0405.Models;

public partial class Goal
{
    public int GoalId { get; set; }

    public string Task { get; set; } = null!;

    public string DueDate { get; set; } = null!;

    public int Quadrant { get; set; }

    public int CategoryId { get; set; }

    public int Completed { get; set; }

    public virtual Category Category { get; set; } = null!;
}
