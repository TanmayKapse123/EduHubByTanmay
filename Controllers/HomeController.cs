using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EduHubMVC.Models;
using EduHubMVC.ViewModel;
using EduHubMVC.Services;

namespace EduHubMVC.Controllers;

public class HomeController : Controller
{
      private readonly IUserService _userservice;
        private readonly AppDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
[HttpGet]
    public IActionResult Index()
    {
        return View();
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
[HttpPost]
public IActionResult Index(LoginViewModel model)
{
        var data = _userservice.LoginStudent(model);
        if (data != null && data.Password==model.Password && data.Role=="student")
        {
           // ViewBag.Role = data.Username;
            TempData["Student"]=data.Username;
            return RedirectToAction("StudentDashBoard");
        }
        else
        {
         return RedirectToAction("Index","Home");   
        }
 
    return View();
}

 
 
}

