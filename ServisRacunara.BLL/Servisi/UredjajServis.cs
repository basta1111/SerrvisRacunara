using Microsoft.EntityFrameworkCore;
using ServisRacunara.DAL.Kontekst;
using ServisRacunara.DAL.Entiteti;

namespace ServisRacunara.BLL.Servisi
{
    public class UredjajServis
    {
        private readonly BazaKontekst _kontekst;

        public UredjajServis(BazaKontekst kontekst)
        {
            _kontekst = kontekst;
        }

        public List<Uredjaj> VratiSveUredjaje()
        {
            return _kontekst.Uredjaji
                .Include(x => x.Klijent)
                .ToList();
        }

        public void DodajUredjaj(Uredjaj uredjaj)
        {
            _kontekst.Uredjaji.Add(uredjaj);
            _kontekst.SaveChanges();
        }

        public Uredjaj? VratiUredjajPoId(int id)
        {
            return _kontekst.Uredjaji.Find(id);
        }

        public void IzmeniUredjaj(Uredjaj uredjaj)
        {
            _kontekst.Uredjaji.Update(uredjaj);
            _kontekst.SaveChanges();
        }

        public void ObrisiUredjaj(int id)
        {
            var uredjaj = _kontekst.Uredjaji.Find(id);

            if (uredjaj != null)
            {
                _kontekst.Uredjaji.Remove(uredjaj);
                _kontekst.SaveChanges();
            }
        }

        public List<Klijent> VratiSveKlijente()
        {
            return _kontekst.Klijenti.ToList();
        }
    }
}