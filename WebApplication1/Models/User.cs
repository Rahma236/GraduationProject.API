using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.API.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        public string ProfilePictureUrl { get; set; } = "default.png";

        public string? UserType { get; set; } = "Student"; // جعلناه Nullable لتجنب تحذيرات الـ Compiler

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? LevelId { get; set; }
        public Level? Level { get; set; }

        public string Specialization { get; set; } = "General";

        public int? MaxStudents { get; set; }
        public string? Department { get; set; }

        public ICollection<CapstoneProject> SupervisedProjects { get; set; } = new List<CapstoneProject>();
        public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
        public ICollection<StudentExamResult> ExamResults { get; set; } = new List<StudentExamResult>();
        public ICollection<RoadmapProgress> RoadmapProgresses { get; set; } = new List<RoadmapProgress>();
        public ICollection<StudentTrack> StudentTracks { get; set; } = new List<StudentTrack>();
        public ICollection<Roadmap> Roadmaps { get; set; } = new List<Roadmap>();
    }
}
