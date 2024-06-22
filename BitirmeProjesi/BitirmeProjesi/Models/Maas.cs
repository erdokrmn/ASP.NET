using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesi.Models
{
    public class Maas
    {
        public Guid Id { get; set; }

        [ForeignKey("Personel")]
        public Guid PersonelId { get; set; }
        public int MaasTutarı { get; set; }
        public int NormalMaas { get; set; }
        public int MesaiMaasi { get; set; }
        public int DegerMaasi { get; set; }
        public int OzelGunMaasi { get; set; }

        public DateTime MaasTarihi { get; set; }

        public Personel Personel { get; set; }
    }
}
