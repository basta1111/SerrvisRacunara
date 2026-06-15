namespace ServisRacunara.Web.ViewModels
{
    public class ServisniNalogViewModel
    {
        public int Id { get; set; }

        public string OpisKvara { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public decimal Cena { get; set; }

        public int UredjajId { get; set; }

        public int ServiserId { get; set; }
    }
}