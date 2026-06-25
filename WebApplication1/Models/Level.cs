using System.Collections.Generic;

namespace GraduationProject.API.Models
{
    public class Level
    {
        public int Id { get; set; } 
        public string LevelName { get; set; } 
        public int MinScore { get; set; } 
        public int MaxScore { get; set; } 
        public string Description { get; set; } 

        // علاقة: المستوى الواحد جواه مستخدمين كتير
        public ICollection<User> Users { get; set; }
    }
}
