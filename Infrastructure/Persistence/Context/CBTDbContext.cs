﻿using CBTPreparation.Domain.AdminAggregate;
using CBTPreparation.Domain.CbtSessionAggregate;
using CBTPreparation.Domain.FreeQuestionAggregate;
using CBTPreparation.Domain.StudentAggregate;
using CBTPreparation.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CBTPreparation.Infrastructure.Persistence.Context
{
    public class CBTDbContext(DbContextOptions<CBTDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<CbtSession> CbtSessions => Set<CbtSession>();
        public DbSet<FreeQuestion> FreeQuestions => Set<FreeQuestion>();
        public DbSet<TrialTransaction> Transactions => Set<TrialTransaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(CBTDbContextSchema.DefaultSchema);

            modelBuilder.Entity<Student>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Admin>().HasQueryFilter(p => !p.IsDeleted);

            var infrastructureAssembly = typeof(IAssemblyMarker).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(infrastructureAssembly);
        }
    }
}
