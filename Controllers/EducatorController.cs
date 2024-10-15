using EduHubMVC.Controllers;
using EduHubMVC.Models;
using EduHubMVC.Services;
using EduHubMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduHubMVC.Controllers;
    public class EducatorController : Controller{
        private readonly IUserService _userservice;
        private readonly AppDbContext _context;
        public EducatorController(IUserService userService,AppDbContext context)
        {
         _userservice=userService;
         _context=context;
       
        }
        [HttpGet]
        public IActionResult EducatorLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EducatorLogin(LoginViewModel model)
        {
            var data = _userservice.LoginEducator(model);
         if (data != null && data.Password==model.Password && data.Role=="educator")
        {
            // ViewBag.Role = data.Username;
            TempData["E"]=data.Username;
            TempData["i"]=data.UserID;
            return RedirectToAction("EducatorDashBoard","Educator");
        }
        else
        {
         return RedirectToAction("Index","Home");   
        }
           
        }
         
    public IActionResult EducatorDashBoard()
{
    return View();
}


    }