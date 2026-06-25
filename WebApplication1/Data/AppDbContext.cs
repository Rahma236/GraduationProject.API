using GraduationProject.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // بنعرفه إن دي الجداول اللي هتروح الـ SQL Server
        public DbSet<User> Users { get; set; }
        public DbSet<Level> Levels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // لتثبيت أسماء الجداول في الداتابيز بحروف صغيرة (Naming Convention)
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Level>().ToTable("levels");

            // تحديد العلاقة (المستخدم له مستوى واحد والمستوى له مستخدمين كتير)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Level)
                .WithMany(l => l.Users)
                .HasForeignKey(u => u.LevelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
