using BitirmeProjesi.Models;
using Microsoft.EntityFrameworkCore;
using GC = BitirmeProjesi.Models.GC;


namespace BitirmeProjesi.DataContext
{
    public class BitirmeProjesiDbContext  : DbContext
    {

        public BitirmeProjesiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Gemi> Gemiler { get; set; }
        public DbSet<GemiEnvanteri> GemiEnvanterleri { get; set; }
		public DbSet<GemiSurec> GemiSurecleri { get; set; }
		public DbSet<Malzeme> Malzemeler { get; set; }
        public DbSet<Masraf> Masraflar { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Zimmet> Zimmetler { get; set; }
		public DbSet<Firma> Firmalar { get; set; }
		public DbSet<Gelir> Gelirler { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OzelGun> OzelGunler { get; set; }
        public DbSet<Maas> Maaslar { get; set; }

        public DbSet<GC> GCs { get; set; }

    }


}
