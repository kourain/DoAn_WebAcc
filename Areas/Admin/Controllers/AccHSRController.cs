using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoAn_WebAcc.Models;
using DoAn_WebAcc.Utilities;

namespace DoAn_WebAcc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccHSRController : Controller
    {
        private readonly DataContext _Context;
        public AccHSRController(DataContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            var mnlist = _Context.AccHSRs.OrderBy(m => m.UID).ToList();
            return View(mnlist);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _Context.AccHSRs.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleAccHSR = _Context.AccHSRs.Find(id);
            if (deleAccHSR == null)
            {
                return NotFound();
            }
            _Context.AccHSRs.Remove(deleAccHSR);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AccHSR mn)
        {
            if (_Context.AccHSRs.Find(mn.UID) == null)
            {
                _Context.AccHSRs.Add(mn);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _Context.AccHSRs.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AccHSR mn)
        {
            if (ModelState.IsValid)
            {
                _Context.AccHSRs.Update(mn);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
