using EduHubMVC.Controllers;
using EduHubMVC.Models;
using EduHubMVC.Services;
using EduHubMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduHubMVC.Controllers;
    public class CourseController : Controller{
      
        private readonly AppDbContext _context;
         private readonly ICourseService _courseService;
        //   private readonly IUserService _userservice;
        public CourseController(AppDbContext context,ICourseService  courseService)
        {
         
         _context=context;
         _courseService=courseService;
        }
        
            public IActionResult CreateCourse(){
                 List<SelectListItem> Levels = new List<SelectListItem>()
       {
        new SelectListItem { Text = "Basic", Value = "Basic" },
        new SelectListItem{ Text="Advance",Value="Advance"},
        new SelectListItem{ Text="Advance",Value="Advance"},
        
        };
         ViewBag.role = Levels;
           
            return View();
        }
        [HttpPost]
   public IActionResult CreateCourse(Course newCourse)
{
    if (ModelState.IsValid)
    {
        _context.Courses.Add(newCourse);
        _context.SaveChanges();
        return RedirectToAction("EducatorDashBoard", "Educator");
    }
    return View(newCourse);
}

        public IActionResult Details(int? id)
        {
                if(id==null)
                {
                    return View();
                }
                else{
                    var data=_context.Courses.FirstOrDefault(x=>x.CourseId==id);
                    if(data==null)
                    {
                        return NotFound();
                    }
                    return View(data);
                }
        }
        public IActionResult Edit(int? id)
        {
              if(id==null)
                {
                    return View();
                }
                else{
                    var data=_context.Courses.FirstOrDefault(x=>x.CourseId==id);
                    if(data==null)
                    {
                        return NotFound();
                    }
                    return View(data);
                }
        }
        [HttpPost]
        public IActionResult Edit(int id, Course modified)
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
            _courseService.Edit(id,modified);
           return RedirectToAction("AllCourse","Course");
        }
      
      public IActionResult EducatorCourses(int id){
         Console.WriteLine($"Received id: {id}");
     var data= _courseService.CourseById(id);
       return View(data);

    //     System.Console.WriteLine(id);
    // var data = _context.Courses.Where(x => x.UserId == id);
    //    return View(data);
}
 public IActionResult AllCourse()
    {
        // var courses =  _context.Courses;
        var courses=_courseService.GetCourses();
        return View(courses);
 
    }
    public IActionResult individualCourses(int id)
    {
         var data= _courseService.CourseById(id);
       return View(data);
    }
        
}