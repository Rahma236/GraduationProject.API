using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.API.Models
{
    public class CapstoneProject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
            = string.Empty;

        public string? Description { get; set; }

        public int MaxStudents { get; set; }

        public int CurrentStudents { get; set; }

        public bool IsPublished { get; set; }
            = false;

        public DateTime CreatedAt { get; set; }
            = DateTime.UtcNow;

        public string? AdvisorId { get; set; }

        [ForeignKey(nameof(AdvisorId))]
        public User? Advisor { get; set; }

        public int TrackId { get; set; }

        [ForeignKey(nameof(TrackId))]
        public Track? Track { get; set; }

        public ICollection<ProjectMember> ProjectMembers { get; set; }
            = new List<ProjectMember>();
    }
}
