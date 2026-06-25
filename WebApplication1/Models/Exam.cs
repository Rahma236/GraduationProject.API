using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.API.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public int Duration { get; set; } // بالدقائق
        public bool IsPublished { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int TrackId { get; set; }

        [ForeignKey(nameof(TrackId))]
        public virtual Track? Track { get; set; }

        public virtual ICollection<ExamQuestion> Questions { get; set; } = new List<ExamQuestion>();
        public virtual ICollection<StudentExamResult> Results { get; set; } = new List<StudentExamResult>();
    }
}
