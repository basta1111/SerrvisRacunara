using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServisRacunara.BLL.Servisi;
using ServisRacunara.DAL.Kontekst;
using ServisRacunara.DAL.Entiteti;
using ServisRacunara.Web.ViewModels;

namespace ServisRacunara.Web.Controllers
{
    public class ServisniNaloziController : Controller
    {
        private readonly ServisniNalogServis _nalogServis;
        private readonly BazaKontekst _kontekst;

        public ServisniNaloziController(
            ServisniNalogServis nalogServis,
            BazaKontekst kontekst)
        {
            _nalogServis = nalogServis;
            _kontekst = kontekst;
        }

        public IActionResult Index()
        {
            var nalozi = _nalogServis.VratiSveNaloge();

            return View(nalozi);
        }

        public IActionResult Dodaj()
        {
            ViewBag.Uredjaji = new SelectList(
                _kontekst.Uredjaji,
                "Id",
                "Model");

            ViewBag.Serviseri = new SelectList(
                _kontekst.Serviseri,
                "Id",
                "Ime");

            return View(new ServisniNalogViewModel());
        }

        [HttpPost]
        public IActionResult Dodaj(ServisniNalogViewModel model)
        {
            var nalog = new ServisniNalog
            {
                OpisKvara = model.OpisKvara,
                Status = model.Status,
                Cena = model.Cena,
                UredjajId = model.UredjajId,
                ServiserId = model.ServiserId,
                DatumPrijema = DateTime.Now
            };

            _nalogServis.DodajNalog(nalog);

            return RedirectToAction("Index");
        }

        public IActionResult Izmeni(int id)
        {
            var nalog = _nalogServis.VratiPoId(id);

            if (nalog == null)
                return NotFound();

            ViewBag.Uredjaji = new SelectList(
                _kontekst.Uredjaji,
                "Id",
                "Model");

            ViewBag.Serviseri = new SelectList(
                _kontekst.Serviseri,
                "Id",
                "Ime");

            var model = new ServisniNalogViewModel
            {
                Id = nalog.Id,
                OpisKvara = nalog.OpisKvara,
                Status = nalog.Status,
                Cena = nalog.Cena,
                UredjajId = nalog.UredjajId,
                ServiserId = nalog.ServiserId
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Izmeni(ServisniNalogViewModel model)
        {
            var nalog = new ServisniNalog
            {
                Id = model.Id,
                OpisKvara = model.OpisKvara,
                Status = model.Status,
                Cena = model.Cena,
                UredjajId = model.UredjajId,
                ServiserId = model.ServiserId
            };

            _nalogServis.IzmeniNalog(nalog);

            return RedirectToAction("Index");
        }

        public IActionResult Obrisi(int id)
        {
            _nalogServis.ObrisiNalog(id);

            return RedirectToAction("Index");
        }
    }
}