using Microsoft.EntityFrameworkCore;
using Razor.Models;

namespace Razor.Data
{
    public class ApplicationDbContextcs: DbContext
    {
        public ApplicationDbContextcs(DbContextOptions<ApplicationDbContextcs> options)
                   : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
    }
}
