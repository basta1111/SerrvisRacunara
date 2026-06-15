using ServisRacunara.DAL.Kontekst;
using ServisRacunara.DAL.Entiteti;

namespace ServisRacunara.BLL.Servisi
{
    public class ServiserServis
    {
        private readonly BazaKontekst _kontekst;

        public ServiserServis(BazaKontekst kontekst)
        {
            _kontekst = kontekst;
        }

        public List<Serviser> VratiSveServisere()
        {
            return _kontekst.Serviseri.ToList();
        }

        public void DodajServisera(Serviser serviser)
        {
            _kontekst.Serviseri.Add(serviser);
            _kontekst.SaveChanges();
        }

        public Serviser? VratiServiseraPoId(int id)
        {
            return _kontekst.Serviseri.Find(id);
        }

        public void IzmeniServisera(Serviser serviser)
        {
            _kontekst.Serviseri.Update(serviser);
            _kontekst.SaveChanges();
        }

        public void ObrisiServisera(int id)
        {
            var serviser = _kontekst.Serviseri.Find(id);

            if (serviser != null)
            {
                _kontekst.Serviseri.Remove(serviser);
                _kontekst.SaveChanges();
            }
        }
    }
}