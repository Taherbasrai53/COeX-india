using COeX_India.Models;
using Microsoft.EntityFrameworkCore;

namespace COeX_India.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Mines> Mines { get; set; }
        public DbSet<RailwayStations> RailwayStations { get; set; }

        public DbSet<Requests> Requests { get; set; }
    }
}
