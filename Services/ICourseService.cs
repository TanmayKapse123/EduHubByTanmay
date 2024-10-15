using EduHubMVC.Models;
using EduHubMVC.ViewModel;

namespace EduHubMVC.Services;
public interface ICourseService
{
    
// Course CreateUser(Course newCourse);
// // int Details(int id);
Course Edit(int id,Course course);
object CourseById(int course);
public List<Course> GetCourses();
public List<Course> SGetCourses();

}