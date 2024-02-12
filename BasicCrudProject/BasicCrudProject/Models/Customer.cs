namespace BasicCrudProject.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}
