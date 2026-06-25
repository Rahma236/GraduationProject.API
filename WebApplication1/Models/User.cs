using Microsoft.AspNetCore.Identity;
using System;

namespace GraduationProject.API.Models
{
    // خليناه يورث من IdentityUser عشان يآخد الخصائص الجاهزة
    public class User : IdentityUser
    {
        // الحقول الأساسية (Id, Email, PasswordHash) موروثة تلقائياً وجاهزة من الـ IdentityUser

        // 2. الحقول الخاصة بمشروعكم اللي مش موجودة في الـ Identity وهنزودها هنا:
        public string FullName { get; set; } // الاسم بالكامل
        public string ProfilePictureUrl { get; set; } // صورة الحساب
        public string UserType { get; set; } // نوع المستخدم (مثلاً: طالب، مرشد، أدمن)
        public int? MaxStudents { get; set; } //الحد الأقصى للطلابـ  
        public string Specialization { get; set; } // التخصص
        public bool IsActive { get; set; } = true; // هل الحساب نشط؟
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // وقت التسجيل

        // 3. العلاقات (الربط مع جدول المستويات)
        public int LevelId { get; set; }
        public Level Level { get; set; }
    }
}
