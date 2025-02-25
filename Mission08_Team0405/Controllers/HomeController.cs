using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0405.Models;
namespace Mission08_Team0405.Controllers;

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
    [HttpGet]
    public IActionResult AddEditTask()
    {
        ViewBag.Categories = _repo.Category.ToList();

        return View();
    }

    [HttpPost]
    public IActionResult AddEditTask(Goal goal)
    {
        if (ModelState.IsValid)
        {
            _repo.Add(goal);  // Add task to repository
            return RedirectToAction("Quadrants");
        }
    
        ViewBag.Categories = _repo.Category.ToList();
        return View(goal);
    }

    [HttpGet]
    public IActionResult EditTask(int id)
    {
        var goal = _repo.Goals.FirstOrDefault(x => x.GoalId == id);
        ViewBag.Categories = _repo.Category.ToList();
        
        return View("AddEditTask", goal);
    }

    [HttpPost]
    public IActionResult EditTask(Goal goal)
    {
        if (ModelState.IsValid)
        {
            _repo.Update(goal);  // Update task
            return RedirectToAction("Quadrants");
        }
    
        ViewBag.Categories = _repo.Category.ToList();
        return View("AddEditTask", goal);
    }
}


