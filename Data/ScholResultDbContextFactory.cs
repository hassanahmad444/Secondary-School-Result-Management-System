using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Secondary_School_Result_Management_System.Data
{
    public class ScholResultDbContextFactory 
    {
        public class AppDbContextFactory : IDesignTimeDbContextFactory<SchoolResultDbContext>
        {
            public SchoolResultDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SchoolResultDbContext>();

                optionsBuilder.UseSqlServer(
                    "data source=(localdb)\\mssqllocaldb;initial catalog=SchoolResultDb;integrated security=true;encrypt=false;trustservercertificate=true"
                );

                return new SchoolResultDbContext(optionsBuilder.Options);
            }
        }

    }
}
