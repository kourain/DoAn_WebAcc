using DoAn_WebAcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DoAn_WebAcc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _datacontext;
        public HomeController(ILogger<HomeController> logger, DataContext datacontext)
        {
            _logger = logger;
            _datacontext = datacontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public int? getmaxuserid()
        {

            int? uid = (from p in _datacontext.AccHIs
                           where (p.Sold != null)
                           orderby p.UID descending
                           select p.UID).Take(1).ToList()[0];
            if(uid == null) uid = 1;
            return uid;
        }

    }
}