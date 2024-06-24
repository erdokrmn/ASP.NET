namespace BitirmeProjesi.Models.ViewModel
{
	public class GemiSurecViewModel
	{
        public List<GemiEnvanteri> GemiEnvanterleri { get; set; }
        public List<Personel> Personeller { get; set; }
        public Dictionary<Guid, string> GemiAdlari { get; set; }  // Yeni eklenen

        public GemiSurecViewModel()
        {
            GemiEnvanterleri = new List<GemiEnvanteri>();
            Personeller = new List<Personel>();
            GemiAdlari = new Dictionary<Guid, string>();
        }
    }
}
