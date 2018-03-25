using Microsoft.EntityFrameworkCore;

//Database in memory
namespace WorldCup2018.Models
{
    public class WorldCup2018Context : DbContext
    {
        public WorldCup2018Context(DbContextOptions<WorldCup2018Context> options)
            : base(options)
        {
        }

        public DbSet<Match> Match { get; set; }
        public DbSet<Phase> Phase { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Stadium> Stadium { get; set; }
        public DbSet<Partnes> Partnes { get; set; }
    }
}