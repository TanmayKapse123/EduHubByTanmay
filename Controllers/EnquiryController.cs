using EduHubMVC.Controllers;
using EduHubMVC.Models;
using EduHubMVC.Services;
using EduHubMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduHubMVC.Controllers;
    public class EnquiryController : Controller{
        private readonly IEnquiryService _Enquiryservice;
        private readonly AppDbContext _context;
        public EnquiryController(IEnquiryService Enquiryservice,AppDbContext _context)
        {
          
            _Enquiryservice=Enquiryservice;
            this._context=_context;
        }
    public IActionResult AllEnquiries()
    {
        var Enquiries =_Enquiryservice.GetAllEnquiries();
        return View(Enquiries);
    }
   public IActionResult GetEnquiryById(int id)
        {
            var data = _Enquiryservice.EnquiryByCId(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
       
       [HttpGet]
     public IActionResult addEnquiry(int id)
{
   

    var En = new Enquiry
    {
        CourseId = id,
        Status = "In Progress",
        Response="Pending"
    };

    return View(En);
} 
[HttpPost]
  public IActionResult addEnquiry(Enquiry enquiry)
  {
    if (ModelState.IsValid)
    {
       _Enquiryservice.addEnquiry(enquiry);
        return RedirectToAction("AllCourse", "Student");
    }
    
    // Log the model state errors for debugging
    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
    {
        Console.WriteLine(error.ErrorMessage);
    }

    return View(enquiry);

  }
  public IActionResult enquiryStudentByuid(int id)
  {
    var data=_Enquiryservice.EnquiryByCIdStudent(id);
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
                    var data = _context.Enquiries.FirstOrDefault(y => y.EnquiryId == id);
                    if(data==null)
                    {
                        return NotFound();
                    }
                    return View(data);
                }
        }
          [HttpPost]
        public IActionResult Edit(Enquiry modified,int? id )
        {
            var data = _context.Enquiries.FirstOrDefault(y => y.EnquiryId == id);
            if (data == null)
            {
                return NotFound();
            }
            data.Status=modified.Status;
             data.Response=modified.Response;
            _context.SaveChanges();
           return RedirectToAction("EducatorDashBoard","Educator");
        }


 }

  