using System;
using System.ComponentModel.DataAnnotations;

namespace EduHubMVC.Models;
public class FeedBack
{
    [Key]
     public int FeedbackId { get; set; }
    public int UserId { get; set; }
    public int CourceId { get; set; }
    public string Feedback { get; set; }
    public DateTime Date { get; set; }

    
}
