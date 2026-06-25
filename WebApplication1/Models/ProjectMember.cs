using System.ComponentModel.DataAnnotations;

namespace GraduationProject.API.Models
{
    public class ProjectMember
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StudentId { get; set; }
            = string.Empty;

        public User? Student { get; set; }

        public int ProjectId { get; set; }

        public CapstoneProject? Project { get; set; }

        public DateTime JoinedAt { get; set; }
            = DateTime.UtcNow;

        public string Role { get; set; }
            = "Developer";
    }
}
