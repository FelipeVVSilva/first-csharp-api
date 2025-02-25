using Microsoft.EntityFrameworkCore;
using NZWalks.API.Domain.Models;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {

        public NZWalksDbContext(DbContextOptions options) : base(options)
        {
            
        }

        DbSet<Difficulty> Difficulties { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<Walk> Walks { get; set; }

    }
}
