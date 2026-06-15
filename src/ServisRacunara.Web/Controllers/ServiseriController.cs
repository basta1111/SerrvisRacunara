using Microsoft.AspNetCore.Mvc;
using ServisRacunara.BLL.Servisi;
using ServisRacunara.DAL.Entiteti;

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
        public IActionResult Dodaj(Serviser serviser)
        {
            _serviserServis.DodajServisera(serviser);

            return RedirectToAction("Index");
        }

        public IActionResult Izmeni(int id)
        {
            var serviser = _serviserServis.VratiServiseraPoId(id);

            if (serviser == null)
                return NotFound();

            return View(serviser);
        }

        [HttpPost]
        public IActionResult Izmeni(Serviser serviser)
        {
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