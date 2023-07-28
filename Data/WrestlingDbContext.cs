using Microsoft.EntityFrameworkCore;

namespace WrestlingMVC.Data
{
	public class WrestlingDbContext : DbContext
	{
		public WrestlingDbContext(DbContextOptions<WrestlingDbContext> options) : base(options) { }

		public DbSet<Promotion> Promotions { get; set; } = null!;
		public DbSet<Championship> Championships { get; set; } = null!;
		public DbSet<Wrestler> Wrestlers { get; set; } = null!;
		public DbSet<Reign> Reigns { get; set; } = null!;
	}
}
