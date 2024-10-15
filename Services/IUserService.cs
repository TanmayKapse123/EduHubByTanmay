using EduHubMVC.Models;
using EduHubMVC.ViewModel;

namespace EduHubMVC.Services;
public interface IUserService
{
   public  User CreateUser(User newUser);
   public  List<User> AllEducator();
    User LoginStudent(LoginViewModel model);//in ma'am project its getStudent(string name,string password,string role)
    User LoginEducator(LoginViewModel model);//in ma'am project its getEducator(string name,string password,string role)
 public User Edit(int id,User modified);
}