using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission08_Team0405.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mission08_Team0405.Views.Task
{
    public class QuadrantsModel : PageModel
    {
        private readonly IGoalsRepository _repo;

        public QuadrantsModel(IGoalsRepository repo)
        {
            _repo = repo;
        }

        public List<Goal> Quadrant1 { get; set; } = new();
        public List<Goal> Quadrant2 { get; set; } = new();
        public List<Goal> Quadrant3 { get; set; } = new();
        public List<Goal> Quadrant4 { get; set; } = new();

        public void OnGet()
        {
            var tasks = _repo.Goals.Where(t => !t.Completed).ToList();

            Quadrant1 = tasks.Where(t => t.Quadrant == 1).ToList();
            Quadrant2 = tasks.Where(t => t.Quadrant == 2).ToList();
            Quadrant3 = tasks.Where(t => t.Quadrant == 3).ToList();
            Quadrant4 = tasks.Where(t => t.Quadrant == 4).ToList();
        }
    }
}
