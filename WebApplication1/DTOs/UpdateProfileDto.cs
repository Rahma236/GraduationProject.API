using System.ComponentModel.DataAnnotations;

namespace GraduationProject.API.DTOs
{

    public class UpdateProfileDto
    {
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
        public string? FullName { get; set; }

        [StringLength(100, ErrorMessage = "Specialization cannot exceed 100 characters.")]
        public string? Specialization { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; set; }

        [Url(ErrorMessage = "Invalid URL format for profile picture.")]
        public string? ProfilePictureUrl { get; set; }
    }

}
