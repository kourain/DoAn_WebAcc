using Microsoft.AspNetCore.Mvc;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;
namespace DoAn_WebAcc.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DataContext _dataContext;
        public RegisterController(DataContext dataContext)
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
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Mail))
            {
                return NotFound();
            }

            if (user == null)
            {
                return NotFound();
            }
            var check = _dataContext.Users.Where(m => m.Mail == user.Mail).FirstOrDefault();
            if (check != null)
            {
                Functions._Message = "Duplicate Email";
                return RedirectToAction("Index", "Register");
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
            return RedirectToAction("Index", "Login");
        }
    }
}
