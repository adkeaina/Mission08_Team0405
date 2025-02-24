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

    public IActionResult AddEditTask()
    {
        ViewBag.Categories = _repo.Category.ToList();

        return View();
    }

}
