using System.ComponentModel.DataAnnotations;
using GraduationProject.API.Enums;

namespace GraduationProject.API.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Level Id is required.")]
        public int LevelId { get; set; }

        [Required(ErrorMessage = "User Type is required.")]
        public UserType UserType { get; set; }

        [StringLength(100, ErrorMessage = "Specialization cannot exceed 100 characters.")]
        public string? Specialization { get; set; }
    }
}
