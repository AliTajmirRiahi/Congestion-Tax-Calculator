using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Arta.Persistence.EF.Contexts
{
    public class ArtaContextFactory : IDesignTimeDbContextFactory<ArtaDbContext>
    {
        public ArtaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ArtaDbContext>();
            //optionsBuilder.UseSqlServer("Server=localhost;Database=SepehrDb;uid=sa;pwd=qazQAZ123!@#;MultipleActiveResultSets=True;");

            return new ArtaDbContext(optionsBuilder.Options);
        }
    }
}