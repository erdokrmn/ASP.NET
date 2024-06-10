namespace BitirmeProjesi.Models
{
    public class Gelir
    {
        public Guid Id { get; set; }

        public string FaturaKesilenAd { get; set; }

        public int Miktar { get; set; }
        public int Kesinti { get; set; }

        public DateTime FaturaTarihi { get; set; }

        public DateTime? ÖdenmeTarihi { get; set; }
    }
}
