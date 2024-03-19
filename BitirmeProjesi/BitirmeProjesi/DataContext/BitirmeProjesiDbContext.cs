using BitirmeProjesi.Models;
using BitirmeProjesiEkranlar.Models;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.DataContext
{
    public class BitirmeProjesiDbContext : DbContext
    {
        public BitirmeProjesiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Gemi> Gemiler { get; set; }
        public DbSet<GemiEnvanteri> GemiEnvanterleri { get; set; }
        public DbSet<GemiSureci> GemiSurecleri { get; set; }
        public DbSet<Malzeme> Malzemeler { get; set; }
        public DbSet<Masraf> Masraflar { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Tevzi> Tevziler { get; set; }
        public DbSet<Zimmet> Zimmetler { get; set; }

    }
   
   
}
