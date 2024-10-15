using EduHubMVC.Models;
using EduHubMVC.ViewModel;

namespace EduHubMVC.Services;
public interface IEnrollmentService
{
  public List<Enrollment> enrollmentsById(int course);
    public List<Enrollment> enrollmentsByIdAndStatus(int course);
  public List<Enrollment> GetEnrollments();
  public Enrollment Enroll(Enrollment enrollment);
     public List<Enrollment> studentEnrollmentsById(int user);
     public List<Enrollment> studentOnEnrollmentsById(int user);
}