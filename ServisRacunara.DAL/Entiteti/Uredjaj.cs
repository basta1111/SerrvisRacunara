using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisRacunara.DAL.Entiteti
{
    public class Uredjaj
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Model { get; set; }

        public int KlijentId { get; set; }

        public Klijent Klijent { get; set; }
    }
}
