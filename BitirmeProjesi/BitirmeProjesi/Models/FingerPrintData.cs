using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesi.Models
{
    public class FingerPrintData
    {
        public Guid Id { get; set; }

        [ForeignKey("Personel")]
        public Guid PersonelId { get; set; }
        public int KullanıcıNo { get; set; }


        public string InOut { get; set; }
        public string Mode { get; set; }
        public DateTime IOZaman { get; set; }

        public virtual Personel Personel { get; set; }
    }
}
