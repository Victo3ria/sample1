using Microsoft.EntityFrameworkCore;

namespace sample1.Models
{
    public class RfqDbContext : DbContext
    {
        public RfqDbContext(DbContextOptions<RfqDbContext> options) : base(options)
        {
        }
        public DbSet<Rfq> Rfqs { get; set; }
    }
}
