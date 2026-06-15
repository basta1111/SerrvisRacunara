using ServisRacunara.DAL.Kontekst;
using ServisRacunara.DAL.Entiteti;
using Microsoft.EntityFrameworkCore;

namespace ServisRacunara.BLL.Servisi
{
    public class KlijentServis
    {
        private readonly BazaKontekst _kontekst;

        public KlijentServis(BazaKontekst kontekst)
        {
            _kontekst = kontekst;
        }

        public List<Klijent> VratiSveKlijente()
        {
            return _kontekst.Klijenti.ToList();
        }

        public void DodajKlijenta(Klijent klijent)
        {
            _kontekst.Klijenti.Add(klijent);
            _kontekst.SaveChanges();
        }

        public void ObrisiKlijenta(int id)
        {
            var klijent = _kontekst.Klijenti.Find(id);

            if (klijent != null)
            {
                _kontekst.Klijenti.Remove(klijent);
                _kontekst.SaveChanges();
            }
        }

        public Klijent? VratiKlijentaPoId(int id)
        {
            return _kontekst.Klijenti.Find(id);
        }

        public void IzmeniKlijenta(Klijent klijent)
        {
            _kontekst.Klijenti.Update(klijent);
            _kontekst.SaveChanges();
        }
    }


}