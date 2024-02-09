using Microsoft.EntityFrameworkCore;

namespace VSComMariaDB.Model
{
    public class _DbContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            IConfigurationRoot Configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
            .Build();

            OptionsBuilder.EnableSensitiveDataLogging();
            OptionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            var ConnectionString = Configuration.GetConnectionString("MariaDB");
            OptionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        }
    }
}
