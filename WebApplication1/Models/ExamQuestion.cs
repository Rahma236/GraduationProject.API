using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.API.Models
{
    public class ExamQuestion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; } = string.Empty;

        [Required] public string OptionA { get; set; } = string.Empty;
        [Required] public string OptionB { get; set; } = string.Empty;
        [Required] public string OptionC { get; set; } = string.Empty;
        [Required] public string OptionD { get; set; } = string.Empty;

        [Required]
        public string CorrectAnswer { get; set; } = string.Empty;

        public int ExamId { get; set; }

        [ForeignKey(nameof(ExamId))]
        public virtual Exam? Exam { get; set; }
    }
}
