using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TicketSale.Models;

namespace TicketSale.Data
{
    public class TicketSaleDbContext :DbContext
    {
        public TicketSaleDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
