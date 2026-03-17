using Bowling_Tournament_Registration_System.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bowling_Tournament_Registration_System.Persistence
{
	public class BowlingDbContext : DbContext
	{
		public BowlingDbContext(DbContextOptions<BowlingDbContext> options)
			: base(options)
		{
		}

		public DbSet<Tournament> Tournaments => Set<Tournament>();
		public DbSet<Team> Teams => Set<Team>();
		public DbSet<Player> Players => Set<Player>();
		public DbSet<TournamentRegistration> TournamentRegistrations => Set<TournamentRegistration>();	
		public DbSet<User> Users => Set<User>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Tournament>().ToTable("Tournament");
			modelBuilder.Entity<Team>().ToTable("Team");
			modelBuilder.Entity<Player>().ToTable("Player");
			modelBuilder.Entity<TournamentRegistration>()
			.ToTable("TournamentRegistration")
			.Property(tr => tr.Status)
			.HasConversion<string>();
			modelBuilder.Entity<User>().ToTable("User");
		}
	}
}