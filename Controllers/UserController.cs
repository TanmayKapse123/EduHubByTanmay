using EduHubMVC.Controllers;
using EduHubMVC.Models;
using EduHubMVC.Services;
using EduHubMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduHubMVC.Controllers;
    public class UserController : Controller{
        private readonly IUserService _userservice;
        private readonly AppDbContext _context;
        public UserController(IUserService userService,AppDbContext _context)
        {
         _userservice=userService;
         this._context=_context;
       
        }
        public IActionResult Index(){
            return View();
        }
        [HttpGet]
    public IActionResult CreateUser()
    {
        List<SelectListItem> userroles = new List<SelectListItem>()
       {
        new SelectListItem { Text = "Educator", Value = "Educator" },
        new SelectListItem{ Text="Student",Value="student"},
        
        };
        ViewBag.role = userroles;
        return View();
    }
    [HttpPost]
    public IActionResult CreateUser(User newuser)
    {
        _userservice.CreateUser(newuser);

        return RedirectToAction("Index","Home");
    }
    public IActionResult Login()
   {
    return View();
}
[HttpPost]
public IActionResult Login(LoginViewModel model)
{
    
        var data = _userservice.LoginStudent(model);
        
        if (data != null && data.Password==model.Password && data.Role=="student")
        {
            
           // ViewBag.Role = data.Username;
        //    HttpContext.Session.SetString("A", data.Username);
             TempData["Student"]=data.Username;
            TempData["uid"]=data.UserID;
            TempData.Keep();
            return RedirectToAction("StudentDashBoard","User");
        }
        else if (data != null && data.Password==model.Password && data.Role=="educator" || data.Role=="Educator")
        {
            // ViewBag.Role = data.Username;
            TempData["E"]=data.Username;
            TempData["UserId"]=data.UserID;
            TempData.Keep();
            return RedirectToAction("EducatorDashBoard","Educator");
        }
        else
        {
         return RedirectToAction("Index","Home");   
        }
 
    return View();
}
public IActionResult StudentDashBoard(int id){
    
    return View();
}


public IActionResult AllEducator()
{
  var data= _userservice.AllEducator(); 
  return View(data);
}


  public ActionResult LogOut(){              
       return RedirectToAction("Index", "Home");
   }
    public IActionResult Edit(int? id)
        {
              if(id==null)
                {
                    return View();
                }
                else{
                    var data=_context.Users.FirstOrDefault(x=>x.UserID==id);
                    if(data==null)
                    {
                        return NotFound();
                    }
                    return View(data);
                }
        }
        [HttpPost]
        public IActionResult Edit(int id, User modified)
        {
            // var data = _context.Courses.FirstOrDefault(y => y.CourseId == id);
            // if (data == null)
            // {
            //     return NotFound();
            // }
            // data.Title = modified.Title;
            // data.Description = modified.Description;
            // data.CourseStartDate= modified.CourseStartDate;
            // data.Level=modified.Level;
            // _context.SaveChanges();
            _userservice.Edit(id,modified);
           return RedirectToAction("EducatorDashBoard","Educator");
        }
   
}
    