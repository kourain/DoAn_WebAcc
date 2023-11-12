using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;
namespace DoAn_WebAcc.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _dataContext;
        public LoginController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
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
                return RedirectToAction("Index", "Login");
            }

            Functions._Message = string.Empty;
            Functions._UserID = check.Id;
            Functions._UserName = string.IsNullOrEmpty(check.Username) ? string.Empty : check.Username;
            Functions._Name = string.IsNullOrEmpty(check.Name) ? string.Empty : check.Name;
            return RedirectToAction("Index", "Home");

        }
    }
}
