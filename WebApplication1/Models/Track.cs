using System.ComponentModel.DataAnnotations;

namespace GraduationProject.API.Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TrackName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
            = DateTime.UtcNow;

        public int LevelId { get; set; }

        public Level? Level { get; set; }

        public ICollection<Exam> Exams { get; set; }
            = new List<Exam>();

        public ICollection<Roadmap> Roadmaps { get; set; }
            = new List<Roadmap>();

        public ICollection<CapstoneProject> CapstoneProjects { get; set; }
            = new List<CapstoneProject>();

        public ICollection<StudentTrack> StudentTracks { get; set; }
            = new List<StudentTrack>();
    }
}
