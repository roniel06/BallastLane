using BallastLane.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace BallastLane.Test.Helpers
{
    public static class DatabaseHelper
    {
        public static ProjectDbContext CreateDbContex()
        {
            var options = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseSqlite("DataSource=:memory;").Options;

            var dbContext = new ProjectDbContext(options);
            dbContext.Database.OpenConnection();
            dbContext.Database.Migrate();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }


    }
}
