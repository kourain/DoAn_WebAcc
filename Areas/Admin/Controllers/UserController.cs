using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;

namespace DoAn_WebAcc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly DataContext _Context;
        public UserController(DataContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {

            var mnlist = _Context.Users.OrderBy(m => m.UserId).ToList();
            return View(mnlist);
        }
        public IActionResult Ban(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _Context.Users.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ban(int id)
        {
            var deleUser = _Context.Users.Find(id);
            if (deleUser == null)
            {
                return NotFound();
            }
            deleUser.Ban = !deleUser.Ban;
            _Context.Users.Update(deleUser);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ResetPassWord(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _Context.Users.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassWord(User mn)
        {
            var resetUser = _Context.Users.Find(mn.UserId);
            if (resetUser == null)
            {
                return NotFound();
            }
            resetUser.Password = Functions.MD5Password("12345678");
            _Context.Users.Update(resetUser);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
