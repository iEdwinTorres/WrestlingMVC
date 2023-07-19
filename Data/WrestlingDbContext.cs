using Microsoft.EntityFrameworkCore;

namespace WrestlingMVC.Data
{
	public class WrestlingDbContext : DbContext
	{
		public WrestlingDbContext(DbContextOptions<WrestlingDbContext> options) : base(options) { }

		public DbSet<Promotion> Promotions { get; set; }
		public DbSet<Championship> Championships { get; set; }
		public DbSet<Wrestler> Wrestlers { get; set; }
		public DbSet<Reign> Reigns { get; set; }
	}
}