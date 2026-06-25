namespace GraduationProject.API.Models
{
    public class Level
    {
        public int Id { get; set; } // الرقم التعريفي للمستوى
        public string Name { get; set; } // اسم المستوى (مبتدئ - متوسط)
        public string Description { get; set; } // وصف المستوى

        // علاقة: المستوى الواحد جواه مستخدمين كتير
        public ICollection<User> Users { get; set; }
    }
}

