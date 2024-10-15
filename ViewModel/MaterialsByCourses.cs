using System.ComponentModel.DataAnnotations;

public class MaterialsByCourses
    {
        [Key]
 
        public int MaterialId { get; set; }
        public string Course_Title { get; set; }
        public string Material_Title { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public string ContentType { get; set; }
    }