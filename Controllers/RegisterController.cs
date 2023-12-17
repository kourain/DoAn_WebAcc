using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;
namespace DoAn_WebAcc.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DataContext _dataContext;
        private string? returnUrl = "";
        public RegisterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (Functions.IsLogin())
                return Redirect("/Home");
            Functions._Message = "";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User user)
        {
            this.returnUrl = Request.Form["returnUrl"];
            if (user == null)
            {
                return NotFound();
            }
            var check = _dataContext.Users.Where(m => m.Mail == user.Mail).FirstOrDefault();
            if (check != null)
            {
                Functions._Message = "Email này đã được sử dụng";
                ViewBag.returnUrl = returnUrl;
                return View();
            }
            check = _dataContext.Users.Where(m => m.Phone == user.Phone).FirstOrDefault();
            if (check != null)
            {
                Functions._Message = "Số điện thoại này đã được sử dụng";
                ViewBag.returnUrl = returnUrl;
                return View();
            }
            user.Username = user.Username.ToLower();
            user.Mail = user.Mail.ToLower();
            Functions._Message = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            int usid = 0;
            try
            {
                usid = (from p in _dataContext.Users
                        orderby p.Id descending
                        select p.Id).Take(1).ToList()[0];
            }
            catch { usid = 0; };
            user.Id = usid + 1;
            _dataContext.Add(user);
            _dataContext.SaveChanges(); 
            if (string.IsNullOrEmpty(this.returnUrl))
            {
                this.returnUrl = "/Home";
            }
            return RedirectToAction("Index", "Login", new { returnUrl, user.Username });
        }
    }
}
