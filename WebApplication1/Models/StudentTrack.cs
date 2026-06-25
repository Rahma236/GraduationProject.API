using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.API.Models
{
    public class StudentTrack
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StudentId { get; set; } = string.Empty;

        [ForeignKey(nameof(StudentId))]
        public User? Student { get; set; }

        [Required]
        public int TrackId { get; set; }

        [ForeignKey(nameof(TrackId))]
        public Track? Track { get; set; }

        public DateTime EnrolledAt { get; set; }
            = DateTime.UtcNow;

        public string Status { get; set; }
            = "Active";
    }
}
