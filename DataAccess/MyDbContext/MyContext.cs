using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.MyDbContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Route> Routes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ticket>()
                .HasOne(ticket => ticket.Route)
                .WithMany(route => route.Tickets)
                .HasForeignKey(ticket => ticket.RouteId);


            modelBuilder.Entity<Route>().HasData(
                new Route { RouteId = 1, DestinyName = "Lugar 1", ExitName = "Lugar 2", Price = 500},
                new Route { RouteId = 2, DestinyName = "Lugar 2", ExitName = "Lugar 1", Price = 500 },
                new Route { RouteId = 3, DestinyName = "Lugar 2", ExitName = "Lugar 3", Price = 1000 },
                new Route { RouteId = 4, DestinyName = "Lugar 3", ExitName = "Lugar 2", Price = 1000 },
                new Route { RouteId = 5, DestinyName = "Lugar 1", ExitName = "Lugar 3", Price = 1500 },
                new Route { RouteId = 6, DestinyName = "Lugar 3", ExitName = "Lugar 1", Price = 1500 });
        }
    }
}