using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

using WebApplication1.context;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers;

[Authorize]

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    ApplicationContext context ;

     public HomeController(ApplicationContext context, ILogger<HomeController> logger)
    {
        this.context = context;
        // Use the logger as needed
    }

    

    public IActionResult Index()
    
    {
        var students = context.Students.ToList();
        var groups = context.Groups.ToList();
        ViewBag.groups = groups;
        return View(students);
        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
