using System.ComponentModel.DataAnnotations;

namespace GraduationProject.API.Models
{
    public class RoadmapProgress
    {
        [Key]
        public int Id { get; set; }

        public int CompletedSteps { get; set; }

        public int TotalSteps { get; set; }

        public int ProgressPercentage { get; set; }

        public string Status { get; set; }
            = "In Progress";

        public DateTime LastUpdatedAt { get; set; }
            = DateTime.UtcNow;

        [Required]
        public string StudentId { get; set; }
            = string.Empty;

        public User? Student { get; set; }

        public int RoadmapId { get; set; }

        public Roadmap? Roadmap { get; set; }
    }
}
