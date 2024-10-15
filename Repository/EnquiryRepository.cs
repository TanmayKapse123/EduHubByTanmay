using EduHubMVC.Models;
using EduHubMVC.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using EduHubMVC.ViewModel;

namespace EduHubMVC.Repository;
public class EnquiryRepository : IEnquiryService
{
    private readonly AppDbContext _context;
    public EnquiryRepository(AppDbContext context)
    {
_context=context;
    }

    public List<Enquiry> EnquiryByCId(int user)
    {
        List<int> courseIds = _context.Courses.Where(x => x.UserId == user).Select(x => x.CourseId).ToList();
    
    return _context.Enquiries.Where(x => courseIds.Contains(x.CourseId) && x.Response=="Pending").ToList();
    }
public List<Enquiry> GetAllEnquiries()
{
    List<Enquiry> data=_context.Enquiries.ToList();
    return data;
}
 public Enquiry addEnquiry(Enquiry enquiry)
    {
       
        _context.Enquiries.Add(enquiry);
        _context.SaveChanges();
       return enquiry;
    }
     public List<Enquiry> EnquiryByCIdStudent(int user)
    {
       
    
    return _context.Enquiries.Where(x => x.UserId==user && x.Response=="Pending").ToList();
    }

}