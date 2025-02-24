using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0405.Models;

namespace Mission08_Team0405.Controllers;

public class HomeController : Controller
{
    private EFGoalsRepository
    
    public IActionResult Quadrant()
    {
        return View();
    }

    public IActionResult AddEditTasks()
    {
        return View();
    }

}