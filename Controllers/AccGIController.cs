using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoAn_WebAcc.Controllers
{
    public class AccGIController : Controller
    {
        private readonly ILogger<AccGIController> _logger;
        private readonly DataContext _dataContext;
        public static int _List_maxpage = 0;
        public static int _List_pagenow = 0;

        public AccGIController(ILogger<AccGIController> logger, DataContext context)
        {
            _logger = logger;
            _dataContext = context;

        }

        public IActionResult Index()
        {
            return Index(1);
        }
        [Route("/AccGI/page={page:int}")]
        public IActionResult Index(int page = 1)
        {
            _List_pagenow = page;
            //reset max pagecount
            int count = _dataContext.AccGIs.Where(p => p.Sold == null || p.Sold == 0).Count();
            _List_maxpage = count / 12;
            if ((_List_maxpage * 12) < count) { _List_maxpage = _List_maxpage + 1; }

            var acc = _dataContext.AccGIs.Where(p => p.Sold != null || p.Sold == 0).Skip(12 * (page - 1)).Take(12).ToList();
            return View(acc);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("/AccGI/Acc-{id:int}")]
        public IActionResult AccGI_Acc(int? id)
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}