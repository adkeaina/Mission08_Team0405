namespace Mission08_Team0405.Models;

public class EFGoalsRepository : IGoalsRepository
{
    private GoalDbContext _context;

    public EFGoalsRepository(GoalDbContext context)
    {
        _context = context;
    }

    public List<Goal> Goals = _context.Goal.ToList();
}