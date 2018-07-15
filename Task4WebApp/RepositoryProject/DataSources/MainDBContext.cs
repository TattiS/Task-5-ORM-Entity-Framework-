using DALProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DALProject
{
	public class MainDBContext:DbContext
    {
		public MainDBContext()
		{
			Database.EnsureCreated();
		}

		public DbSet<Flight> Flights { get; set; }
		public DbSet<Departure> Departures { get; set; }
		public DbSet<Stewardess> Stewardesses { get; set; }
		public DbSet<Pilot> Pilots { get; set; }
		public DbSet<PlaneType> PlaneTypes { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyTestDatabase;Trusted_Connection=True;Integrated Security=True;", b => b.MigrationsAssembly("Task4WebApp"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Flight>()
				.HasMany<Ticket>(f => f.Tickets)
				.WithOne()
				.HasForeignKey(t => t.FlightId)
				.OnDelete(DeleteBehavior.Cascade);
		}


	}
}
