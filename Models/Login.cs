using System.ComponentModel.DataAnnotations;

namespace EduHubMVC.Models;
   public class Login{  //in ma'am project its loginModel
     [Key]
    public string Username { get; set; }
    public string Password { get; set; }
    public string? Role{ get; set; }

     
    }
