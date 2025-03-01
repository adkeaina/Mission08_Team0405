namespace Mission08_Team0405.Models;

public class EFGoalsRepository : IGoalsRepository
{
    private GoalDbContext _context;
    
    public EFGoalsRepository(GoalDbContext context)
    {
        _context = context;
    }
    
    public List<Goal> Goals => _context.Goals.ToList();
    public List<Category> Category => _context.Category.ToList();
    public void Add(Goal goal)
    {
        _context.Add(goal);
        _context.SaveChanges();
    }

    public void Update(Goal goal)
    {
        _context.Update(goal);
        _context.SaveChanges();
    }

    public void Remove(Goal goal)
    {
        _context.Remove(goal);
        _context.SaveChanges();
    }

    public void MarkCompleted(Goal goal)
    {
        goal.Completed = !goal.Completed;
        _context.SaveChanges();
    }
}