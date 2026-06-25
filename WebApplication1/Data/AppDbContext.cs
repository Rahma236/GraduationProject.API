using GraduationProject.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.API.Data
{
    // 1. خليناه يورث من IdentityDbContext عشان جداول الحسابات الجاهزة
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // 2. جدول الـ Levels بنعرفه هنا (أما جدول الـ Users فالـ Identity بتعرفه تلقائياً)
        public DbSet<Level> Levels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 3. السطر ده مهم جداً عشان يثبت إعدادات جداول الـ Identity الأساسية في الخلفية
            base.OnModelCreating(modelBuilder);

            // 4. تحديد أسماء الجداول بحروف صغيرة في الداتابيز
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Level>().ToTable("levels");

            // 5. تحديد العلاقة (المستخدم له مستوى واحد والمستوى له مستخدمين كتير)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Level)
                .WithMany(l => l.Users)
                .HasForeignKey(u => u.LevelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
