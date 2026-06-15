using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServisRacunara.BLL.Servisi;
using ServisRacunara.DAL.Kontekst;
using ServisRacunara.DAL.Entiteti;
using ServisRacunara.Web.ViewModels;

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

            return View(new UredjajViewModel());
        }

        [HttpPost]
        public IActionResult Dodaj([FromForm] UredjajViewModel NoviModel)
        {
            var uredjaj = new Uredjaj
            {
                Naziv = NoviModel.Naziv,
                Model = NoviModel.Model,
                KlijentId = NoviModel.KlijentId
            };

            _uredjajServis.DodajUredjaj(uredjaj);

            return RedirectToAction("Index");
        }

        public IActionResult Izmeni(int id)
        {
            var uredjaj = _uredjajServis.VratiUredjajPoId(id);

            if (uredjaj == null)
                return NotFound();

            ViewBag.Klijenti = new SelectList(
                _kontekst.Klijenti,
                "Id",
                "Ime");

            var model = new UredjajViewModel
            {
                Id = uredjaj.Id,
                Naziv = uredjaj.Naziv,
                Model = uredjaj.Model,
                KlijentId = uredjaj.KlijentId
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Izmeni(UredjajViewModel IzmenjenModel)
        {
            var uredjaj = new Uredjaj
            {
                Id = IzmenjenModel.Id,
                Naziv = IzmenjenModel.Naziv,
                Model = IzmenjenModel.Model,
                KlijentId = IzmenjenModel.KlijentId
            };

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