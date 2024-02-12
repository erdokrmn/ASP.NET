namespace BasicCrudProject.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public string LocationA { get; set; }
        public string LocationB { get; set; }
        public TimeOnly Time { get; set; }
        public DateOnly Date { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
