using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context
{
    public class CBTDbContext(DbContextOptions<CBTDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasMany(s => s.Subjects)
                      .WithMany(s => s.Students);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasMany(s => s.Students)
                      .WithMany(s => s.Subjects);
            });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<CbtSession> CbtSessions { get; set; }
        public DbSet<SessionResult> SessionResults { get; set; }
    }
}
