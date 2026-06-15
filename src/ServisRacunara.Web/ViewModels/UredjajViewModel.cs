namespace ServisRacunara.Web.ViewModels
{
    public class UredjajViewModel
    {
        public int Id { get; set; }

        public string Naziv { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public int KlijentId { get; set; }
    }
}