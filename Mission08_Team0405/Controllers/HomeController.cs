using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Mission08_Team0405.Models;

namespace Mission08_Team0405.Controllers
{
    public class HomeController : Controller
    {
        private IGoalsRepository _repo;

        public HomeController(IGoalsRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Quadrants");
        }

        public IActionResult Quadrants()
        {
            var tasks = _repo.Goals.Where(t => !t.Completed).ToList();

            ViewBag.Quadrant1 = tasks.Where(t => t.Quadrant == 1).ToList();
            ViewBag.Quadrant2 = tasks.Where(t => t.Quadrant == 2).ToList();
            ViewBag.Quadrant3 = tasks.Where(t => t.Quadrant == 3).ToList();
            ViewBag.Quadrant4 = tasks.Where(t => t.Quadrant == 4).ToList();
            
            ViewBag.CompletedTasks = _repo.Goals.Where(t => t.Completed).ToList();
            Console.WriteLine(ViewBag.CompletedTasks.Count);
            ViewBag.Categories = _repo.Category.ToList();
            return View();
        }

        // GET method for Add/Edit Task
        [HttpGet]
        public IActionResult AddEditTask(int? taskId)
        {
            ViewBag.Categories = _repo.Category.ToList();
            
            // If taskId is null, we are adding a new task
            if (taskId == null)
            {
                return View(new Goal());  // Return empty Goal model for new task
            }
            
            // If taskId is provided, fetch the task for editing
            var goal = _repo.Goals.FirstOrDefault(x => x.GoalId == taskId);
            if (goal == null)
            {
                return NotFound();  // If task not found
            }

            return View(goal);
        }

        // POST method for Add/Edit Task
        [HttpPost]
        public IActionResult AddEditTask(Goal goal)
        {
            if (ModelState.IsValid)
            {
                if (goal.GoalId == 0) // Add new task
                {
                    _repo.Add(goal);
                }
                else // Update existing task
                {
                    _repo.Update(goal);
                }
                return RedirectToAction("Quadrants");
            }

            // If model state is invalid, return the form with validation errors
            ViewBag.Categories = _repo.Category.ToList();
            foreach (var modelError in ModelState)
            {
                if (modelError.Value.Errors.Count > 0)
                {
                    foreach (var error in modelError.Value.Errors)
                    {
                        // Log or display error messages
                        Console.WriteLine($"Field: {modelError.Key} - Error: {error.ErrorMessage}");
                        Console.WriteLine(goal.CategoryId);
                    }
                }
            }
            return View(goal);
        }

        public IActionResult DeleteTask(int? taskId)
        {
            if (taskId == null)
            {
                return NotFound();
            }

            var goal = _repo.Goals.FirstOrDefault(x => x.GoalId == taskId);
            if (goal == null)
            {
                return NotFound();
            }

            _repo.Remove(goal);

            return RedirectToAction("Quadrants");
        }

        public IActionResult MarkCompleted(int? taskId)
        {
            var goal = _repo.Goals.FirstOrDefault(g => g.GoalId == taskId);
            if (goal == null)
            {
                // Handle case where the goal is not found
                return NotFound();
            }
            _repo.MarkCompleted(goal);
            return RedirectToAction("Quadrants");
        }
    }
}
