using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Areas.Admin.Utilities;
namespace DoAn_WebAcc.Areas.Admin.Controllers
{
    [Area("Admin")] 
    
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
