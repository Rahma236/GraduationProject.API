using System.ComponentModel.DataAnnotations;

namespace GraduationProject.API.Models
{
    public class Level
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LevelName { get; set; } = string.Empty;

        public int MinScore { get; set; }

        public int MaxScore { get; set; }

        public string? Description { get; set; }

        public ICollection<User> Users { get; set; }
            = new List<User>();

        public ICollection<Track> Tracks { get; set; }
            = new List<Track>();
    }
}
