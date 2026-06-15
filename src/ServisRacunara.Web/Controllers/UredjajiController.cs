using Microsoft.AspNetCore.Mvc;
using ServisRacunara.BLL.Servisi;
using ServisRacunara.DAL.Entiteti;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServisRacunara.DAL.Kontekst;

namespace ServisRacunara.Web.Controllers
{
    public class UredjajiController : Controller
    {
        private readonly UredjajServis _uredjajServis;

        private readonly BazaKontekst _kontekst;

        public UredjajiController(
            UredjajServis uredjajServis,
            BazaKontekst kontekst)
        {
            _uredjajServis = uredjajServis;
            _kontekst = kontekst;
        }

        public IActionResult Index()
        {
            var uredjaji = _uredjajServis.VratiSveUredjaje();

            return View(uredjaji);
        }

        public IActionResult Dodaj()
        {
            ViewBag.Klijenti = new SelectList(
                _kontekst.Klijenti,
                "Id",
                "Ime");

            return View();
        }

        [HttpPost]
        public IActionResult Dodaj(Uredjaj uredjaj)
        {
            _uredjajServis.DodajUredjaj(uredjaj);

            return RedirectToAction("Index");
        }

        public IActionResult Izmeni(int id)
        {
            var uredjaj = _uredjajServis.VratiUredjajPoId(id);

            if (uredjaj == null)
                return NotFound();

            return View(uredjaj);
        }

        [HttpPost]
        public IActionResult Izmeni(Uredjaj uredjaj)
        {
            _uredjajServis.IzmeniUredjaj(uredjaj);

            return RedirectToAction("Index");
        }

        public IActionResult Obrisi(int id)
        {
            _uredjajServis.ObrisiUredjaj(id);

            return RedirectToAction("Index");
        }
    }
}