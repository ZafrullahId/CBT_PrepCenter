using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CBTPreparation.Infrastructure.Persistence.Context;
public class CBTDbContextFactory : IDesignTimeDbContextFactory<CBTDbContext>
{
    public CBTDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<CBTDbContext>();
        optionBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=cbtpreparationdb;TrustServerCertificate=True;Trusted_Connection=True;");

        return new CBTDbContext(optionBuilder.Options);
    }
}
