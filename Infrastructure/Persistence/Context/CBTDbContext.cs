using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class CBTDbContext(DbContextOptions<CBTDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Student>(entity =>
            //{
            //    entity.HasMany(s => s.Subjects)
            //          .WithMany(s => s.Students);
            //});
            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.HasKey(s => s.Id);
            //});

            //modelBuilder.Entity<Subject>(entity =>
            //{
            //    entity.HasMany(s => s.Students)
            //          .WithMany(s => s.Subjects);
            //});
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<CbtSession> CbtSessions { get; set; }
        public DbSet<FreeOption> FreeOptions { get; set; }
        public DbSet<FreeQuestion> FreeQuestions { get; set; }
        public DbSet<SessionQuestion> SessionQuestions { get; set; }

        
    }
}
