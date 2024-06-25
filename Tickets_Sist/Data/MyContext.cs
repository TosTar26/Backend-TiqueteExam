using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
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
                 .HasOne(ticket => ticket.Routes)
                 .WithMany(route => route.Tickets)
                 .HasForeignKey(ticket => ticket.RouteId);

            modelBuilder.Entity<Route>().HasData(
                new Route { RouteId = 1, Price = 500, DestinyPlace = "Lugar 1", ExitPlace = "Lugar 2" },
                new Route { RouteId = 2, Price = 500, DestinyPlace = "Lugar 2", ExitPlace = "Lugar 1" },
                new Route { RouteId = 3, Price = 1000, DestinyPlace = "Lugar 2", ExitPlace = "Lugar 3" },
                new Route { RouteId = 4, Price = 1000, DestinyPlace = "Lugar 3", ExitPlace = "Lugar 2" },
                new Route { RouteId = 5, Price = 1500, DestinyPlace = "Lugar 1", ExitPlace = "Lugar 3" },
                new Route { RouteId = 6, Price = 1500, DestinyPlace = "Lugar 3", ExitPlace = "Lugar 1" }
                );
        }

        }
}