using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoAn_WebAcc.Controllers
{
    public class AccHSRController : Controller
    {
        private readonly ILogger<AccHSRController> _logger;
        private readonly DataContext _dataContext;
        public static int _List_maxpage = 0;
        public static int _List_pagenow = 0;

        public AccHSRController(ILogger<AccHSRController> logger, DataContext context)
        {
            _logger = logger;
            _dataContext = context;
        }

        public IActionResult Index()
        {
            return Index(1);
        }
        [Route("/AccHSR/page={page:int}")]
        public IActionResult Index(int page = 1)
        {
            _List_pagenow = page;
            //reset max pagecount
            int count = _dataContext.AccHSRs.Where(p => p.Sold == null || p.Sold == 0).Count();
            _List_maxpage = count / 12;
            if ((_List_maxpage * 12) < count) { _List_maxpage++; }

            var acc = _dataContext.AccHSRs.Where(p => p.Sold == null || p.Sold == 0).Skip(12 * (page - 1)).Take(12).ToList();
            return View(acc);
        }
        [HttpGet]
        [Route("/AccHSR/Search")]
        public IActionResult Search([FromQuery] string? price, [FromQuery] string sort_price, [FromQuery] string? acc_server, [FromQuery] int? page)
        {
            if (price == null) { price = "0|999999999"; }
            int min_price;
            int max_price;
            try
            {
                min_price = int.Parse(price.Split('|')[0]);
                max_price = int.Parse(price.Split('|')[1]);
            }
            catch (Exception ex)
            {
                min_price = 0;
                max_price = 999999999;
            }
            var acc = _dataContext.AccHSRs.Where(p => (p.Sold == null || p.Sold == 0)
                    && p.Price > min_price
                    && p.Price < max_price);
            if (sort_price == "desc")
            {
                acc = acc.OrderByDescending(p => p.Price);
            }
            else if (sort_price == "asc")
            {
                acc = acc.OrderBy(p => p.Price);
            }
            if (acc_server != null)
            {
                acc = acc.Where(p => p.Server == acc_server);
            }
            _List_pagenow = page.GetValueOrDefault(1);
            //reset max pagecount
            int count = acc.Count();
            _List_maxpage = count / 12;
            if ((_List_maxpage * 12) < count) { _List_maxpage++; }
            return View(acc.Skip(12 * (_List_pagenow - 1)).Take(12).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(AccHSR acc)
        {
            var accbuy = _dataContext.AccHSRs.Where(m => m.UID == acc.UID && (m.Sold == null || m.Sold == 0)).FirstOrDefault();
            if (accbuy != null)
            {
                accbuy.SoldDate = DateTime.Now;
                accbuy.Sold = Functions._UserID;
                _dataContext.AccHSRs.Update(accbuy);
                _dataContext.SaveChanges();
                return RedirectToAction("HistoryBuy");
            }
            return RedirectToAction("AccHSR_Acc", acc.UID);
        }
        [Route("/AccHSR/HistoryBuy")]
        public IActionResult HistoryBuy()
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");

            }
            var acc = _dataContext.AccHSRs.Where(m => (m.Sold == Functions._UserID)).ToList();
            return View(acc);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("/AccHSR/Acc-{id:int}")]
        public IActionResult AccHSR_Acc(int? id)
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