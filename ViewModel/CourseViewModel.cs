    namespace EduHubMVC.ViewModel;
    public class CourseViewModel
{
    public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CourseStartDate { get; set; }
        public string CourseEndDate { get; set; }
        public int UserId { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public int ActiveC { get; set; }
}