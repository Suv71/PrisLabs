using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        /// <summary/>
        public DatabaseContext CreateDbContext(string[] args)
        {
            var dbConnectionString = "Host=localhost;Username=postgres;Password=root;Database=Pris.Hotel";
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseNpgsql(dbConnectionString, o => o.MigrationsAssembly("DAL"));
            return new DatabaseContext(builder.Options);
        }
    }
}