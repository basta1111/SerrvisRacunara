using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServisRacunara.DAL.Kontekst;
using ServisRacunara.Web.Models;

namespace ServisRacunara.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BazaKontekst _kontekst;

        public HomeController(
            ILogger<HomeController> logger,
            BazaKontekst kontekst)
        {
            _logger = logger;
            _kontekst = kontekst;
        }

        public IActionResult Index()
        {
            DashboardModel model = new DashboardModel
            {
                BrojKlijenata = _kontekst.Klijenti.Count(),
                BrojUredjaja = _kontekst.Uredjaji.Count(),
                BrojServisera = _kontekst.Serviseri.Count(),
                BrojNaloga = _kontekst.ServisniNalozi.Count()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}