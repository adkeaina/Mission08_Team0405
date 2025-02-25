using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Quadrants()
        {
            ViewBag.Goals = _repo.Goals.ToList();
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
            var goal = _repo.Goals.FirstOrDefault(x => x.TaskId == taskId);
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
                if (goal.TaskId == 0) // Add new task
                {
                    _repo.Add(goal);
                }
                else // Update existing task
                {
                    _repo.Update(goal);
                }
                _repo.SaveChanges();  // Make sure to save the changes to the repository
                return RedirectToAction("Quadrants");
            }

            // If model state is invalid, return the form with validation errors
            ViewBag.Categories = _repo.Category.ToList();
            return View(goal);
        }
    }
}
