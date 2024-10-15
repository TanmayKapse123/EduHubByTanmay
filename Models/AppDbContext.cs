using Microsoft.EntityFrameworkCore;

namespace EduHubMVC.Models;
public class AppDbContext:DbContext{

public AppDbContext(DbContextOptions<AppDbContext>options):base(options){}
  public DbSet<User> Users{get;set;}  
  public DbSet<Login> logins{get;set;}  
  public DbSet<Course> Courses{get;set;}
  public DbSet<Enrollment> Enrollments{get;set;}
  public DbSet<Material> Materials{get;set;}
   public DbSet<FeedBack> feedBacks{get;set;}
   public DbSet<Enquiry> Enquiries { get; set; }
   public DbSet<MaterialsByCourses>MaterialsByCourses{get;set;}
}