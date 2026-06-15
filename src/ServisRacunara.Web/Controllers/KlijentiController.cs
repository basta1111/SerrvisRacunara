using Microsoft.AspNetCore.Mvc;
using ServisRacunara.BLL.Servisi;
using ServisRacunara.DAL.Entiteti;
using ServisRacunara.Web.ViewModels;

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
        public IActionResult Dodaj(KlijentViewModel model)
        {
            var klijent = new Klijent
            {
                Ime = model.Ime,
                Prezime = model.Prezime,
                Telefon = model.Telefon,
                Email = model.Email
            };

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

            var model = new KlijentViewModel
            {
                Id = klijent.Id,
                Ime = klijent.Ime,
                Prezime = klijent.Prezime,
                Telefon = klijent.Telefon,
                Email = klijent.Email
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Izmeni(KlijentViewModel model)
        {
            var klijent = new Klijent
            {
                Id = model.Id,
                Ime = model.Ime,
                Prezime = model.Prezime,
                Telefon = model.Telefon,
                Email = model.Email
            };

            _klijentServis.IzmeniKlijenta(klijent);

            return RedirectToAction("Index");
        }
    }
}