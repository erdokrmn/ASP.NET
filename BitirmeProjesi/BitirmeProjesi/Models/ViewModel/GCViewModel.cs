using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesi.Models.ViewModel
{
    public class GCViewModel
    {

        public Guid Id { get; set; }

        public Guid PersonelId { get; set; }
        public string AdSoyad { get; set; }

        public DateTime GS { get; set; }

        public DateTime CS { get; set; }

        public DateTime Tarih { get; set; }

       

    }
}
