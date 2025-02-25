using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0405.Models;

public partial class GoalDbContext : DbContext
{
    public GoalDbContext()
    {
    }

    public GoalDbContext(DbContextOptions<GoalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }
    
}
