using GraduationProject.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.API.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Level> Levels { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<CapstoneProject> CapstoneProjects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<StudentExamResult> StudentExamResults { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<RoadmapStep> RoadmapSteps { get; set; }
        public DbSet<RoadmapProgress> RoadmapProgresses { get; set; }
        public DbSet<JobOpportunity> JobOpportunities { get; set; }
        public DbSet<StudentTrack> StudentTracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table Names

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Level>().ToTable("levels");
            modelBuilder.Entity<Track>().ToTable("tracks");
            modelBuilder.Entity<CapstoneProject>().ToTable("capstone_projects");
            modelBuilder.Entity<ProjectMember>().ToTable("project_members");
            modelBuilder.Entity<Exam>().ToTable("exams");
            modelBuilder.Entity<ExamQuestion>().ToTable("exam_questions");
            modelBuilder.Entity<StudentExamResult>().ToTable("student_exam_results");
            modelBuilder.Entity<Roadmap>().ToTable("roadmaps");
            modelBuilder.Entity<RoadmapStep>().ToTable("roadmap_steps");
            modelBuilder.Entity<RoadmapProgress>().ToTable("roadmap_progresses");
            modelBuilder.Entity<JobOpportunity>().ToTable("job_opportunities");
            modelBuilder.Entity<StudentTrack>().ToTable("student_tracks");

            // User → Level

            modelBuilder.Entity<User>()
                .HasOne(u => u.Level)
                .WithMany(l => l.Users)
                .HasForeignKey(u => u.LevelId)
                .OnDelete(DeleteBehavior.Restrict);

            // Track → Level

            modelBuilder.Entity<Track>()
                .HasOne(t => t.Level)
                .WithMany(l => l.Tracks)
                .HasForeignKey(t => t.LevelId)
                .OnDelete(DeleteBehavior.Restrict);

            // CapstoneProject → Track

            modelBuilder.Entity<CapstoneProject>()
                .HasOne(c => c.Track)
                .WithMany(t => t.CapstoneProjects)
                .HasForeignKey(c => c.TrackId)
                .OnDelete(DeleteBehavior.Restrict);

            // CapstoneProject → Advisor

            modelBuilder.Entity<CapstoneProject>()
                .HasOne(c => c.Advisor)
                .WithMany(u => u.SupervisedProjects)
                .HasForeignKey(c => c.AdvisorId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProjectMember → Student

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.Student)
                .WithMany(u => u.ProjectMembers)
                .HasForeignKey(pm => pm.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProjectMember → Project

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.Project)
                .WithMany(p => p.ProjectMembers)
                .HasForeignKey(pm => pm.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // StudentTrack → Student

            modelBuilder.Entity<StudentTrack>()
                .HasOne(st => st.Student)
                .WithMany(u => u.StudentTracks)
                .HasForeignKey(st => st.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // StudentTrack → Track

            modelBuilder.Entity<StudentTrack>()
                .HasOne(st => st.Track)
                .WithMany(t => t.StudentTracks)
                .HasForeignKey(st => st.TrackId)
                .OnDelete(DeleteBehavior.Cascade);

            // Exam → Track

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Track)
                .WithMany(t => t.Exams)
                .HasForeignKey(e => e.TrackId)
                .OnDelete(DeleteBehavior.Restrict);

            // ExamQuestion → Exam

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(eq => eq.Exam)
                .WithMany(e => e.Questions)
                .HasForeignKey(eq => eq.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            // StudentExamResult → Student

            modelBuilder.Entity<StudentExamResult>()
                .HasOne(sr => sr.Student)
                .WithMany(u => u.ExamResults)
                .HasForeignKey(sr => sr.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // StudentExamResult → Exam

            modelBuilder.Entity<StudentExamResult>()
                .HasOne(sr => sr.Exam)
                .WithMany(e => e.Results)
                .HasForeignKey(sr => sr.ExamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Roadmap → Track

            modelBuilder.Entity<Roadmap>()
                .HasOne(r => r.Track)
                .WithMany(t => t.Roadmaps)
                .HasForeignKey(r => r.TrackId)
                .OnDelete(DeleteBehavior.Restrict);

            // RoadmapStep → Roadmap

            modelBuilder.Entity<RoadmapStep>()
                .HasOne(rs => rs.Roadmap)
                .WithMany(r => r.Steps)
                .HasForeignKey(rs => rs.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade);

            // RoadmapProgress → Student

            modelBuilder.Entity<RoadmapProgress>()
                .HasOne(rp => rp.Student)
                .WithMany(u => u.RoadmapProgresses)
                .HasForeignKey(rp => rp.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // RoadmapProgress → Roadmap

            modelBuilder.Entity<RoadmapProgress>()
                .HasOne(rp => rp.Roadmap)
                .WithMany(r => r.Progresses)
                .HasForeignKey(rp => rp.RoadmapId)
                .OnDelete(DeleteBehavior.Restrict);


            // Seed Data

            modelBuilder.Entity<Level>().HasData(

                new Level
                {
                    Id = 1,
                    LevelName = "Beginner",
                    MinScore = 0,
                    MaxScore = 40,
                    Description = "Beginner level"
                },

                new Level
                {
                    Id = 2,
                    LevelName = "Intermediate",
                    MinScore = 41,
                    MaxScore = 70,
                    Description = "Intermediate level"
                },

                new Level
                {
                    Id = 3,
                    LevelName = "Advanced",
                    MinScore = 71,
                    MaxScore = 100,
                    Description = "Advanced level"
                }
            );
        }
    }
}
