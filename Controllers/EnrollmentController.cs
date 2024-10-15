using EduHubMVC.Controllers;
using EduHubMVC.Models;
using EduHubMVC.Services;
using EduHubMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduHubMVC.Controllers;
    public class EnrollmentController : Controller{
         private readonly IEnrollmentService _enrollservice;
        private readonly AppDbContext _context;
        public EnrollmentController(AppDbContext context,IEnrollmentService enrollment)
        {
         _enrollservice=enrollment;
         _context=context;
        }
 public IActionResult GetEnrollments()
{ 
    var data=_enrollservice.GetEnrollments();
    return View(data);
          
}
  public IActionResult GetEnrollmentsById(int id){
     
     var data= _enrollservice.enrollmentsById(id);
    
       return View(data);
  }
  public IActionResult GetEnrollmentsByIdAndStatus(int id){
     
     var data= _enrollservice.enrollmentsByIdAndStatus(id);
    
       return View(data);
  }
  [HttpGet]
    public IActionResult Edit(int? id)
        {
              if(id==null)
                {
                    return View();
                }
                else{
                    var data=_context.Enrollments.FirstOrDefault(x=>x.EnrollmentId==id);
                    if(data==null)
                    {
                        return NotFound();
                    }
                    return View(data);
                }
        }
          [HttpPost]
        public IActionResult Edit(int? id, Enrollment modified)
        {
            var data = _context.Enrollments.FirstOrDefault(y => y.EnrollmentId == id);
            if (data == null)
            {
                return NotFound();
            }
            data.Status=modified.Status;
            _context.SaveChanges();
           return RedirectToAction("GetEnrollments","Enrollment");
        }
public IActionResult Enroll(int id)
{
   

    var En = new Enrollment
    {
        CourseId = id,
        Status = "Rejected",
    };

    return View(En);
}




[HttpPost]
public IActionResult Enroll(Enrollment enrollment)
{
    if (ModelState.IsValid)
    {
        _enrollservice.Enroll(enrollment);
        return RedirectToAction("AllCourse", "Student");
    }
    
    // Log the model state errors for debugging
    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
    {
        Console.WriteLine(error.ErrorMessage);
    }

    return View(enrollment);
}
[HttpGet]
 public IActionResult StudentGetEnrollmentsById(int id){
     Console.WriteLine("=============="+id);
     var data= _enrollservice.studentEnrollmentsById(id);
    
       return View(data);
  }
  [HttpGet]
 public IActionResult StudentOnGetEnrollmentsById(int id){
     Console.WriteLine("=============="+id);
     var data= _enrollservice.studentOnEnrollmentsById(id);
    
       return View(data);
  }


    }