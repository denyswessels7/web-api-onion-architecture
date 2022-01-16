using Microsoft.EntityFrameworkCore;
using OA.Data;

namespace OA.Persistance.Context
{
    public class OADbContext : DbContext
    {
        public OADbContext(DbContextOptions<OADbContext> options):base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
        }
    }
}
