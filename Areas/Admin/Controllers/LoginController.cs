using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAn_WebAcc.Areas.Admin.Models;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;
namespace DoAn_WebAcc.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult Index(AdminUser user)
        {
           if (user == null)
            {
                return NotFound();
            }
            
           string pw = Functions.MD5Password(user.Password);
            var check = _dataContext.AdminUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Functions._MessageEmail = "Invalid UserName or Password";
                return RedirectToAction("Index", "Login");
            }

            Functions._Message = string.Empty;
            Functions._UserID = check.UserID;
            Functions._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;

            return RedirectToAction("Index" , "Home");

        }
    }
}
