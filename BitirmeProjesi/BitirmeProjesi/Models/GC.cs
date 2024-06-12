using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesi.Models
{
    public class GC
    {
        public Guid Id { get; set; }


        [ForeignKey("Personel")]
        public Guid PersonelId { get; set; }
        public string AdSoyad { get; set; }

        public DateTime GS { get; set; }

        public DateTime CS { get; set; }

        public DateTime Tarih { get; set; }

        public Personel PersonelAd { get; set; }




    }
}
