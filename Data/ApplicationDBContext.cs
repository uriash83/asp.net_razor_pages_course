using Abby.Model;
using Microsoft.EntityFrameworkCore;

namespace Abby.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            :base(options)
        {

        }
        public DbSet<Category> Category { get; set; } // taka bedzie nazwa tabeli
    }
}
