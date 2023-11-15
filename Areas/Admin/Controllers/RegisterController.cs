using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAn_WebAcc.Areas.Admin.Models;
using DoAn_WebAcc.Controllers;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Areas.Admin.Utilities;
namespace DoAn_WebAcc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DataContext _dataContext;
        public RegisterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            Functions._Message = "";
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminUser user)
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
                int usid = 0;
                try
                {
                   usid =  (from p in _dataContext.AdminUsers
                     orderby p.UserID descending
                     select p.UserID).Take(1).ToList()[0];
                }
                catch  { usid = 0; };
                user.UserID = usid + 1;
                _dataContext.Add(user);
                _dataContext.SaveChanges();
                return RedirectToAction("Index", "Login");

        
        }
    }
}
