using EduHubMVC.Models;
using EduHubMVC.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using EduHubMVC.ViewModel;

namespace EduHubMVC.Repository;
public class UserRepository : IUserService
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context=context;
    }
      public  List<User> AllEducator()
      {
        
        return _context.Users.Where(x=>x.Role=="educator" && x.Active==true).ToList();
      }
    public User CreateUser(User newUser)
    {
        _context.Users.Add(newUser);
        _context.SaveChanges();
       return newUser;
    }

    public User LoginEducator(LoginViewModel model)
    {
        User user=_context.Users.FirstOrDefault(x=>x.Username==model.Username);
      
        return user;
       
    }

    public User LoginStudent(LoginViewModel model)
    {
        User user1 = _context.Users.FirstOrDefault(y => y.Username == model.Username);
        return user1;
    
    }
     public User Edit(int id,User modified)
    {
      
              var data = _context.Users.FirstOrDefault(y => y.UserID == id);
            if (data == null)
            {
                return null;
            }
            data.Active = modified.Active;
            data.Username = modified.Username;
            data.Email= modified.Email;
            data.Mobilenumber=modified.Mobilenumber;
           _context.SaveChanges();
           return data;
                
    }
}