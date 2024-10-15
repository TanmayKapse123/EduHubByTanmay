using System.ComponentModel.DataAnnotations;

namespace EduHubMVC.Models;
   public class User{
    [Key]
    public int  UserID { get; set; }
    public string Username { get; set; }
    public string? Password{get;set;}
    public string? Email{get;set;}
    public string? Mobilenumber{get;set;}
   // public string? UserRole{get;set;}
    public string? Role{ get; set; }
    public bool Active{get;set;}
   
     public string? ProfileImage{get;set;}
     
    }
