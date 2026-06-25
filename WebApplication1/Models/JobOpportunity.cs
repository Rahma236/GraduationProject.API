using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProject.API.Models
{
    public class JobOpportunity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
    }
}
