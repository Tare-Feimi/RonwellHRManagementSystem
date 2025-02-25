namespace RonwellHR.Application.Projects.Models
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; } 
        public string EndDate { get; set; }
    }
}
