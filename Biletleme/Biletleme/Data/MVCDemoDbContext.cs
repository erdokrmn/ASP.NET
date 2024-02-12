using Biletleme.Models;
using Microsoft.EntityFrameworkCore;

namespace Biletleme.Data
{
	public class MVCDemoDbContext : DbContext
	{
		public MVCDemoDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Musteri> Musteriler { get; set; }
       

    }
}
