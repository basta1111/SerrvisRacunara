using Microsoft.AspNetCore.Mvc;
using ServisRacunara.BLL.Servisi;

namespace ServisRacunara.Web.Controllers
{
    public class KlijentiController : Controller
    {
        private readonly KlijentServis _klijentServis;

        public KlijentiController(KlijentServis klijentServis)
        {
            _klijentServis = klijentServis;
        }

        public IActionResult Index()
        {
            var klijenti = _klijentServis.VratiSveKlijente();

            return View(klijenti);
        }

        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Dodaj(ServisRacunara.DAL.Entiteti.Klijent klijent)
        {
            _klijentServis.DodajKlijenta(klijent);

            return RedirectToAction("Index");
        }

        public IActionResult Obrisi(int id)
        {
            _klijentServis.ObrisiKlijenta(id);

            return RedirectToAction("Index");
        }

        public IActionResult Izmeni(int id)
        {
            var klijent = _klijentServis.VratiKlijentaPoId(id);

            if (klijent == null)
                return NotFound();

            return View(klijent);
        }

        [HttpPost]
        public IActionResult Izmeni(ServisRacunara.DAL.Entiteti.Klijent klijent)
        {
            _klijentServis.IzmeniKlijenta(klijent);

            return RedirectToAction("Index");
        }
    }
}