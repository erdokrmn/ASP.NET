namespace TicketSale.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Ticket Ticket { get; set; }
    }
}
