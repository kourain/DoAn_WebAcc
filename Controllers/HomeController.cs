using DoAn_WebAcc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoAn_WebAcc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _dataContext = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("/AccHI-{slug}-{id:int}.html", Name = "AccHI")]
        public IActionResult AccHI_view(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var acc = _dataContext.AccHIs.FirstOrDefault(m => (m.UID == id));
            if (acc == null)
            {
                return NotFound();
            }
            return View(acc);
        }
        [Route("/AccGI-{slug}-{id:int}.html", Name = "AccGI")]
        public IActionResult AccGI_view(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var acc = _dataContext.AccGIs.FirstOrDefault(m => (m.UID == id));
            if (acc == null)
            {
                return NotFound();
            }
            return View(acc);
        }
        [Route("/AccHSR-{slug}-{id:int}.html", Name = "AccHSR")]
        public IActionResult AccHSR_view(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var acc = _dataContext.AccHSRs.FirstOrDefault(m => (m.UID == id));
            if (acc == null)
            {
                return NotFound();
            }
            return View(acc);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}