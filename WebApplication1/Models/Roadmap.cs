using System.ComponentModel.DataAnnotations;

namespace GraduationProject.API.Models
{
    public class Roadmap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
            = string.Empty;

        public string? Description { get; set; }

        public string RoadmapType { get; set; }
            = "Career";

        public DateTime CreatedAt { get; set; }
            = DateTime.UtcNow;

        public int TrackId { get; set; }

        public Track? Track { get; set; }

        public ICollection<RoadmapStep> Steps { get; set; }
            = new List<RoadmapStep>();

        public ICollection<RoadmapProgress> Progresses { get; set; }
            = new List<RoadmapProgress>();
    }
}
