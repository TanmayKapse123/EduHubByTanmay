using System;
using System.ComponentModel.DataAnnotations;

namespace EduHubMVC.Models;
public class Material
{
    [Key]
    public int materialId { get; set; }
    public int CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime UploadDate { get; set; }
    public string Url { get; set; }
    public string ContentType { get; set; }
}

