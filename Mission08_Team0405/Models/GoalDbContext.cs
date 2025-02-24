using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0405.Models;

public class GoalDbContext : DbContext
{
    public GoalDbContext(DbContextOptions<GoalDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Goal> Goals { get; set; }
    
}