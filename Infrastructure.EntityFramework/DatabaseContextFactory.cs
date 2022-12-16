using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EntityFramework
{
    public class DatabaseContextFactory:IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var connectionString = configuration["ConnectionString"];
            if (connectionString == null)
            {
                throw new Exception("Connection string is null");
            }
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            //dbContextOptionsBuilder.UseSqlServer(connectionString);
            dbContextOptionsBuilder.UseNpgsql(connectionString, opt => opt.MigrationsAssembly("Infrastructure.EntityFramework"));
            return new DataBaseContext(dbContextOptionsBuilder.Options);
        }
    }
}
