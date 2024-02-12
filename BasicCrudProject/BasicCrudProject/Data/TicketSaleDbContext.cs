using Microsoft.EntityFrameworkCore;
using BasicCrudProject.Models;

namespace BasicCrudProject.Data
{
    public class TicketSaleDbContext : DbContext
    {
        public TicketSaleDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
