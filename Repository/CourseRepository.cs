using EduHubMVC.Models;
using EduHubMVC.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using EduHubMVC.ViewModel;

namespace EduHubMVC.Repository;
public class CourseRepository : ICourseService
{
    private readonly AppDbContext _context;
    public CourseRepository(AppDbContext context)
    {
        _context=context;
    }

    public Course CreateUser(Course newCourse)
    {
        _context.Courses.Add(newCourse);
        _context.SaveChanges();
       return newCourse;
    }
   public Course Edit(int id,Course modified)
    {
      
              var data = _context.Courses.FirstOrDefault(y => y.CourseId == id);
            if (data == null)
            {
                return null;
            }
            data.Title = modified.Title;
            data.Description = modified.Description;
            data.CourseStartDate= modified.CourseStartDate;
            data.Level=modified.Level;
           _context.SaveChanges();
           return data;
                
    }

    public object CourseById(int course)
{
 
    var courses = _context.Courses.Where(x => x.UserId == course).ToList();
    return courses;
}
public List<Course> GetCourses()
{
    List<Course> data=_context.Courses.ToList();
    return data;
}
public List<Course> SGetCourses()
{
    var data = (from courses in _context.Courses
                join users in _context.Users on courses.UserId equals users.UserID
                where users.Active == true
                select courses).ToList();
    // List<Course> l=_context.Courses.ToList();
    return data;
}

}