using Microsoft.EntityFrameworkCore;
using ServisRacunara.DAL.Entiteti;

namespace ServisRacunara.DAL.Kontekst
{
    public class BazaKontekst : DbContext
    {
        public BazaKontekst(DbContextOptions<BazaKontekst> options)
            : base(options)
        {
        }

        public DbSet<Klijent> Klijenti { get; set; }

        public DbSet<Uredjaj> Uredjaji { get; set; }

        public DbSet<Serviser> Serviseri { get; set; }

        public DbSet<ServisniNalog> ServisniNalozi { get; set; }
    }
}