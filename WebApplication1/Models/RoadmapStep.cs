using System.ComponentModel.DataAnnotations;

namespace GraduationProject.API.Models
{
    public class RoadmapStep
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StepName { get; set; }
            = string.Empty;

        public string? Description { get; set; }

        public string? ResourceLink { get; set; }

        public int Order { get; set; }

        public bool IsCompleted { get; set; } = false;

        public int RoadmapId { get; set; }

        public Roadmap? Roadmap { get; set; }
    }
}
