using System.ComponentModel.DataAnnotations;

namespace GraduationProject.API.Models
{
    public class StudentExamResult
    {
        [Key]
        public int Id { get; set; }

        public int Score { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime ExamDate { get; set; }
            = DateTime.UtcNow;

        [Required]
        public string StudentId { get; set; }
            = string.Empty;

        public User? Student { get; set; }

        public int ExamId { get; set; }

        public Exam? Exam { get; set; }
    }
}
