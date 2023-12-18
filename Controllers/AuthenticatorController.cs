using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using Microsoft.AspNetCore.Mvc.Routing;

namespace DoAn_WebAcc.Controllers
{
    public class AuthenticatorController : Controller
    {
        private readonly DataContext _dataContext;
        private string? returnUrl = "";
        public AuthenticatorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [Route("/Logout")]
        public ActionResult Logout()
        {
            Functions._UserID = 0;
            Functions._Name = string.Empty;
            Functions._Message = string.Empty;
            return RedirectToAction("Index", "Home");
        }
        [Route("/Login")]
        [HttpGet]
        public IActionResult Login([FromQuery] string returnUrl,string? username = null)
        {
            if(Functions.IsLogin()) 
                return Redirect("/Home");
            this.returnUrl = returnUrl;
            if (username != null)
            {
                Functions._Message = "Vui lòng điền lại thông tin";
                Models.User view = new User();
                view.Username = username;
                return View(view);
            }
            return View();
        }
        [Route("/Login")]
        [HttpPost]
        public ActionResult Login(User user)
        {
            this.returnUrl = Request.Form["returnUrl"];
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return NotFound();
            }
            string pw = Functions.MD5Password(user.Password);
            user.Username = user.Username.ToLower();
            var check = _dataContext.Users.Where(m => (m.Username == user.Username) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Tên đăng nhập hoặc mật khẩu không chính xác";
                return RedirectToAction("Index","Login",new { returnUrl, user.Username});
            }
            Functions._Message = string.Empty;
            Functions._UserID = check.Id;
            Functions._UserName = string.IsNullOrEmpty(check.Username) ? string.Empty : check.Username;
            Functions._Name = string.IsNullOrEmpty(check.Name) ? string.Empty : check.Name;
            if (string.IsNullOrEmpty(this.returnUrl))
            {
                this.returnUrl = "/Home";
            }
            return Redirect(this.returnUrl);
        }
        [Route("/Register")]
        [HttpGet]
        public IActionResult Register()
        {
            if (Functions.IsLogin())
                return Redirect("/Home");
            Functions._Message = "";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
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
            //int usid = 0;
            //try
            //{
            //    usid = (from p in _dataContext.Users
            //            orderby p.Id descending
            //            select p.Id).Take(1).ToList()[0];
            //}
            //catch { usid = 0; };
            //user.Id = usid + 1;
            _dataContext.Add(user);
            _dataContext.SaveChanges();
            if (string.IsNullOrEmpty(this.returnUrl))
            {
                this.returnUrl = "/Home";
            }
            return RedirectToAction("Index", "Login", new { returnUrl, user.Username });
        }
        [Route("/ForgotPass")]
        [HttpGet]
        public IActionResult ForgotPass()
        {
            if (Functions.IsLogin())
                return Redirect("/Home");
            return View();
        }
        [Route("/ForgotPass")]
        [HttpPost]
        public ActionResult ForgotPass(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Mail))
            {
                return NotFound();
            }
            var check = _dataContext.Users.Where(m => (m.Username == user.Username) && (m.Mail == user.Mail)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Tên đăng nhập hoặc mật khẩu không chính xác";
                return View();
            }
            else
            {
                //reset pass
            }
            Functions._Message = "Thành Công!!!";
            return View();
        }
    }
}
