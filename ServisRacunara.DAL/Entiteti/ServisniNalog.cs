using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisRacunara.DAL.Entiteti
{
    public class ServisniNalog
    {
        public int Id { get; set; }

        public string OpisKvara { get; set; }

        public DateTime DatumPrijema { get; set; }

        public string Status { get; set; }

        public decimal Cena { get; set; }

        public int UredjajId { get; set; }

        public Uredjaj Uredjaj { get; set; }

        public int ServiserId { get; set; }

        public Serviser Serviser { get; set; }
    }
}
