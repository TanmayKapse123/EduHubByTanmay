using EduHubMVC.Models;
using EduHubMVC.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using EduHubMVC.ViewModel;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace EduHubMVC.Repository;
public class MaterialRepository : IMaterialService
{
    private readonly AppDbContext _context;
    public MaterialRepository(AppDbContext context)
    {
_context=context;
    }
    public void CreateMaterial(Material newMaterial)
    {
        
        
        _context.Materials.Add(newMaterial);
        _context.SaveChanges();
    }
    public int GetuserId(int cid)
    {
        var data = _context.Courses.FirstOrDefault(x=>x.CourseId == cid);
        
        return data.UserId;
    }
    
    public bool DeleteMaterial(int materialId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Material> GetAllMaterials()
    {
       var data=_context.Materials;
       return data;
    }

   

    public List<Material> GetMaterialByCourseId(int courseId)
    {
       var data = _context.Materials.Where(x => x.CourseId == courseId).ToList(); 
    if (data == null || !data.Any())
    {
        System.Console.WriteLine("No materials found for CourseId: " + courseId);
    }
    return data;
    }

    public void UpdateMaterial(int materialid, Material updatedMaterial)
    {
        throw new NotImplementedException();
    }
    IEnumerable<MaterialsByCourses> GetMaterialsByCourses(int courseId)
    {
        var data = _context.MaterialsByCourses.FromSqlInterpolated($"Sp_MaterialsByCourses {courseId}").ToList();
        if (data == null || !data.Any())
        {
            System.Console.WriteLine("No materials found for CourseId: " + courseId);
        }
        return data;
    }
}