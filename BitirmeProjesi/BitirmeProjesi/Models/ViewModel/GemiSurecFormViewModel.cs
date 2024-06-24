namespace BitirmeProjesi.Models.ViewModel
{
    public class GemiSurecFormViewModel
    {
        public Guid GemiEnvanteriId { get; set; }
        public List<Guid> PersonelIds { get; set; }
        public string Durum { get; set; }
        public DateTime Tarih { get; set; }
    }
}
