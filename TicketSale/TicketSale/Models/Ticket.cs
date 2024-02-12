namespace TicketSale.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string LocationA { get; set; }
        public string LocationB { get; set; }
        public string Time { get; set; }
        public string VehicleType { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
