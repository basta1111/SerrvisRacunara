using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServisRacunara.BLL.Servisi;
using ServisRacunara.DAL.Kontekst;
using ServisRacunara.DAL.Entiteti;

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

            return View();
        }

        [HttpPost]
        public IActionResult Dodaj(ServisniNalog nalog)
        {
            nalog.DatumPrijema = DateTime.Now;

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

            return View(nalog);
        }

        [HttpPost]
        public IActionResult Izmeni(ServisniNalog nalog)
        {
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