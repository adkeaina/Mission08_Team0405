namespace Mission08_Team0405.Models;

public interface IGoalsRepository
{
    public List<Goal> Goals { get; }
    public List<Category> Category { get; }
    public void Add(Goal goal);
    public void Update(Goal goal);
    public void Remove(Goal goal);
    public void MarkCompleted(Goal goal);
}