using Microsoft.EntityFrameworkCore;

namespace ReactAspCoreCrud1.Models
{
	public class DonationDBContext : DbContext
	{
		public DonationDBContext(DbContextOptions<DonationDBContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder){
			builder.Entity<DCandidate>(
					e => {
					e.HasIndex(e => e.fullName);

					}
					);
		}
		public DbSet<DCandidate> DCandidates { get; set; }
	}
}
