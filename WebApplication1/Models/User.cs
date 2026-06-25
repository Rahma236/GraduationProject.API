namespace GraduationProject.API.Models
{
    public class User
    {
        public int Id { get; set; } // رقم المستخدم
        public string FullName { get; set; } // الاسم بالكامل
        public string Email { get; set; } // الإيميل
        public string PasswordHash { get; set; } // الباسورد مشفرة
        public string ProfilePictureUrl { get; set; } // صورة الحساب
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // وقت التسجيل

        // الربط مع جدول المستويات (Foreign Key)
        public int LevelId { get; set; }
        public Level Level { get; set; }
    }
}


