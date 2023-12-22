using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAn_WebAcc.Areas.Admin.Models;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Areas.Admin.Utilities;
namespace DoAn_WebAcc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticatorController : Controller
    {
        private readonly DataContext _dataContext;
        public AuthenticatorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [Route("/Admin/Logout")]
        public IActionResult Logout()
        {
            Functions._AdminUserID = 0;
            Functions._AdminUserName = string.Empty;
            Functions._Email = string.Empty;
            Functions._Message = string.Empty;
            return RedirectToAction("Index", "Home");
        }
        [Route("/Admin/Login")]
        public IActionResult Login()
        {
            if (Functions.IsLogin())
                return Redirect("/Admin");
            Functions._Message = "";
            return View();
        }
        [Route("/Admin/UserProfile")]
        public IActionResult UserProfile()
        {
            Functions._Message = "";
            return View();
        }
        [Route("/Admin/Login")]
        [HttpPost]
        public IActionResult Login(AdminUser user)
        {

            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return NotFound();
            }

            string pw = Functions.MD5Password(user.Password);
            var check = _dataContext.AdminUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Invalid UserName or Password";
                return View();
            }

            Functions._Message = string.Empty;
            Functions._AdminUserID = check.AdminUserID;
            Functions._AdminUserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;

            return RedirectToAction("Index" , "Home");

        }
        [Route("/Admin/Register")]
        public IActionResult Register()
        {
            if (Functions.IsLogin())
                return Redirect("/Admin");
            Functions._Message = "";
            return View();
        }
        [Route("/Admin/Register")]
        [HttpPost]
        public IActionResult Register(AdminUser user)
        {

            if (user == null)
            {
                return NotFound();
            }
            var check = _dataContext.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                Functions._Message = "Duplicate Email";
                return View();
            }

            Functions._Message = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _dataContext.Add(user);
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
        [Route("/Admin/AdminChangePass")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminChangePass(ChangePass cp)
        {
            var check = _dataContext.AdminUsers.Where(m => (m.AdminUserID == Functions._AdminUserID) && (m.Password == Functions.MD5Password(cp.oldPass))).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Mật khẩu cũ không chính xác";
                return View();
            }
            else
            {
                check.Password = Functions.MD5Password(cp.newPass);
                _dataContext.Update(check);
                _dataContext.SaveChanges();
            }
            Functions._Message = "Thành Công!!!";
            return View();
        }
    }
}
