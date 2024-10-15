using EduHubMVC.Models;
using EduHubMVC.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using EduHubMVC.ViewModel;

namespace EduHubMVC.Repository;
public class EnrollmentRepository : IEnrollmentService
{
    private readonly AppDbContext _context;
    public EnrollmentRepository(AppDbContext context)
    {
_context=context;
    }

  public List<Enrollment> enrollmentsById(int user)
{
    List<int> courseIds = _context.Courses.Where(x => x.UserId == user).Select(x => x.CourseId).ToList();
    
    return _context.Enrollments.Where(x => courseIds.Contains(x.CourseId) && x.Status=="Rejected").ToList();

}

    public List<Enrollment> enrollmentsByIdAndStatus(int user)
    {
        
    List<int> courseIds = _context.Courses.Where(x => x.UserId == user).Select(x => x.CourseId).ToList();
    
    return _context.Enrollments.Where(x => courseIds.Contains(x.CourseId) && x.Status == "Accepted").ToList();
    }

    public List<Enrollment> GetEnrollments()
    {
        List<Enrollment> data = _context.Enrollments.ToList();
         return data;
    }
    public Enrollment Enroll(Enrollment enrollment)
    {
       
        _context.Enrollments.Add(enrollment);
        _context.SaveChanges();
       return enrollment;
    }
     public List<Enrollment> studentEnrollmentsById(int user)
{
    System.Console.WriteLine("Repo=========="+user);
    return _context.Enrollments.Where(x=>x.UserId==user && x.Status=="Rejected").ToList();

}
 public List<Enrollment> studentOnEnrollmentsById(int user)
 {
     return _context.Enrollments.Where(x=>x.UserId==user && x.Status=="Accepted").ToList();
 }
}