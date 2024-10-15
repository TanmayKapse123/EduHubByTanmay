using EduHubMVC.Models;
using EduHubMVC.ViewModel;

namespace EduHubMVC.Services;
public interface IEnquiryService
{
   public List<Enquiry> EnquiryByCId(int id);
   public List<Enquiry> GetAllEnquiries();
   public Enquiry addEnquiry(Enquiry enquiry);
   public List<Enquiry> EnquiryByCIdStudent(int user);
}