using Microsoft.AspNetCore.Mvc;
using ServisRacunara.BLL.Servisi;
using ServisRacunara.DAL.Entiteti;
using ServisRacunara.Web.ViewModels;

namespace ServisRacunara.Web.Controllers
{
    public class ServiseriController : Controller
    {
        private readonly ServiserServis _serviserServis;

        public ServiseriController(ServiserServis serviserServis)
        {
            _serviserServis = serviserServis;
        }

        public IActionResult Index()
        {
            var serviseri = _serviserServis.VratiSveServisere();

            return View(serviseri);
        }

        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Dodaj(ServiserViewModel model)
        {
            var serviser = new Serviser
            {
                Ime = model.Ime,
                Prezime = model.Prezime,
                Specijalizacija = model.Specijalizacija
            };

            _serviserServis.DodajServisera(serviser);

            return RedirectToAction("Index");
        }

        public IActionResult Izmeni(int id)
        {
            var serviser = _serviserServis.VratiServiseraPoId(id);

            if (serviser == null)
                return NotFound();

            var model = new ServiserViewModel
            {
                Id = serviser.Id,
                Ime = serviser.Ime,
                Prezime = serviser.Prezime,
                Specijalizacija = serviser.Specijalizacija
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Izmeni(ServiserViewModel model)
        {
            var serviser = new Serviser
            {
                Id = model.Id,
                Ime = model.Ime,
                Prezime = model.Prezime,
                Specijalizacija = model.Specijalizacija
            };

            _serviserServis.IzmeniServisera(serviser);

            return RedirectToAction("Index");
        }

        public IActionResult Obrisi(int id)
        {
            _serviserServis.ObrisiServisera(id);

            return RedirectToAction("Index");
        }
    }
}