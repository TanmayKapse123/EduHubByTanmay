using EduHubMVC.Controllers;
using EduHubMVC.Models;
using EduHubMVC.Services;
using EduHubMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduHubMVC.Controllers;
    public class StudentController : Controller{
        private readonly ICourseService _courseService;
        private readonly AppDbContext _context;
        public StudentController(ICourseService userService,AppDbContext context)
        {
         _courseService=userService;
         _context=context;
       
        }
        public IActionResult AllCourse()
    {
        // var courses =  _context.Courses;
        var courses=_courseService.SGetCourses();
        return View(courses);
 
    }

    }