using Microsoft.EntityFrameworkCore;

namespace ReactAspCoreCrud1.Models
{
    public class DonationDBContext : DbContext
    {
        public DonationDBContext(DbContextOptions<DonationDBContext> options) : base(options)
        {
            
        }
        public DbSet<DCandidate> DCandidates { get; set; }
    }
}