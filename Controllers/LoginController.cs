using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using Microsoft.AspNetCore.Mvc.Routing;

namespace DoAn_WebAcc.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _dataContext;
        private string? returnUrl = "";
        public LoginController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult Index([FromQuery] string returnUrl,string? username = null)
        {
            if(Functions.IsLogin()) 
                return Redirect("/Home");
            this.returnUrl = returnUrl;
            if (username != null)
            {
                Functions._Message = "";
                Models.User view = new User();
                view.Username = username;
                return View(view);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
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
    }
}
