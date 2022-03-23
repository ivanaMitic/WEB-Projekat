using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class PlesniKluboviContext : DbContext
    {
        public DbSet<PlesniKlub> PlesniKlubovi { get; set; }
        public DbSet<ClanKluba> ClanoviKluba { get; set; }
        public DbSet<Ples> Plesovi { get; set; }
        public DbSet<Clanarina> Clanarine { get; set; }
        public DbSet<Placanje> ClanoviPlesovi { get; set; }

        public PlesniKluboviContext(DbContextOptions options) : base(options)
        {}
    }
}