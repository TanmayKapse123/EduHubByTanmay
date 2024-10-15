using EduHubMVC.Controllers;
using EduHubMVC.Models;
using EduHubMVC.Services;
using EduHubMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EduHubMVC.Controllers;
    public class MaterialController : Controller{
     
        private readonly IMaterialService _MService;
        
        public MaterialController(IMaterialService service)
        {
            _MService=service;
           
        }
       public IActionResult AddMaterial(int id)
{
    var material = new Material
    {
        CourseId = id
    };
   
    return View(material);
}

[HttpPost]
public IActionResult AddMaterial(int cid, Material newMaterial)
{
    newMaterial.CourseId = cid;

    if (ModelState.IsValid)
    {
        int data=_MService.GetuserId(cid);
        _MService.CreateMaterial(newMaterial);
    
        return RedirectToAction("EducatorCourses", "Course",new{id = data});
    }
    return View(newMaterial);
}
public IActionResult getMaterialByCid(int id)
{
    System.Console.WriteLine("========================" + id);
    var materials = _MService.GetMaterialByCourseId(id);
    if (materials == null)
    {
        return NotFound();
    }
    return View(materials);
}


    }