using Microsoft.EntityFrameworkCore;
using ServisRacunara.DAL.Kontekst;
using ServisRacunara.DAL.Entiteti;

namespace ServisRacunara.BLL.Servisi
{
    public class ServisniNalogServis
    {
        private readonly BazaKontekst _kontekst;

        public ServisniNalogServis(BazaKontekst kontekst)
        {
            _kontekst = kontekst;
        }

        public List<ServisniNalog> VratiSveNaloge()
        {
            return _kontekst.ServisniNalozi
                .Include(x => x.Uredjaj)
                .Include(x => x.Serviser)
                .ToList();
        }

        public void DodajNalog(ServisniNalog nalog)
        {
            if (string.IsNullOrWhiteSpace(nalog.OpisKvara))
            {
                throw new Exception("Opis kvara je obavezan.");
            }

            if (nalog.Cena < 0)
            {
                throw new Exception("Cena ne može biti negativna.");
            }

            _kontekst.ServisniNalozi.Add(nalog);
            _kontekst.SaveChanges();
        }

        public ServisniNalog? VratiPoId(int id)
        {
            return _kontekst.ServisniNalozi.Find(id);
        }

        public void IzmeniNalog(ServisniNalog nalog)
        {
            if (string.IsNullOrWhiteSpace(nalog.OpisKvara))
            {
                throw new Exception("Opis kvara je obavezan.");
            }

            if (nalog.Cena < 0)
            {
                throw new Exception("Cena ne može biti negativna.");
            }

            _kontekst.ServisniNalozi.Update(nalog);
            _kontekst.SaveChanges();
        }

        public void ObrisiNalog(int id)
        {
            var nalog = _kontekst.ServisniNalozi.Find(id);

            if (nalog != null)
            {
                _kontekst.ServisniNalozi.Remove(nalog);
                _kontekst.SaveChanges();
            }
        }


    }
}